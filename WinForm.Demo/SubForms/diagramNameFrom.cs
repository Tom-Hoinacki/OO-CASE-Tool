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
    public partial class SaveProjectForm : Form
    {
        public SaveProjectForm()
        {
            InitializeComponent();
        }



        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.diagramNameText.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a name for the diagram!");

            }
            else
            {
                DiagramNameHelper.diagramName = this.diagramNameText.Text;
                this.Dispose();
            }
            
        }

        private void DiagramName_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
 
    }



    public static class DiagramNameHelper
   {
       public static string diagramName;
   }
}
