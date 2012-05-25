using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TreeGenerator;
using System.Xml;

namespace TestTreeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowTree_Click(object sender, EventArgs e)
        {

        }
       // private TreeGenerator.
        private TreeBuilder myTree=null;
        private void ShowTree()
        {
            picTree.Image = Image.FromStream(myTree.GenerateTree(-1, -1, "1", System.Drawing.Imaging.ImageFormat.Bmp));
            //picTree.Image.Save(@"d:\temp\1.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void SetControlValues()
        {
            if (myTree != null)
            {
                //lblBGColor.BackColor = myTree.BGColor;
               // lblBoxFillColor.BackColor = myTree.BoxFillColor;
               // lblFontColor.BackColor = myTree.FontColor;
               // lblLineColor.BackColor = myTree.LineColor;
                nudBoxHeight.Value = Convert.ToDecimal( myTree.BoxHeight);
                nudBoxWidth.Value  = Convert.ToDecimal( myTree.BoxWidth);
                nudFontSize.Value = Convert.ToDecimal( myTree.FontSize);
                nudHorizontalSpace.Value = Convert.ToDecimal( myTree.HorizontalSpace);
                nudLineWidth.Value =Convert.ToDecimal(  myTree.LineWidth);
                nudMargin.Value =Convert.ToDecimal(  myTree.Margin);
                nudVerticalSpace.Value = Convert.ToDecimal(myTree.VerticalSpace);
            
            
            }
        
        }

        private void lblFontColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.FontColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBoxFillColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BoxFillColor  = colorDialog1.Color;
            ShowTree();
        }

        private void lblLineColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.LineColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBGColor_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BGColor = colorDialog1.Color;
            ShowTree();
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            myTree.LineWidth =(float) nudLineWidth.Value;
            ShowTree();
        }

        private void nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            myTree.FontSize = (int)nudFontSize.Value;
            ShowTree();
        }

        private void nudVerticalSpace_ValueChanged(object sender, EventArgs e)
        {
            myTree.VerticalSpace = (int)nudVerticalSpace.Value;
            ShowTree();
        }

        private void nudHorizontalSpace_ValueChanged(object sender, EventArgs e)
        {
            myTree.HorizontalSpace = (int)nudHorizontalSpace.Value;
            ShowTree();
        }

        private void nudMargin_ValueChanged(object sender, EventArgs e)
        {
            myTree.Margin = (int)nudMargin.Value;
            ShowTree();
        }

        private void nudBoxHeight_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxHeight = (int)nudBoxHeight.Value;
            ShowTree();
        }

        private void nudBoxWidth_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxWidth = (int)nudBoxWidth.Value;
            ShowTree();
        }

        private void picOrgChart_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle currentRect;
            //determine if the mouse clicked on a box, if so, show the  node description.
            string SelectedNode = "No Node";
            //find the node
            foreach (XmlNode oNode in myTree.xmlTree.SelectNodes("//Node"))
            { 
                //iterate through all nodes until found.
                currentRect = myTree.getRectangleFromNode(oNode);
                if (e.X >= currentRect.Left &&
                    e.X <= currentRect.Right &&
                    e.Y >= currentRect.Top &&
                    e.Y <= currentRect.Bottom)
                {
                    SelectedNode = oNode.Attributes["nodeDescription"].InnerText;
                    break;
                }
                
               
            }
            
            //MessageBox.Show(SelectedNode);
            lblNodeText.Text = string.Format("Last Clicked:{0}", SelectedNode);
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            ShowTree();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TreeGenerator.TreeData.TreeDataTableDataTable dtTree = new TreeData.TreeDataTableDataTable();
//dtTree.AddTreeDataTableRow("1", "", "Sumil", "");
//dtTree.AddTreeDataTableRow("2", "1", "Amit", "");
//dtTree.AddTreeDataTableRow("3", "1", "Manoj", "");


            //dtTree.AddTreeDataTableRow("1", "", "1", "");
            //dtTree.AddTreeDataTableRow("2", "1", "2", "");
            //dtTree.AddTreeDataTableRow("3", "1", "3", "");
            //dtTree.AddTreeDataTableRow("4", "2", "4", "");
            //dtTree.AddTreeDataTableRow("5", "2", "5", "");
            //dtTree.AddTreeDataTableRow("6", "2", "6", "");
            //dtTree.AddTreeDataTableRow("7", "2", "7", "");
            //dtTree.AddTreeDataTableRow("8", "7", "8", "");
            //dtTree.AddTreeDataTableRow("9", "7", "9", "");
            //dtTree.AddTreeDataTableRow("10", "3", "10", "");
            //dtTree.AddTreeDataTableRow("11", "3", "11", "");
            //dtTree.AddTreeDataTableRow("12", "10", "12", "");
            //dtTree.AddTreeDataTableRow("13", "10", "13", "");
            //dtTree.AddTreeDataTableRow("14", "10", "14", "");
            //dtTree.AddTreeDataTableRow("15", "10", "15", "");
            //dtTree.AddTreeDataTableRow("16", "10", "16", "");
            //dtTree.AddTreeDataTableRow("17", "1", "17", "");
            //dtTree.AddTreeDataTableRow("18", "1", "18", "");
            

            
            //instantiate the object
            //myOrgChart = new OrgChartGenerator.OrgChart(myOrgData);
            myTree = new TreeBuilder(GetTreeData());
            SetControlValues();    
        }
        private TreeData.TreeDataTableDataTable GetTreeData()
        {
            TreeData.TreeDataTableDataTable dt = new TreeData.TreeDataTableDataTable();
            dt.AddTreeDataTableRow("1", "", "Localhost", "This is your Local Server");
            dt.AddTreeDataTableRow("2", "1", "Child 1", "This is the first child.");
            dt.AddTreeDataTableRow("3", "1", "Child 2", "This is the second child.");
            dt.AddTreeDataTableRow("4", "1", "Child 3", "This is the third child.");
            dt.AddTreeDataTableRow("5", "2", "GrandChild 1", "This is the only Grandchild.");
            for (int i = 6; i < 150; i++)
            {
                Random rand = new Random();
                dt.AddTreeDataTableRow(i.ToString(), rand.Next(1, i).ToString(), "GrandChild " + i.ToString(), "This is the only Grandchild.");
            }
            return dt;
        }

        private void btnRun100_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                myTree = new TreeBuilder(GetTreeData());
                picTree.Image = Image.FromStream(myTree.GenerateTree(-1, -1, "1", System.Drawing.Imaging.ImageFormat.Bmp));
                //picTree.Image.Save(string.Format(@"d:\temp\{0}.jpg",i.ToString()), System.Drawing.Imaging.ImageFormat.Jpeg);
            
            }

        }




    }
}
