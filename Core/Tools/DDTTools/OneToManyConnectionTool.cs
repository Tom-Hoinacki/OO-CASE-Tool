using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class OneToManyConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public OneToManyConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.ONETOMANY;
        }
        #endregion
    }

}

