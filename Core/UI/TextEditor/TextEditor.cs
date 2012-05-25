using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Netron.NetronLight.Win;
namespace Netron.NetronLight
{
    static class TextEditor
    {

        private static TextEditorControl editor = null;
        private static IShape currentShape;
        private static DiagramControl diagramControl;
        private static EventHandler<MouseEventArgs> onescape = new EventHandler<MouseEventArgs>(Controller_OnMouseDown);
        private static IShape Shape
        {
            get
            {
                return currentShape;
            }
        }
        private static TextEditorControl Editor
        {
            get
            {
                if(editor == null)        
                    editor = new TextEditorControl();
                return editor;
            }

        }
        public static void Init(DiagramControl parent)
        {
            diagramControl = parent;
            parent.Controls.Add(Editor);
            Editor.Visible = false;
        }

        public static TextEditorControl GetEditor(IShape shape)
        {
            if(shape == null)
                throw new InconsistencyException("Cannot assign an editor to a 'null' shape.");
            currentShape = shape;
            Editor.Location = currentShape.Rectangle.Location;
            Editor.Width = currentShape.Rectangle.Width;
            Editor.Height = currentShape.Rectangle.Height;
            Editor.Font = ArtPallet.DefaultFont;
            Editor.BackColor = diagramControl.BackColor;//            currentShape.ShapeColor;
            Editor.Visible = false;
            return Editor;
        }
        //public static TextEditorControl GetEditor(Rectangle rectangle, string text, Font font) 
        //{
        //    if(shape == null)
        //        throw new InconsistencyException("Cannot assign an editor to a 'null' shape.");
        //    currentShape = shape;
        //    Editor.Location = rectangle.Location;
        //    Editor.Width = rectangle.Width;
        //    Editor.Height = rectangle.Height;
        //    Editor.Font = font;
        //    Editor.Visible = false;
        //    return Editor;
        //}

        public static void Show()
        {
            if(currentShape == null)
                return;
            Selection.Clear();
            diagramControl.View.ResetTracker();
            diagramControl.Controller.SuspendAllTools();
            diagramControl.Controller.Enabled = false;
            diagramControl.Controller.OnMouseDown += onescape;
            Editor.Visible = true;
            Editor.Text = (currentShape as SimpleShapeBase).Text;
            Editor.SelectionLength = Editor.Text.Length;
            Editor.ScrollToCaret();
            Editor.Focus();
        }

        static void Controller_OnMouseDown(object sender, MouseEventArgs e)
        {
            Hide();
            diagramControl.Controller.OnMouseDown -= onescape;
        }
        public static void Hide()
        {
            if(currentShape == null)
                return;
            diagramControl.Controller.Enabled = true;
            diagramControl.Focus();
            Editor.Visible = false;
            (currentShape as SimpleShapeBase).Text = Editor.Text;
            diagramControl.Controller.UnsuspendAllTools();
            currentShape = null;
        }

        internal class TextEditorControl : TextBox
        {

            public TextEditorControl()
                : base()
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Multiline = true;
                this.ScrollBars = ScrollBars.None;
                this.WordWrap = true;
                this.BackColor = Color.White;
            }
         
        }
    }
    
}
