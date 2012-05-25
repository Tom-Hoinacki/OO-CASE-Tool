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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netron.NetronLight.Demo
{
    public partial class Form1 : Form
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
        bool fileBtn=false, menu=false;
        public DataEntryUserControl dataEntryControl;
        public GraphManipulationUserControl graphControl;
        public Form1()
        {
            DDT.DDTHelper.NewProj = true;
            dataEntryControl = new DataEntryUserControl();
            graphControl = new GraphManipulationUserControl();
            graphControl.parent = this;

            InitializeComponent();

            this.splitContainer1.Panel2.Controls.Add(dataEntryControl);
            this.splitContainer1.Panel2.Controls.Add(graphControl);
            this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataEntryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphControl.AutoScroll = true;
            dataEntryControl.Hide();
            graphControl.Hide();
        }



        private void dataEntryButton_Click(object sender, EventArgs e)
        {
            graphControl.Hide();
            dataEntryControl.Show();
            dataEntryButton.Hide();
            drawingButton.Hide();
            gohome.Show();
            
            menu_panel.Visible = false;

        }

        private void drawingButton_Click(object sender, EventArgs e)
        {
            dataEntryControl.Hide();
            graphControl.Show();
            dataEntryButton.Hide();
            drawingButton.Hide();
            gohome.Show();
            menu_panel.Visible = false;
        }

        private void gohome_Click(object sender, EventArgs e)
        {
            dataEntryControl.Hide();
            graphControl.Hide();
            drawingButton.Show();
            dataEntryButton.Show();
            gohome.Hide();
            menu_panel.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            menu_panel.Visible = false;
        }




       
        private void new_highlight_MouseEnter(object sender, EventArgs e)
        {
          
            label1.BackColor = Color.Gray;
            label1.ForeColor = Color.WhiteSmoke;
            new_highlight.FillColor = Color.Gray;
            label1.BringToFront();
           
        }

        private void new_highlight_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            new_highlight.FillColor = Color.White;
            //label1.SendToBack();
        }

        private void open_highlight_MouseEnter_1(object sender, EventArgs e)
        {
            label2.BackColor = Color.Gray;
            label2.ForeColor = Color.WhiteSmoke;
            open_highlight.FillColor = Color.Gray;
            label2.BringToFront();
        }

        private void open_highlight_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            open_highlight.FillColor = Color.White;
        }

        private void save_highlight_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Gray;
            label3.ForeColor = Color.WhiteSmoke;
            save_highlight.FillColor = Color.Gray;
            label3.BringToFront();
        }

        private void save_highlight_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            save_highlight.FillColor = Color.White;
        }

        private void exit_highlight_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Gray;
            label4.ForeColor = Color.WhiteSmoke;
            exit_highlight.FillColor = Color.Gray;
            label4.BringToFront();
        }

        private void exit_highlight_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            exit_highlight.FillColor = Color.White;
        }

        private void mainPanel_MouseDown_1(object sender, MouseEventArgs e)
        {
            menu_panel.Visible = false;
        }


        private void button_file_Click(object sender, EventArgs e)
        {
            if (menu_panel.Visible.Equals(false))
            // MessageBox.Show("yes");
            {
                menu_panel.Visible = true;

                label1.BringToFront();
            }

            else
            {//MessageBox.Show("no");
                menu_panel.Visible = false;

            }
        }

        private void exit_highlight_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to EXIT without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            if (!YorN)
            { return; }
            else 
            {
                this.Dispose();
            }

        }

        private void new_highlight_Click(object sender, EventArgs e)
        {
          
            // lets remove the current project. and start over.
            DDT.DDTHelper.manager.project = new DDT.DDTProject();
            DDT.DDTHelper.NewProj = true;
            menu_panel.Visible = false;

            //refresh object browsers
            dataEntryControl.objectExplorer_Enter(sender,e);
            graphControl.refresh();
            graphControl.ClearDiagrams();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

            graphControl.toolStripButton4_Click(sender, e);

            menu_panel.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            graphControl.saveButton_Click(sender, e);
            menu_panel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphControl.helpButton_Click(sender, e);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            menu_panel.Visible = false;
        }

        private void HELP_MouseHover(object sender, EventArgs e)
        {
            menu_panel.Visible = false;
        }

        private void Version_MouseHover(object sender, EventArgs e)
        {
            menu_panel.Visible = false;
        }

        private void Version_Click(object sender, EventArgs e)
        {
            VersionInfo verion = new VersionInfo();
            verion.Show(this);
        }

        

      /* 
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            menu_panel.Visible = false;
        }

        */

     
        
    

       

    }
}