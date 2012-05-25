using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class WideArrowConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public WideArrowConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.WIDEARROW;
        }
        #endregion

    }
}
