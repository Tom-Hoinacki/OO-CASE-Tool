using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class MoveTool : AbstractTool, IMouseListener
    {

        #region Fields
        private Point initialPoint;
        private Point lastPoint;

        private bool connectorMove;
        public bool AsConnectorMover
        {
            get
            {
                return connectorMove;
            }
            set
            {
                connectorMove = value;
            }
        }

        #endregion

        #region Constructor
        public MoveTool(string name)
            : base(name)
        {
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            Controller.View.CurrentCursor = CursorPallet.Move;

        }

        public void MouseDown(MouseEventArgs e)
        {
            if(e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            if(e.Button == MouseButtons.Left && Enabled && !IsSuspended)
            {
                if(Selection.SelectedItems.Count > 0)
                {
                    initialPoint = e.Location;
                    lastPoint = initialPoint;
                    connectorMove = false;
                    //while moving the shapes we'll clear the tracker
                    this.Controller.View.ResetTracker();
                    //now, go for it
                    this.ActivateTool();
                }
                else if(Selection.Connector != null)
                {
                    if(!typeof(IShape).IsInstanceOfType(Selection.Connector.Parent)) //note that there is a separate tool to move shape-connectors!
                    {
                        initialPoint = e.Location;
                        lastPoint = initialPoint;
                        connectorMove = true; //keep this for the final packaging into the undo manager
                        this.ActivateTool();
                    }
                }
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            if(e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            Point point = e.Location;
            if(IsActive)
            {
                //can be a connector
                if(Selection.Connector != null)
                {
                    Selection.Connector.Move(new Point(point.X - lastPoint.X, point.Y - lastPoint.Y));
                    #region Do we hit something meaningful?
                    IConnector hoveredConnector = Selection.FindConnectorAt(e.Location);
                    if(hoveredConnector != null && hoveredConnector!=Selection.Connector)
                    {
                        Controller.View.CurrentCursor = CursorPallet.Grip;
                    }
                    else
                        Controller.View.CurrentCursor = CursorPallet.Move;
                    #endregion
                }
                else //can be a selection
                {
                    foreach(IDiagramEntity entity in Selection.SelectedItems)
                    {

                        entity.Move(new Point(point.X - lastPoint.X, point.Y - lastPoint.Y));
                    }
                }
                lastPoint = point;
            }
        }
        public void MouseUp(MouseEventArgs e)
        {
            if(IsActive)
            {
                DeactivateTool();
                //creation of the total undoredo package
                CompoundCommand package = new CompoundCommand(this.Controller);
                string message = string.Empty;
                //notice that the connector can only be a connection connector because of the MouseDown check above
                if(connectorMove)
                {
                    #region We are moving a connection-connector
                    
                    #region Is the connector attached?
                    //detach only if there is a parent different than a connection; the join of a chained connection is allowed to move
                    if( Selection.Connector.AttachedTo != null && !typeof(IConnection).IsInstanceOfType(Selection.Connector.AttachedTo))
                    {
                        DetachConnectorCommand detach = new DetachConnectorCommand(this.Controller, Selection.Connector.AttachedTo, Selection.Connector);
                        detach.Redo();
                        package.Commands.Add(detach);

                    }
                    #endregion 
                    
                    #region The moving part
                    //a bundle might look like overkill here but it makes the coding model uniform
                    Bundle bundle = new Bundle(Controller.Model);
                    bundle.Entities.Add(Selection.Connector);
                    MoveCommand move = new MoveCommand(this.Controller, bundle, new Point(lastPoint.X - initialPoint.X, lastPoint.Y - initialPoint.Y));
                    //no Redo() necessary here!
                    package.Commands.Add(move);
                    #endregion 

                    #region The re-attachment near another connector
                    //let's see if the connection endpoints hit other connectors (different than the selected one!)   
                    //define a predicate delegate to filter things out otherwise the hit will return the moved connector which would results
                    //in a stack overflow later on
                    Predicate<IConnector> predicate =
                        delegate(IConnector conn)
                        {
                            //whatever, except itself and any children of the moved connector
                            //since this would entail a child becoming a parent!
                            if(conn.Hit(e.Location) && conn != Selection.Connector && !Selection.Connector.AttachedConnectors.Contains(conn)) 
                                return true;
                            return false;
                        };
                    //find it!
                    IConnector parentConnector = Selection.FindConnector(predicate);

                    if(parentConnector != null) //aha, there's an attachment
                    {
                        BindConnectorsCommand binder = new BindConnectorsCommand(this.Controller, parentConnector, Selection.Connector);
                        package.Commands.Add(binder);
                        binder.Redo(); //this one is necessary since the redo cannot be performed on the whole compound command
                        
                        // change the DDTConnection properties
                        if (Selection.Connector.Equals(((DDTConnection)Selection.Connector.Parent).From))
                        {
                            ((DDTConnection)Selection.Connector.Parent).fromId = ((IDDTObject)parentConnector.Parent).ID;
                            ((DDTConnection)Selection.Connector.Parent).fromConnectorIndex = DDTConnectionTool.getConnectorIndex(parentConnector);


                           // MessageBox.Show(((DDTConnection)Selection.Connector.Parent).fromId.ToString()); //connection
                           // MessageBox.Show(((DDTConnection)Selection.Connector.Parent).fromConnectorIndex.ToString());  //object
                        }
                        else //equals To
                        {
                            ((DDTConnection)Selection.Connector.Parent).toId = ((IDDTObject)parentConnector.Parent).ID;
                            ((DDTConnection)Selection.Connector.Parent).toConnectorIndex = DDTConnectionTool.getConnectorIndex(parentConnector);


                            //MessageBox.Show(((DDTConnection)Selection.Connector.Parent).toId.ToString()); //connection
                           // MessageBox.Show(((DDTConnection)Selection.Connector.Parent).toConnectorIndex.ToString());  //object
                        }




                    }
                    #endregion 
			
                    message = "Connector move";
                    #endregion
                }
                else
                {
                    #region We are moving entities other than a connector
                    Bundle bundle = new Bundle(Controller.Model);
                    bundle.Entities.AddRange(Selection.SelectedItems);
                    MoveCommand cmd = new MoveCommand(this.Controller, bundle, new Point(lastPoint.X - initialPoint.X, lastPoint.Y - initialPoint.Y));
                    package.Commands.Add(cmd);
                    //not necessary to perform the Redo action of the command since the mouse-move already moved the bundle!
                    #endregion

                    message = "Entities move";
                }
                package.Text = message;
                //whatever the content of the package we add it to the undo history                
                this.Controller.UndoManager.AddUndoCommand(package);

                //show the tracker again
                this.Controller.View.ShowTracker();

            }
        }
        #endregion
    }

}
