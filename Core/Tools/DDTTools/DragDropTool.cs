using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class DragDropTool : AbstractTool, IMouseListener, IDragDropListener
    {

        #region Fields
        Cursor feedbackCursor;
        #endregion

        #region Constructor
        public DragDropTool(string name) : base(name)
        { 
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            Controller.View.CurrentCursor = Cursors.SizeAll;
        }

        public void MouseDown(MouseEventArgs e)
        {
          
        }

        public void MouseMove(MouseEventArgs e)
        {
           
        }
        public void MouseUp(MouseEventArgs e)
        {
            
        }
        #endregion

        public void OnDragDrop(DragEventArgs e)
        {
          
            Control control = (Control)this.Controller.ParentControl;
            Point p = control.PointToClient(new Point(e.X, e.Y));
            IShape shape = null;
            IDataObject iDataObject = e.Data;

            if (DragHelp.DraggedShape != null)
            {
                shape = DragHelp.DraggedShape;
                Netron.NetronLight.DragHelp.DraggedShape = null;
            }  
            else if(iDataObject.GetDataPresent(typeof(string)))
            {
                foreach(string shapeType in Enum.GetNames(typeof(ShapeTypes)))
                {
                    if(shapeType.ToString().ToLower() == iDataObject.GetData(typeof(string)).ToString().ToLower())
                    {
                        shape = ShapeFactory.GetShape(shapeType); 
                        break;
                    }
                }
            }
            
            else if(iDataObject.GetDataPresent(typeof(Bitmap)))
            {
                
                return;

            }

            if(shape != null)
            {
                shape.Move(new Point(p.X, p.Y));
                //ComplexRectangle shape = new ComplexRectangle();
                //shape.Rectangle = new Rectangle(p.X, p.Y, 150, 70);
                //shape.Text = "Just an example, work in progress.";

                //TextLabel shape = new TextLabel();
                //shape.Rectangle = new Rectangle(p.X, p.Y, 150, 70);
                //shape.Text = "Just an example, work in progress.";

                AddShapeCommand cmd = new AddShapeCommand(this.Controller, shape, p);
                this.Controller.UndoManager.AddUndoCommand(cmd);
                cmd.Redo();
                feedbackCursor = null;
            }
        }

        public void OnDragLeave(EventArgs e)
        {
            
        }

        public void OnDragOver(DragEventArgs e)
        {   
        }


        public void OnDragEnter(DragEventArgs e)
        {
            AnalyzeData(e);
        }

        private void AnalyzeData(DragEventArgs e)
        {
            IDataObject iDataObject = e.Data;
            if(iDataObject.GetDataPresent(typeof(string)))
            {
                foreach(string shapeType in Enum.GetNames(typeof(ShapeTypes)))
                {
                    if(shapeType.ToString().ToLower() == iDataObject.GetData(typeof(string)).ToString().ToLower())
                    {
                        feedbackCursor = CursorPallet.DropShape;
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }

                feedbackCursor = CursorPallet.DropText;
                e.Effect = DragDropEffects.Copy;
                return;


            }
            if(iDataObject.GetDataPresent(typeof(Bitmap)))
            {
                feedbackCursor = CursorPallet.DropImage;
                e.Effect = DragDropEffects.Copy;
                return;

            }
        }


        public void GiveFeedback(GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = feedbackCursor;
        }
    }

}
