/*
 * CECS 543 Spring 2011
 * Team Number 1:
 *   Philip Brack(project Manager)
 *   Tom Hoinacki
 *   Ayan Kar
 *   Ravi Mahana
 *   Michael Ngo
 *   Panos Zoumpoulidis
 *   Yang Zhao
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DDT;

namespace Netron.NetronLight.Demo
{
    public partial class DataEntryUserControl : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        } 

        public DataEntryUserControl()
        {
            InitializeComponent();
            //ResizeRedraw = true;
            this.DoubleBuffered = true;
            cpanel.Hide(); 
            SetWindowTheme(objectExplorer.Handle, "explorer", null); 
            button_save.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void cpanel_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);
        public String a;
        public String attrib, domain, description;
        public Boolean key;

        // These variables should be used when creating new objects.
        public DDT.CObject newCObject = null;
        public bool newObject = false;
        public DDT.ADTObject newADTObject = null;
        public DDT.SMObject newSMObject = null;

        private void chighlight_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gray;
            label1.ForeColor = Color.WhiteSmoke;
            chighlight.FillColor = Color.Gray;
            label1.BringToFront();
            cpanel.Show();
            clean();
            cname.Clear();
            list_attrib.Items.Clear();
            newCObject = null;
            newCObject = new DDT.CObject();
            //MessageBox.Show(newCObject.ID.ToString());
            cname.Focus();

            // we are going to create a new object.
            newObject = true;
        }

        private void cname_TextChanged(object sender, EventArgs e)
        {
            a = cname.Text.ToUpper();
            clabel.Text = a;
            if (cname.Text == "")
            {
                clabel.Text = "{UNNAMED}";
                button_save.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                button_save.Enabled = true;
                groupBox1.Enabled = true;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            //chighlight.Hide();
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(64,64,64);
            cpanel.Hide();
            chighlight.FillColor = Color.Transparent;
            label1.SendToBack();
        }

        private void button_addattrib_Click(object sender, EventArgs e)
        {
            attrib = cattrib.Text;
            domain = cdomain.Text;
            description = cdescription.Text;
            if (key_yes.Checked)
                key = true;
            else if (key_no.Checked)
                key = false;
            groupBox2.Enabled = true;

            if (list_attrib.SelectedIndex == -1)
            {
                button_removeattrib.Enabled = false;
                button_editattrib.Enabled = false;
            }

            // add attributes to the new C object   
            if(list_attrib.SelectedIndex != -1)
            { 
                DDT.Attribute selectedAttribute = newCObject.attributes[list_attrib.SelectedIndex];
                if (selectedAttribute.name == cattrib.Text)
                {
                    selectedAttribute.domain = cdomain.Text;
                    selectedAttribute.description = cdescription.Text;
                    selectedAttribute.key = key;
                    cdomain.Focus();
                }
                else
                {
                    DDT.Attribute newAttribute = new DDT.Attribute(attrib, description, domain, key);
                    newCObject.attributes.Add(newAttribute);
                    list_attrib.Items.Add(attrib);
                }
            }
            else
            {
                DDT.Attribute newAttribute = new DDT.Attribute(attrib, description, domain, key);
                newCObject.attributes.Add(newAttribute);
                list_attrib.Items.Add(attrib);
            }
            cattrib.Focus();

            //clear everything after adding to list
            

        }

        private void button_save_Click(object sender, EventArgs e)
        { 
            newCObject.name = cname.Text; 
            // MessageBox.Show(newCObject.ID.ToString());
            if (newObject)
            {
                // if this a new object do the follow
                DDTHelper.manager.project.addNewCObject(newCObject); 
            }
            // set my reference to null
            clean();
            list_attrib.Items.Clear();
            cpanel.Hide();
            newCObject = null;
            newObject = false;
        }

        private void button_removeattrib_Click(object sender, EventArgs e)
        {
            if (list_attrib.SelectedIndex != -1)
            {
                list_attrib.Items.RemoveAt(list_attrib.SelectedIndex);
                newCObject.attributes.RemoveAt(list_attrib.SelectedIndex);
            }
            if (list_attrib.Items.Count==0)
            {
                button_editattrib.Enabled = false;
                button_removeattrib.Enabled = false;
            }
            clean();

        }

        private void button_editattrib_Click(object sender, EventArgs e)
        {
            if (list_attrib.SelectedIndex != -1)
            {
                DDT.Attribute selectedAttribute = newCObject.attributes[list_attrib.SelectedIndex];

                // fill my textboxes with stuff...
                cattrib.Text = selectedAttribute.name;
                cdomain.Text = selectedAttribute.domain;
                cdescription.Text = selectedAttribute.description;
                key = selectedAttribute.key;
                if (key == true)
                    key_yes.Checked = true;
                else
                    key_no.Checked = true;
                cdomain.Focus();
                cdomain.SelectAll();
            } 
        }

        /// functions for the objectExplorer
        public void objectExplorer_Enter(object sender, EventArgs e)
        {

            foreach (TreeNode n in objectExplorer.Nodes)  // Genres of objects
            {
                /*
                foreach (TreeNode nn in n.Nodes) // remove all subelements
                {
                    if(nn !=null)
                    n.Nodes.Remove(nn);
                }*/
                n.Nodes.Clear();
            }
            TreeNode newNode;
            // add elements
            foreach (DDT.CObject c in DDTHelper.manager.project.cObjects)
            {
                newNode = new TreeNode(c.name);
                newNode.Name = c.name;
                newNode.Tag = c;

                objectExplorer.Nodes[0].Nodes.Add(newNode);
            }
            foreach (DDT.ADTObject c in DDTHelper.manager.project.aObjects)
            {
                newNode = new TreeNode(c.name);
                newNode.Name = c.name;
                newNode.Tag = c;
                objectExplorer.Nodes[1].Nodes.Add(newNode);

            }
            foreach (DDT.SMObject c in DDTHelper.manager.project.smObjects)
            {
                newNode = new TreeNode(c.name);
                newNode.Name = c.name;
                newNode.Tag = c;
                objectExplorer.Nodes[2].Nodes.Add(newNode);

            }
            objectExplorer.EndUpdate();
        }


        public DDT.CObject currentCObject = null;  // one way to do the updating...
        private void objectExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level != 0)
            {
                if (e.Node.Tag.GetType() == typeof(DDT.CObject))
                {
                    newCObject = (DDT.CObject)e.Node.Tag;
                   // MessageBox.Show("display C object gui thingy");
                    cname.Text = newCObject.name;
                    list_attrib.Items.Clear();
                    foreach( DDT.Attribute a in newCObject.attributes)
                    {
                        list_attrib.Items.Add(a.name);
                    }
                    cpanel.Show();
                    //TODO add the code to fill your data.
                }
                else if (e.Node.Tag.GetType() == typeof(DDT.ADTObject))
                {
                    MessageBox.Show("display ADT object gui thingy");
                }
                else if (e.Node.Tag.GetType() == typeof(DDT.SMObject))
                {
                    MessageBox.Show("display SM object gui thingy");
                }

            }
        }

        private void list_attrib_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(list_attrib.SelectedIndex != -1)
                button_removeattrib.Enabled = true;
            button_editattrib.Enabled = true;
        }

        private void clean()
        {
            cattrib.Clear();
            cdomain.Clear();
            cdescription.Clear();
            key_yes.Checked = false;
            key_no.Checked = false;
            attrib = "";
            domain = "";
            description = "";
           
            key.Equals(null);}

 
        
      /*  public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            var form = Form.ActiveForm as Form1;
            form.menu_panel.Visible = false;
        } 

 */
        ///end functions for the objectExplorer



       // public string a { get; set; }


        
    }
}
