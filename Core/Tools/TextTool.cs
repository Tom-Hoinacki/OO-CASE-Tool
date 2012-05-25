using System;
using System.Drawing;

namespace Netron.NetronLight
{
    class TextTool : AbstractDrawingTool
    {
        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor
        public TextTool() : base("Text Tool")
        {
        }
        public TextTool(string name): base(name)
        {

        }
        #endregion

        #region Methods
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (IsActive && started)
            {
                Point point = new Point(e.X, e.Y);
                Controller.View.PaintGhostRectangle(startingPoint, point);
                Controller.View.Invalidate(System.Drawing.Rectangle.Inflate(Controller.View.Ghost.Rectangle, 20, 20));
            }
        }


        protected override void GhostDrawingComplete()
        {

            try
            {
                TextOnly shape = new TextOnly(this.Controller.Model);
                shape.Width = (int) Rectangle.Width;
                shape.Height = (int) Rectangle.Height;
                shape.Text = "New label";
                shape.ShapeColor = Color.WhiteSmoke;
                AddShapeCommand cmd = new AddShapeCommand(this.Controller, shape, new Point((int) Rectangle.X, (int)Rectangle.Y));
                this.Controller.UndoManager.AddUndoCommand(cmd);
                cmd.Redo();
                TextEditor.GetEditor(shape);
                TextEditor.Show();
            }
            catch
            {
                base.Controller.DeactivateTool(this);
                Controller.View.Invalidate();
                throw;
            }

            base.Controller.DeactivateTool(this);
        }


        #endregion
    }

}
