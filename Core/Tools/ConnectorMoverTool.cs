using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{
    class ConnectorMoverTool : AbstractTool, IMouseListener
    {

        #region Fields
        private Point initialPoint;
        private Point lastPoint;
        private IConnector fetchedConnector;
        private bool motionStarted;

        #endregion

        #region Constructor
        public ConnectorMoverTool(string name) : base(name)
        {
        }
        #endregion

        #region Methods

        protected override void OnActivateTool()
        {
            Controller.View.CurrentCursor = CursorPallet.Select;
            motionStarted = false;
            fetchedConnector = null;
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            if (e.Button == MouseButtons.Left && Enabled && !IsSuspended)
            {
                fetchedConnector = Selection.FindShapeConnector(e.Location);
                if(fetchedConnector != null)
                {
                    
                        initialPoint = e.Location;
                        lastPoint = initialPoint;
                        motionStarted = true;
                        
                    
                }
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            Point point = e.Location;
            if(IsActive && motionStarted)
            {

                fetchedConnector.Move(new Point(point.X - lastPoint.X, point.Y - lastPoint.Y));
                
                lastPoint = point;
            }            
        }
        public void MouseUp(MouseEventArgs e)
        {
            if (IsActive)
            {
                DeactivateTool();
                if(fetchedConnector == null)
                    return;
                Bundle bundle = new Bundle(Controller.Model);
                bundle.Entities.Add(fetchedConnector);
                MoveCommand cmd = new MoveCommand(this.Controller, bundle, new Point(lastPoint.X - initialPoint.X, lastPoint.Y - initialPoint.Y));
                Controller.UndoManager.AddUndoCommand(cmd);
                //not necessary to perform the Redo action of the command since the mouse-move already moved the bundle!
            }
        }
        #endregion
    }

}
