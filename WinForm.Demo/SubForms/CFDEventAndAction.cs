using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netron.NetronLight.Demo
{
    public partial class CFDEventAndAction : Form
    {
        private Netron.NetronLight.DDTConnection conn;
        public CFDEventAndAction()
        {
            InitializeComponent();

            this.conn = Netron.NetronLight.Demo.NetronDDTHelper.getDDTConnection();
            this.fromText.Text = conn.fromText;
            
            this.middleText.Text = conn.midText;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            conn.setText(this.fromText.Text, this.middleText.Text, "");
            conn.addConnectionText();

            DDT.DDTHelper.UNSAVED();
            this.Dispose();
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void erase_Click(object sender, EventArgs e)
        {
            this.fromText.Text = null;
            this.middleText.Text = null;
        }


    }
}
