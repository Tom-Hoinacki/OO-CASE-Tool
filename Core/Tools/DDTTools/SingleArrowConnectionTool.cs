using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class SingleArrowConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public SingleArrowConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.SINGLEARROW;
        }
        #endregion

    }
}
