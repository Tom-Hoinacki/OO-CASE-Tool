using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class DashedArrowConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public DashedArrowConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.DASHEDARROW;
        }
        #endregion
    }

}

