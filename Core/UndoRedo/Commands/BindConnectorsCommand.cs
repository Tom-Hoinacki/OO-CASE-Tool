using System;
using System.Collections.Generic;
using System.Text;

namespace Netron.NetronLight
{
    class BindConnectorsCommand : Command
    {
        IConnector parent;
        IConnector child;

        public override void Redo()
        {
            parent.AttachConnector(child);
        }
        public override void Undo()
        {
            parent.DetachConnector(child);
        }

        #region Constructor
        public BindConnectorsCommand(IController controller, IConnector parent, IConnector child) : base(controller)
        {
            this.parent = parent;
            this.child = child;
        }
        #endregion
  
    }
}
