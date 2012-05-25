using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class NormalConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public NormalConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.NORMAL;
        }
        #endregion
    }

}

