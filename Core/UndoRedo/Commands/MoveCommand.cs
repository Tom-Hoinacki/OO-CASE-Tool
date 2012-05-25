using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    class MoveCommand : Command
    {
        #region Fields
        IBundle bundle;
        IController controller;
        Point delta;
        #endregion

        #region Properties

        public CollectionBase<IDiagramEntity> Entities
        {
            get { return bundle.Entities; }
        }

        #endregion

        #region Constructor
        public MoveCommand(IController controller, IBundle bundle, Point delta)
            : base(controller)
        {
            this.Text = "Move " + bundle.EntityName;
            this.controller = controller;
            this.delta = delta;
            this.bundle = bundle;
        }
        #endregion

        #region Methods

        public override void Redo()
        {
            bundle.Move(delta);
            //invalidate the space before the move
            Rectangle rec = bundle.Rectangle;
            rec.Offset(-delta.X, -delta.Y);
            rec.Inflate(20, 20);
            bundle.Invalidate(rec);//same as an invalidate on the controller level
            //invalidate the current neighborhood of the bundle
            bundle.Invalidate();

        }

        public override void Undo()
        {
            bundle.Move(new Point(-delta.X, -delta.Y)); //invert the vector
            //invalidate the space before the move
            Rectangle rec = bundle.Rectangle;
            rec.Offset(delta.X, delta.Y);
            rec.Inflate(20, 20);
            bundle.Invalidate(rec);//same as an invalidate on the controller level
            //invalidate the current neighborhood of the bundle
            bundle.Invalidate();
        }


        #endregion
    }

}