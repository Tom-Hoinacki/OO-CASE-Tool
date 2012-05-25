using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class DDTConnectionTool : AbstractTool, IMouseListener
    {

        #region Fields
        protected Point initialPoint;
        protected bool doDraw;
        protected ConnectionType connectionType = ConnectionType.NORMAL;

        #endregion

        #region Constructor
        public DDTConnectionTool(string name)
            : base(name)
        {
        }
        #endregion

        #region Methods
        public static int getConnectorIndex(IConnector cnct)
        {
           if(cnct.Equals(((IDDTObject)cnct.Parent).connectorA))
           {
              return 1;
           }
           else if(cnct.Equals(((IDDTObject)cnct.Parent).connectorB))
           {
              return 2;
           }
           else if(cnct.Equals(((IDDTObject)cnct.Parent).connectorC))
           {
              return 3;
           }
           else if(cnct.Equals(((IDDTObject)cnct.Parent).connectorD))
           {
               return 4;
           }
           else
            return 0;
        
        }



        protected override void OnActivateTool()
        {
            Controller.View.CurrentCursor =CursorPallet.Grip;
            this.SuspendOtherTools(); 
            doDraw = false;
        }

        public void MouseDown(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            if (e.Button == MouseButtons.Left && Enabled && !IsSuspended)
            {
               
                    initialPoint = e.Location;
                    doDraw = true;
                               
            }
        }

        public virtual void MouseMove(MouseEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("The argument object is 'null'");
            Point point = e.Location;
            if(IsActive && doDraw)
            {
                Controller.View.PaintGhostLine(initialPoint, point);
                Controller.View.Invalidate(System.Drawing.Rectangle.Inflate(Controller.View.Ghost.Rectangle, 20, 20));
            }            
        }
        public void MouseUp(MouseEventArgs e)
        {
            if (IsActive)
            {
                DeactivateTool();

                //whatever comes hereafter, a compund command is the most economic approach
                CompoundCommand package = new CompoundCommand(this.Controller);

                //let's see if the connection endpoints hit other connectors
                //note that the following can be done because the actual connection has not been created yet
                //otherwise the search would find the endpoints of the newly created connection, which
                //would create a loop and a stack overflow!
                IConnector startConnector = Selection.FindConnectorAt(initialPoint);
                IConnector endConnector = Selection.FindConnectorAt(e.Location);

                #region Create the new connection
                DDTConnection cn = new DDTConnection(this.initialPoint, e.Location, this.Controller.Model, connectionType);
                
                AddConnectionCommand newcon = new AddConnectionCommand(this.Controller, cn);
                package.Commands.Add(newcon);
                #endregion 
			
                #region assign id

                if(startConnector != null)
                {
                    BindConnectorsCommand bindStart = new BindConnectorsCommand(this.Controller, startConnector, cn.From);
                    package.Commands.Add(bindStart);
                    cn.fromConnectorIndex = getConnectorIndex(startConnector);
                    cn.fromId = ((IDDTObject)startConnector.Parent).ID; 
                }
                #endregion 

                #region  
                if(endConnector != null)
                {
                    BindConnectorsCommand bindEnd = new BindConnectorsCommand(this.Controller, endConnector, cn.To);
                    package.Commands.Add(bindEnd);
                    cn.toConnectorIndex = getConnectorIndex(endConnector);
                    cn.toId = ((IDDTObject)endConnector.Parent).ID; 
                }
                #endregion 
			     package.Text = "New connection";
                this.Controller.UndoManager.AddUndoCommand(package);
               
                //do it all
                package.Redo();
			    
                
                //drop the painted ghost
                Controller.View.ResetGhost();
                //release other tools
                this.UnsuspendTools();
            }
            
        }
        #endregion
    }

}
