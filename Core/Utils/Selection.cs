using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    public static class Selection
    {
        #region Events
        public static event EventHandler OnNewSelection;
        #endregion

        #region Fields
        private static IController mController;
        private static SelectionTypes mSelectionType = SelectionTypes.Partial;
        private static CollectionBase<IDiagramEntity> mSelection = new CollectionBase<IDiagramEntity>();
        private static IModel mModel;
        private static IConnector connector;
        #endregion

        #region Properties
        public static IConnector Connector
        {
            get
            {
                return Selection.connector;
            }
            set
            {
                Selection.connector = value;
            }
        }

        public static IModel Model
        {
            get
            {
                return mModel;
            }
        }

        public static CollectionBase<IDiagramEntity> SelectedItems
        {
            get
            {
                return Selection.mSelection;
            }
            internal set
            {
                if(value == null || value.Count == 0)
                    return;
                //clear the current selection
                Clear();

                Selection.mSelection = value;
                foreach(IDiagramEntity entity in value)
                {
                    if(entity.Group != null)
                        entity.Group.IsSelected = true;
                    else
                        entity.IsSelected = true;
                }
            }
        }
        public static CollectionBase<IDiagramEntity> FlattenedSelectionItems
        {
            get
            {
                CollectionBase<IDiagramEntity> flatList = new CollectionBase<IDiagramEntity>();
                foreach(IDiagramEntity entity in mSelection)
                {
                    if(entity is IGroup)
                        Utils.TraverseCollect(entity as IGroup, ref flatList);
                    else
                        flatList.Add(entity);
                }
                return flatList;
            }
        }
       

        public static IController Controller
        {
            get
            {
                return Selection.mController;
            }
            set
            {
                Selection.mController = value;
                mModel = value.Model;
            }
        }
        #endregion

        #region Methods

        public static IConnector FindConnector(Predicate<IConnector> predicate)
        {
            IConnection con;
            IShape sh;

            foreach(IDiagramEntity entity in Model.Paintables)
            {
                if(typeof(IShape).IsInstanceOfType(entity))
                {
                    sh = entity as IShape;
                    foreach(IConnector cn in sh.Connectors)
                    {
                        if(predicate(cn))
                            return cn;
                    }
                }
                else if(typeof(IConnection).IsInstanceOfType(entity))
                {
                    con = entity as IConnection;
                    if(predicate(con.From))
                        return con.From;
                    if(predicate(con.To))
                        return con.To;
                }
            }
            return null;
        }

        public static IConnector FindShapeConnector(Point surfacePoint)
        {


            IShape sh;

            foreach(IDiagramEntity entity in Model.Paintables)
            {
                if(typeof(IShape).IsInstanceOfType(entity))
                {
                    sh = entity as IShape;
                    foreach(IConnector cn in sh.Connectors)
                    {
                        if(cn.Hit(surfacePoint))
                            return cn;
                    }
                }
            }
            return null;
        }

        public static IConnector FindConnectorAt(Point surfacePoint)
        {
            IConnection con;
            IShape sh;

            foreach(IDiagramEntity entity in Model.Paintables)
            {
                if(typeof(IShape).IsInstanceOfType(entity))
                {
                    sh = entity as IShape;
                    foreach(IConnector cn in sh.Connectors)
                    {
                        if(cn.Hit(surfacePoint))
                            return cn;
                    }
                }
                else if(typeof(IConnection).IsInstanceOfType(entity))
                {
                    con = entity as IConnection;
                    if(con.From.Hit(surfacePoint))
                        return con.From;
                    if(con.To.Hit(surfacePoint))
                        return con.To;
                }
            }
            return null;
        }
        public static void CollectEntitiesAt(Point surfacePoint)
        {
            if(surfacePoint == Point.Empty)
                return;
            if(Selection.mController == null)
                return;

            //only change the current selection if the mouse did not hit an already selected element
            if(mSelection.Count > 0)
            {
                foreach(IDiagramEntity entity in mSelection)
                {
                    if(entity.Rectangle.Contains(surfacePoint))
                        return;
                }
            }

            //here the scene-graph will play a role in the future,
            //for now we'll keep is simple
            Selection.Clear();

            IConnection con;
            IShape sh;

            //we use the paintables here rather than traversing the scene-graph because only
            //visible things can be collected
            //We traverse the paintables from top to bottom since the highest z-order
            //is at the top of the stack.

            for (int k = Model.Paintables.Count - 1; k >= 0; k--)
            {
                IDiagramEntity entity = Model.Paintables[k];

                #region we give priority to the connector selection
                if (typeof(IConnection).IsInstanceOfType(entity))
                {
                    con = entity as IConnection;
                    if (con.From.Hit(surfacePoint))
                    {
                        connector = con.From;
                        connector.IsSelected = true;
                        Invalidate();
                        return;
                    }
                    if (con.To.Hit(surfacePoint))
                    {
                        connector = con.To;
                        connector.IsSelected = true;
                        Invalidate();
                        return;
                    }
                }
                else
                    if (typeof(IShape).IsInstanceOfType(entity))
                    {
                        sh = entity as IShape;
                        foreach (IConnector cn in sh.Connectors)
                        {
                            //if there are connectors attached to the shape connector, the attached ones should be picked up and not the one of the shape
                            if (cn.Hit(surfacePoint) && cn.AttachedConnectors.Count == 0)
                            {
                                connector = cn;
                                connector.IsSelected = true;
                                Invalidate();//this will invalidate only the selected connector
                                return; //we hit a connector and quit the selection. If the user intended to select the entity it had to be away from the connector!
                            }
                        }
                    }

                #endregion

                #region no connector was hit, maybe the entity itself
                if (entity.Hit(surfacePoint))
                {

                    //if the entity is part of an IGroup, the IGroup should be selected
                    //rather than the entity itself
                    //Note that the Group property returns the top group parent and not
                    //just the immediate parent of an entity
                    if (entity.Group != null)
                    {
                        entity.Group.IsSelected = true;
                        mSelection.Add(entity.Group);
                    }
                    else
                    {
                        entity.IsSelected = true;
                        mSelection.Add(entity);
                    }


                    break;
                }
                #endregion
            }
            RaiseOnNewSelection();
            Invalidate();

            //Using a full invalidate is rather expensive, so we'll only refresh the current selection
            //Controller.View.Invalidate();

        }

        private static void RaiseOnNewSelection()
        {
            if(OnNewSelection != null)
                OnNewSelection(null, EventArgs.Empty);
        }
        public static void Invalidate()
        {
            if(connector != null)
                connector.Invalidate();

            foreach(IDiagramEntity entity in mSelection)
            {
                entity.Invalidate();
            }
        }
        public static void CollectEntitiesInside(Rectangle surfaceRectangle)
        {
            if(surfaceRectangle == Rectangle.Empty)
                return;
            Selection.Clear();
            foreach(IDiagramEntity entity in Selection.Controller.Model.Paintables)
            {
               //if the entity is part of a group we have to look at the bigger picture
                if(mSelectionType == SelectionTypes.Inclusion)
                {
                    if(entity.Group != null)
                    {
                        //the rectangle must contain the whole group
                        if(surfaceRectangle.Contains(entity.Group.Rectangle))
                        {
                            //add the group if not already present via another group member
                            if(!mSelection.Contains(entity.Group))
                                mSelection.Add(entity.Group);
                            continue;
                        }
                    }
                    else
                    {
                        if(surfaceRectangle.Contains(entity.Rectangle))
                        {

                            mSelection.Add(entity);
                            entity.IsSelected = true;
                        }
                    }
                }
                else //the selection requires only partial overlap with the rectangle
                {
                    if(entity.Group != null)
                    {
                        if(surfaceRectangle.IntersectsWith(entity.Group.Rectangle))
                        {
                            if(!mSelection.Contains(entity.Group))
                                mSelection.Add(entity.Group);
                            continue;
                        }
                    }
                    else
                    {
                        if(surfaceRectangle.IntersectsWith(entity.Rectangle))
                        {
                            mSelection.Add(entity);
                            entity.IsSelected = true;
                        }
                    }
                }
                

                
            }
            RaiseOnNewSelection();

        }
        public static void Clear()
        {
            if(connector != null)
            {
                connector.IsSelected = false;
                connector = null;
                ;
            }



            if(Selection.mController == null)
                return;
            //deselect the current ones
            foreach(IDiagramEntity entity in SelectedItems)
            {
                entity.IsSelected = false;
            }
            //forget the current state
            mSelection.Clear();
            Controller.View.Invalidate();
        }

        
        #endregion
    }
}
