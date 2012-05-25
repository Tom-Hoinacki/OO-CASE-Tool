using System;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Netron.NetronLight
{

    class OneToOneConnectionTool : DDTConnectionTool
    {

        #region Constructor
        public OneToOneConnectionTool(string name)
            : base(name)
        {
            this.connectionType = ConnectionType.ONETOONE;
        }
        #endregion
    }

}

