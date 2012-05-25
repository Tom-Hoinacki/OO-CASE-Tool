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
    public partial class EditOtherObjects : Form
    {
        private Netron.NetronLight.IDDTObject obj;

        public EditOtherObjects()
        {
            InitializeComponent();
            obj = Netron.NetronLight.Demo.NetronDDTHelper.getIDDTObject();
            this.nameText.Text = obj.Text;
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            obj.Text = this.nameText.Text; 
            DDT.DDTHelper.UNSAVED();
            this.Dispose();
        }

        private void erase_Click(object sender, EventArgs e)
        {
            this.nameText.Text = null;
        }
    }
}
