using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    class GroupCommand : Command
    {
        #region Fields
        IBundle bundle;
        IController controller;
        IGroup mGroup;
        #endregion

        #region Properties
        public IGroup Group
        {
            get { return mGroup; }
        }

        public CollectionBase<IDiagramEntity> Entities
        {
            get { return bundle.Entities; }
        }

        #endregion

        #region Constructor
        public GroupCommand(IController controller, IBundle bundle)
            : base(controller)
        {
            this.Text = "Group";
            this.controller = controller;
            this.bundle = bundle;//the bundle should contain only IShape and IConnection entities!
        }
        #endregion

        #region Methods

        public override void Redo()
        {
            //create a new group
            GroupShape group = new GroupShape(this.Controller.Model);
            //asign the entities to the group
            group.Entities.Clear();
            
            foreach (IDiagramEntity entity in bundle.Entities)
            {
                //this will be recursive if an entity is itself an IGroup
                entity.Group = group;
                group.Entities.Add(entity);
            }
            //add the new group to the layer
            this.Controller.Model.DefaultPage.DefaultLayer.Entities.Add(group);

            mGroup = group;

            //select the newly created group
            CollectionBase<IDiagramEntity> col = new CollectionBase<IDiagramEntity>();
            col.Add(mGroup);                  
            Selection.SelectedItems = col;
            mGroup.Invalidate();
        }

        public override void Undo()
        {
            

            //remove the group from the layer
            this.Controller.Model.DefaultPage.DefaultLayer.Entities.Remove(mGroup);
          //detach the entities from the group
            foreach (IDiagramEntity entity in mGroup.Entities)
            {
                //this will be recursive if an entity is itself an IGroup
                entity.Group = null;
            }
            //change the visuals such that the entities in the group are selected
            Selection.SelectedItems = mGroup.Entities;

            mGroup.Invalidate();

            mGroup = null;

            //note that the entities have never been disconnected from the layer
            //so they don't have to be re-attached to the anything.
            //The insertion of the Group simply got pushed in the scene-graph.


        }


        #endregion
    }

}