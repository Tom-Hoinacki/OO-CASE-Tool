using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Netron.NetronLight
{
    class AddShapeCommand : Command
    {
        IShape shape;        
        Point location;        

        public IShape Shape
        {
            get { return shape; }
        }

        

        public  AddShapeCommand(IController controller, IShape shape, Point location) :base(controller)
        {
            if (shape == null)
                throw new ArgumentNullException("The shape is 'null' and cannot be inserted.");            
            this.Text = "Add " + shape.EntityName;          

            this.location = location;
            this.shape = shape;
        }

        public override void Redo()
        {
            Controller.Model.AddShape(shape);
            
            shape.Transform(location.X, location.Y, shape.Width, shape.Height);
            Rectangle rec = shape.Rectangle;
            rec.Inflate(20, 20);
            Controller.View.Invalidate(rec);            
        }

        public override void Undo()
        {
            Rectangle rec = shape.Rectangle;
            rec.Inflate(20, 20);
            Controller.Model.RemoveShape(shape);

            Controller.View.Invalidate(rec);
            
        }


    }

}
