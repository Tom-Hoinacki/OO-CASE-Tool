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
    public partial class TransactionDrivenFrom : Form
    {
        public TransactionDrivenFrom()
        {
            InitializeComponent();

            foreach (int objId in DDT.ConversionHelper.objectIdList)
            {
                processingbox.Items.Add(getObjectName(objId)+"="+objId);
                OutputProcessing.Items.Add(getObjectName(objId)+"="+objId);
            
            }

        }

        private string getObjectName(int ObjId)
        {
          return  DDT.DDTHelper.manager.getDDTObjectNameById(ObjId);
        }

        private void processingbox_TextChanged(object sender, EventArgs e)
        {
            if (processingbox.SelectedItem.ToString() == OutputProcessing.SelectedItem.ToString())
                OutputProcessing.SelectedItem = null;
        }

        private void OutputProcessing_TextChanged(object sender, EventArgs e)
        {
            if (processingbox.SelectedItem.ToString() == OutputProcessing.SelectedItem.ToString())
                processingbox.SelectedItem = null;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DDT.ConversionHelper.processingObjectId = 0;
            DDT.ConversionHelper.OutputObjectId = 0;
            this.Dispose();
        }

        private int getObjectIdFromItem(object item)
        {
            string tmp="";
            int index = item.ToString().LastIndexOf('=');
            tmp = item.ToString().Substring(index + 1);
            return Int32.Parse(tmp);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (processingbox.SelectedItem.Equals(null) || OutputProcessing.SelectedItem.Equals(null))
            {
                MessageBox.Show("Please choose both objects!", "WARNING");
            }

            DDT.ConversionHelper.processingObjectId = getObjectIdFromItem(processingbox.SelectedItem.ToString());
            DDT.ConversionHelper.OutputObjectId = getObjectIdFromItem(OutputProcessing.SelectedItem.ToString());

            this.Dispose();
        }



    }
}
