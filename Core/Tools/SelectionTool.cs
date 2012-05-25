using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class SelectionTool : AbstractTool, IMouseListener
    {

        #region Fields
        private Point initialPoint;

        #endregion

        #region Constructor
        public SelectionTool(string name) : base(name)
        {
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            Controller.View.CurrentCursor = CursorPallet.Selection;
        }

        public void MouseDown(MouseEventArgs e)
        {
            
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            if (e.Button == MouseButtons.Left && Enabled && !IsSuspended)
            {
                if(Selection.SelectedItems.Count == 0 && Selection.Connector==null)
                {
                    initialPoint = e.Location;                    
                    this.ActivateTool();
                }                
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            Point point = e.Location;
            if(IsActive && !IsSuspended)
            {
                Controller.View.PaintGhostRectangle(initialPoint, point);
                Controller.View.Invalidate(System.Drawing.Rectangle.Inflate(Controller.View.Ghost.Rectangle, 20, 20));
            }            
        }
        public void MouseUp(MouseEventArgs e)
        {
            if (IsActive)
            {
                DeactivateTool();
                if(Controller.View.Ghost != null)
                {
                    Selection.CollectEntitiesInside(Controller.View.Ghost.Rectangle);
                    Controller.RaiseOnShowSelectionProperties(new SelectionEventArgs(Selection.SelectedItems.ToArray()));
                }
                //Bundle bundle = new Bundle(Controller.Model);
                //bundle.Entities.AddRange(Selection.SelectedItems);
                //MoveCommand cmd = new MoveCommand(this.Controller, bundle, new Point(lastPoint.X - initialPoint.X, lastPoint.Y - initialPoint.Y));
                //Controller.UndoManager.AddUndoCommand(cmd);
                Controller.View.ResetGhost();

            }
        }
        #endregion
    }

}
