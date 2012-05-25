using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class DoubleArrowConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public DoubleArrowConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.DOUBLEARROW;
        }
        #endregion

    }
}
