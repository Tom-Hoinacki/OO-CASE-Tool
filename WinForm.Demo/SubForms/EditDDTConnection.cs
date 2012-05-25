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
    public partial class EditDDTConnection : Form
    {
        private Netron.NetronLight.DDTConnection conn;
        public EditDDTConnection()
        {
            InitializeComponent();

            this.conn = Netron.NetronLight.Demo.NetronDDTHelper.getDDTConnection();
            this.fromText.Text = conn.fromText;
            this.toText.Text = conn.toText;
            this.middleText.Text = conn.midText;
        }

        private void help_Click(object sender, EventArgs e)
        {
            conncetionHelp ch = new conncetionHelp();
            ch.Show(this);
        }
        private void erase_Click(object sender, EventArgs e)
        {
            this.fromText.Text = null;
            this.middleText.Text = null;
            this.toText.Text = null;
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            conn.setText(this.fromText.Text, this.middleText.Text, this.toText.Text);
            conn.addConnectionText();

            DDT.DDTHelper.UNSAVED();
            this.Dispose();
        }


    }
}
