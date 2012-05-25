using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class DiamondArrowConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public DiamondArrowConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.DIAMONDARROW;
        }
        #endregion
    }

}

