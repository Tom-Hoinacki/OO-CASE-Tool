using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class ManyToManyConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public ManyToManyConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.MANYTOMANY;
        }
        #endregion
    }

}

