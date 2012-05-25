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
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Permissions;
using System.Security;

namespace Netron.NetronLight.Demo
{

    public partial class GraphManipulationUserControl : UserControl
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


        //DDT.DDTProjectDrawingManagement ddtprojmgmt;
       
        DDT.DDTTabManagement tabmgmt;
        DDT.DDTTabControl ERDTabControl;
        DDT.DDTTabControl CHTabControl;
        DDT.DDTTabControl CFDTabControl;
        DDT.DDTTabControl DFDTabControl;
        DDT.DDTTabControl DMDTabControl;
        DDT.DDTTabControl ORVTabControl;
        System.Drawing.Image image;

        TabControl tabControl; //current tabcontrol
        DDT.DDT_Diagram_Type currentType;
        
        public Form parent;

        public GraphManipulationUserControl()
        {
            InitializeComponent();
            ReloadGraphicControl();
        }

        public void ReloadGraphicControl()
        {
            this.ProjectStatus.Text = "Ready";
            // this.getDiagramControl().controller.OnShowContextMenu += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.controller_OnShowContextMenu);

            //test

            currentType = DDT.DDT_Diagram_Type.ERD;


            // DDT.DDTHelper.manager



            //initialize tabcontrols, make ERD as default control
            CFDTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.CFD);
            DFDTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.DFD);
            ERDTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.ERD);
            CHTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.CH);
            DMDTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.DMD);
            ORVTabControl = new DDT.DDTTabControl(DDT.DDT_Diagram_Type.ORV);


            tabmgmt = new DDT.DDTTabManagement((DDT.DDTTabControl)ERDTabControl);

            tabmgmt.parent = this;
            //////////////////////////////////////////////////////////////////////////////////
            //add a default ERD diagram
            DDT.DDTDiagram default_ERD = DDT.DDTHelper.manager.newDiagram("default_ERD", this.currentType);

            this.tabmgmt.LoadDiagram(default_ERD);
            
            //////////////////////////////////////////////////////////////////////////////////

            this.splitContainerright.Panel2.Controls.Add(this.ERDTabControl);
            this.splitContainerright.Panel2.Controls.Add(this.DFDTabControl);
            this.splitContainerright.Panel2.Controls.Add(this.CFDTabControl);
            this.splitContainerright.Panel2.Controls.Add(this.CHTabControl);
            this.splitContainerright.Panel2.Controls.Add(this.DMDTabControl);
            this.splitContainerright.Panel2.Controls.Add(this.ORVTabControl);

            setupTabcontrol(this.ERDTabControl);
            setupTabcontrol(this.DFDTabControl);
            setupTabcontrol(this.CFDTabControl);
            setupTabcontrol(this.CHTabControl);
            setupTabcontrol(this.DMDTabControl);
            setupTabcontrol(this.ORVTabControl);


            this.tabControl = ERDTabControl;
            this.tabControl.Visible = true;

            this.objectExplorer.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(objectExplorer_NodeMouseDoubleClick);

            this.btnRelationship.DefaultItem = btnArrow00;
            this.btnRelationship.Image = btnArrow00.Image;

            buttonChosen(this.ERDbutton);
            disableConversions();
            SetWindowTheme(objectExplorer.Handle, "explorer", null);
            this.ORV.Enabled = true;

            image = this.splitContainer1.Panel2.BackgroundImage;
            this.hideTabControlIfNoTabPage();
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);

        private void objectExplorer_NodeMouseDoubleClick(object sender, MouseEventArgs e)
        {
             
                TreeNode node = objectExplorer.GetNodeAt(new Point(e.X, e.Y));
                if (node != null)
                {
                    if (node.Parent != null)
                    {
                        this.Hide();
                        ((Form1)parent).dataEntryControl.Show();
                         
                    }

                }
            
        }
 


        private void ActivateRelationshipTool(ToolStripMenuItem item, string toolname)
        {
            DeactivateTools();
            SetDefaultRelationshipButton(item);
            this.getDiagramControl().ActivateTool(toolname);
        }

        public void DeactivateTools()
        {
            foreach (ITool tool in getDiagramControl().controller.Tools)
                if (tool.IsActive)
                    getDiagramControl().controller.DeactivateTool(tool);
        }

        private void SetDefaultRelationshipButton(ToolStripMenuItem item)
        {
            btnRelationship.DefaultItem = item;
            btnRelationship.Image = item.Image;
        }


        private void setupTabcontrol(TabControl tab)
        {
            //tab.Controls.Add(this.tabDiagram);
            tab.Dock = System.Windows.Forms.DockStyle.Fill;
            tab.Location = new System.Drawing.Point(0, 0);
            tab.Name = "tabControl";
            //tab.SelectedIndex = 0;
            tab.Size = new System.Drawing.Size(520, 467);
            //tab.SelectedTab = tabDiagram;
            // tab.TabIndex = 1;
            tab.Visible = false;
        }

        
        private Win.DiagramControl getDiagramControl()
        {
            if (this.tabControl != null && this.tabControl.SelectedTab != null && this.tabControl.SelectedTab.Controls != null)
                return (Win.DiagramControl)(this.tabControl.SelectedTab.Controls[0]);
            else return new Win.DiagramControl();
        }



        private void showCurrentTabControl(TabControl tabcontrol)
        {
            ERDTabControl.Visible = false;
            DFDTabControl.Visible = false;
            CFDTabControl.Visible = false;
            CHTabControl.Visible = false;
            DMDTabControl.Visible = false;
            ORVTabControl.Visible = false;
            tabcontrol.Visible = true;
        }


        public void Activate(Win.DiagramControl dc)
        {
            // HACK: ensure that the singleton Selection refers to the correct diagram.
            // Selection should probably not be a singleton, but that would require
            // substantial changes to Netron.
            Selection.Clear();
            Selection.Controller = dc.Controller;
            Selection.Controller.View.ResetGhost();
            Selection.Controller.View.ResetTracker();
            Selection.Controller.View.Invalidate();
        }

        
        private void showDiagramList()
        {
            this.diagramListBox.SelectedItem = null;
            this.diagramListBox.Items.Clear();
         
            List<string> diagramnames = new List<string>();

            
            foreach (DDT.DDTDiagram diagram in DDT.DDTHelper.manager.project.diagrams)
            {
                if (diagram.type.Equals(this.currentType))
                {
                    diagramnames.Add(diagram.name);
                }
            }

            object[] a = diagramnames.ToArray();

            this.diagramListBox.Items.AddRange(a);

        }

        public void buttonClear()
        {
            this.ERDbutton.BackgroundImage = null;
            this.DFDButton.BackgroundImage = null;
            this.CFDButton.BackgroundImage = null;
            this.CHButton.BackgroundImage = null;
            this.DMDButton.BackgroundImage = null;
            this.ORVbutton.BackgroundImage = null;
        }


        public void buttonChosen(Button button)
        {
            buttonClear();
            this.diagramListBox.Enabled = true;
            disableConversions();
            newDiagramButton.Enabled = true;
            toolStripProgressBar1.Value = 0;
             button.BackgroundImage = global::Netron.NetronLight.Demo.Properties.Resources.CanvasBackground;
        }

        public void hideTabControlIfNoTabPage()
        {
            if (this.tabControl.TabCount < 1)
            {
                this.tabControl.Hide();
                this.splitContainer1.Panel2.BackgroundImage = image; 
            }
            else {
                this.splitContainer1.Panel2.BackgroundImage = null;
                this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            
            }
        
        }


        public void ORV_chosen()
        {
            currentType = DDT.DDT_Diagram_Type.ORV;
            this.tabControl = ORVTabControl;
            
            showCurrentTabControl(this.ORVTabControl);
            //manage ORVTabcontrol
            tabmgmt.TabControl = ORVTabControl;
            this.Activate(getDiagramControl());


            buttonChosen(this.ORVbutton);

            diagramListBox.Enabled = false;
            
           
            this.ProjectStatus.Text = "Object Relation View";
          
           

        }

        public void ERDbutton_Click(object sender, EventArgs e)
        {
             
            currentType = DDT.DDT_Diagram_Type.ERD;
            this.tabControl = ERDTabControl;
            showCurrentTabControl(this.ERDTabControl);
            //manage ERDTabcontrol
            tabmgmt.TabControl = ERDTabControl;
            this.Activate(getDiagramControl());


            buttonChosen(this.ERDbutton);


            this.ORV.Enabled = true;
           
            this.ProjectStatus.Text = "Entity Relational Diagram";
            hideTabControlIfNoTabPage();

            // tabmgmt.addTabPage("erd");

            // MessageBox.Show("TabControl: " + ((DDT.DDTTabControl)this.tabControl).diagramType);

        }

        private void CFDButton_Click(object sender, EventArgs e)
        {
           
            currentType = DDT.DDT_Diagram_Type.CFD;
            this.tabControl = CFDTabControl;
            showCurrentTabControl(this.CFDTabControl);
            tabmgmt.TabControl = CFDTabControl;
            this.Activate(getDiagramControl());
             
         //   tabmgmt.addTabPage("CFD");
            buttonChosen(this.CFDButton);

            this.CFDConversion.Enabled = true;
           
            this.ProjectStatus.Text = "Control Flow Diagram";
            hideTabControlIfNoTabPage();
        }

        private void DFDButton_Click(object sender, EventArgs e)
        {
           
            currentType = DDT.DDT_Diagram_Type.DFD;
            this.tabControl = DFDTabControl;
            showCurrentTabControl(this.DFDTabControl);
            tabmgmt.TabControl = DFDTabControl;
            this.Activate(getDiagramControl());
             
           // tabmgmt.addTabPage("DFD");

            buttonChosen(this.DFDButton);

            this.DFDConversion1.Enabled = true;
            this.DFDConversion2.Enabled = true;
           
            this.ProjectStatus.Text = "Data Flow Diagram";
            hideTabControlIfNoTabPage();
        }

        private void DMDButton_Click(object sender, EventArgs e)
        {
            
            currentType = DDT.DDT_Diagram_Type.DMD;
            this.tabControl = DMDTabControl;
            showCurrentTabControl(this.DMDTabControl);
            tabmgmt.TabControl = DMDTabControl;
            this.Activate(getDiagramControl());


            buttonChosen(this.DMDButton);
           // tabmgmt.addTabPage("DMD");
            this.ProjectStatus.Text = "Data Model Diagram";
            hideTabControlIfNoTabPage();
        }

        private void CHButton_Click(object sender, EventArgs e)
        {
          
            currentType = DDT.DDT_Diagram_Type.CH;
            this.tabControl = CHTabControl;
            showCurrentTabControl(this.CHTabControl);
            tabmgmt.TabControl = CHTabControl;
            this.Activate(getDiagramControl());
         
           // tabmgmt.addTabPage("CH");

            buttonChosen(this.CHButton);

            this.ProjectStatus.Text = "Class Hierarchy";
            hideTabControlIfNoTabPage();
        }


        private void ORVbutton_Click(object sender, EventArgs e)
        {
            currentType = DDT.DDT_Diagram_Type.ORV;
            this.tabControl = ORVTabControl;
            showCurrentTabControl(this.ORVTabControl);
            //manage ORVTabcontrol
            tabmgmt.TabControl = ORVTabControl;
            this.Activate(getDiagramControl());
            

            buttonChosen(this.ORVbutton);
            this.diagramListBox.Enabled = false;
            newDiagramButton.Enabled = false;

            this.ProjectStatus.Text = "Object Relation View";
            hideTabControlIfNoTabPage();
        }



        //tools 
        private void sendToBackButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().ActivateTool("SendToBack Tool");
        }

        private void sendToFrontButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().ActivateTool("SendToFront Tool");
        }

        private void groupButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().ActivateTool("Group Tool");
        }

        private void ungroupButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().ActivateTool("Ungroup Tool");
        }

        private void newDiagramButton_Click(object sender, EventArgs e)
        {
            bool dupFlag = false;
            SaveProjectForm diagramName = new SaveProjectForm();
            diagramName.ShowDialog(this);

            if (DiagramNameHelper.diagramName.Length.Equals(0)) return;

            foreach (TabPage tp in this.tabControl.TabPages)
            {
                if (tp.Name == DiagramNameHelper.diagramName)
                {
                    MessageBox.Show("Duplicate names, please use another name!", "WARNING: DUPLICATE NAMES");
                    DiagramNameHelper.diagramName = null;
                    dupFlag = true;
                    
                }
            }
            if (!dupFlag)
            {
                //create DDT.DDTDiagram
                DDT.DDTDiagram newDiagram = DDT.DDTHelper.manager.newDiagram(DiagramNameHelper.diagramName, this.currentType);

                this.tabmgmt.LoadDiagram(newDiagram);
                DiagramNameHelper.diagramName = null;

                this.tabControl.Show();
                hideTabControlIfNoTabPage();
                toolStripProgressBar1.Value = 0;

                this.getDiagramControl().OnHistoryChange += new EventHandler<HistoryChangeEventArgs>(DDT_OnHistoryChange);
            }
            else { newDiagramButton_Click(sender,e);}


        }


        private void DDT_OnHistoryChange(object sender, HistoryChangeEventArgs e)
        {
            /*
            if (e.UndoText.Length == 0)
            {
                this.undoButton.Enabled = false;
                this.undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.undoButton.Enabled = true;
                this.undoToolStripMenuItem.Enabled = true;
                this.undoButton.ToolTipText = "Undo " + e.UndoText;
                this.undoToolStripMenuItem.Text = "Undo " + e.UndoText;
            }

            if (e.RedoText.Length == 0)
            {
                this.redoButton.Enabled = false;
                this.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.redoButton.Enabled = true;
                this.redoToolStripMenuItem.Enabled = true;
                this.redoButton.ToolTipText = "Redo " + e.RedoText;
                this.redoToolStripMenuItem.Text = "Redo " + e.RedoText;
            }
             * */
            DDT.DDTHelper.UNSAVED();
            toolStripProgressBar1.Value = 0;
            ProjectStatus.Text = "EDITING"; 
        }


        // Below here is code to deal with the TreeView - objectExplorer
        public void refresh()
        {

            foreach (TreeNode n in objectExplorer.Nodes)  // Genres of objects
            {
                /*foreach (TreeNode nn in n.Nodes) // remove all subelements
                {
                    n.Nodes.Remove(nn);
                }*/
                n.Nodes.Clear();
            }

            // add new elements from project.
            foreach (DDT.DDTObject d in DDT.DDTHelper.manager.project.objects)
            {
                TreeNode newNode = new TreeNode(d.name);
                if (d.type == DDT.DDT_Obj_Type.COBJECT)
                {
                    newNode.Name = d.name;
                    newNode.Tag = d;
                    objectExplorer.Nodes[0].Nodes.Add(newNode);  // add the C Object.
                    
                }
                if (d.type == DDT.DDT_Obj_Type.ADT)
                {
                    newNode.Name = d.name;
                    newNode.Tag = d;
                    objectExplorer.Nodes[1].Nodes.Add(newNode);
                }

                if (d.type == DDT.DDT_Obj_Type.SMOBJECT)
                {
                    newNode.Name = d.name;
                    newNode.Tag = d;
                    objectExplorer.Nodes[2].Nodes.Add(newNode);
                }
            }
        }



        private void objectExplorer_Enter(object sender, EventArgs e)
        {
            refresh();
            toolStripProgressBar1.Value = 0;

        }

        private void objectExplorer_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode draggedNode = e.Item as TreeNode;
            if (draggedNode != null)
            {
                DDT.DDTObject obj = draggedNode.Tag as DDT.DDTObject;
                if (obj != null)
                {

                    // User needs to implement the DragEnter event.
                    //DoDragDrop(obj, DragDropEffects.Link | DragDropEffects.Copy);

                    Netron.NetronLight.IDDTObject temp = DDT.DDTProjectDrawingManagement.DDTObjectToCanvas(obj, new Point());
                    
                    Netron.NetronLight.DragHelp.DraggedShape = temp;

                    string objType = DDT.DDTProjectDrawingManagement.getObjectTypeString(obj);

                    this.getDiagramControl().DoDragDrop(objType, DragDropEffects.All);
                }
            }
        }




        private void btnArrow00_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow00, "NormalConnection Tool");
        }

        private void btnArrow01_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow01, "SingleArrowConnection Tool");
        }

        private void btnArrow02_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow02, "DoubleArrowConnection Tool");
        }

        private void btnArrow11_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow11, "OneToOneConnection Tool");
        }

        private void btnArrow12_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow12, "OneToManyConnection Tool");
        }

        private void btnArrow22_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrow22, "ManyToManyConnection Tool");
        }

        private void btnArrowGeneral_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(btnArrowGeneral, "DiamondArrowConnection Tool");
        }

        private void btnArrowControl_Click(object sender, EventArgs e)
        {

            this.ActivateRelationshipTool(btnArrowControl, "WideArrowConnection Tool");
        }

        private void dashedArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActivateRelationshipTool(dashedArrowToolStripMenuItem, "DashedArrowConnection Tool");
        }

        private void ListViewUtilities_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.ListViewUtilities.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                 IShape shape=null;
                  foreach(string shapeType in Enum.GetNames(typeof(ShapeTypes)))
                {
                    if(shapeType.ToString().ToLower() == item.Tag.ToString().ToLower())
                    {
                        shape = ShapeFactory.GetShape(shapeType); 
                        break;
                    }
                }
                  ((Netron.NetronLight.IDDTObject)shape).ID = DDT.staticId.getid();
                  Netron.NetronLight.DragHelp.DraggedShape = (Netron.NetronLight.IDDTObject)shape;
                

                this.getDiagramControl().DoDragDrop(item.Tag.ToString(), DragDropEffects.All);
            }

        }

 


        //save diagrams in 'tc'
        private void SaveDiagramsInTabControl(DDT.DDTTabControl tc)
        {
            DDT.DDTTabControl orignialTc = tabmgmt.TabControl;

            tabmgmt.TabControl = tc;

            tabmgmt.SaveDiagrams();

            tabmgmt.TabControl = orignialTc;
        }
        


        public void saveButton_Click(object sender, EventArgs e)
        {
            if (DDT.DDTHelper.Saved) return;
            this.SaveDiagramsInTabControl(ERDTabControl);
            this.SaveDiagramsInTabControl(CHTabControl);
            this.SaveDiagramsInTabControl(DFDTabControl);
            this.SaveDiagramsInTabControl(CFDTabControl);
            this.SaveDiagramsInTabControl(DMDTabControl);
            //this.SaveDiagramsInTabControl(ORVTabControl);
            DDT.DDTHelper.SAVED();

            //show progress Bar
            toolStripProgressBar1.Visible = true;
            for(int i=0;i<=10;i++)
            toolStripProgressBar1.Value = 10*i;

          
            this.ProjectStatus.Text = "PROJECT SAVED";

            if (DDT.DDTHelper.NewProj)
            {

                SaveFileDialog

                 browseFile = new SaveFileDialog();

                browseFile.Filter =

                "XML Files (*.xml)|*.xml";

                browseFile.Title =

                "Browse XML file";


                if (browseFile.ShowDialog() == DialogResult.Cancel)


                    return;


                try
                {

                    DDT.XML.serialize(DDT.DDTHelper.manager.project, browseFile.FileName);
                    //menu_panel.Visible = false;
                    DDT.DDTHelper.NewProj = false;
                    DDT.DDTHelper.savedPath = browseFile.FileName;
                }


                catch (Exception)
                {


                    MessageBox.Show("Error opening file", "File Error",


                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }


            }
            else {

                try
                {

                    DDT.XML.serialize(DDT.DDTHelper.manager.project, DDT.DDTHelper.savedPath);
                    //menu_panel.Visible = false;
                    DDT.DDTHelper.NewProj = false;

                }


                catch (Exception)
                {


                    MessageBox.Show("Error opening file", "File Error",


                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            
            }
             
        }



        private void LoadDiagramsInTabControl(DDT.DDTTabControl tc)
        {
            tabmgmt.TabControl = tc;

            tabmgmt.LoadDiagrams();

            if (tc.TabCount != 0) tc.Show();
        }

 

        private void undoButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            this.getDiagramControl().Redo();
        }

        public void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to load diagram without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            if (YorN)
            {

                OpenFileDialog

                 browseFile = new OpenFileDialog();

                browseFile.Filter =

                "XML Files (*.xml)|*.xml";

                browseFile.Title =

                "Browse XML file";


                if (browseFile.ShowDialog() == DialogResult.Cancel)


                    return;


                try
                {

                    DDT.DDTProject d = DDT.XML.deserialize(browseFile.FileName);
                    DDT.DDTHelper.manager.project = d;

                    loadDiagram();
                    if (this.Visible)
                    {
                        ERDbutton_Click(sender, e);
                for (int i = 0; i <= 10; i++)
                    toolStripProgressBar1.Value = 10 * i;

                this.ProjectStatus.Text = "PROJECT LOADED";
                    }
                }


                catch (Exception)
                {


                    MessageBox.Show("Error opening file", "File Error",


                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        public void loadDiagram()
        {
            DDT.DDTTabControl orignialTc = tabmgmt.TabControl;
            this.LoadDiagramsInTabControl(ERDTabControl);
            this.LoadDiagramsInTabControl(CHTabControl);
            this.LoadDiagramsInTabControl(DFDTabControl);
            this.LoadDiagramsInTabControl(CFDTabControl);
            this.LoadDiagramsInTabControl(DMDTabControl);
            //this.LoadDiagramsInTabControl(ORVTabControl);
            tabmgmt.TabControl = orignialTc;
            DDT.DDTHelper.SAVED();
            Activate(getDiagramControl());
        }
 

        private void disableConversions()
        {
            this.DFDConversion1.Enabled = false;
            this.DFDConversion2.Enabled = false;
            this.CFDConversion.Enabled = false;
            this.ORV.Enabled = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Activate(getDiagramControl());
            getTabPage().Refresh();
        }
        private TabPage getTabPage()
        {
            return (TabPage)(this.tabControl.SelectedTab);
        }

        private void CFDConversion_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to process it without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            if (!YorN)
            { return; }

            toolStripProgressBar1.Visible = true;
            for (int i = 0; i <= 5; i++)
                toolStripProgressBar1.Value = 20 * i;
            // TODO - Bryan add logic here to retrieve the CFD
            int diagramId = this.getDiagramControl().diagramID;

            //the current diagram 
            DDT.DDTDiagram CFDDiagram = DDT.DDTHelper.manager.getDDTDiagramById(diagramId);

            DDT.CFDConverter.displayTable(CFDDiagram);
        }


        // Transform based conversion.
        private void DFDConversion1_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to process it without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            if (!YorN)
            { return; }

            int processingObjectId = 0;
            int outputObjectId = 0;
            int diagramId = this.getDiagramControl().diagramID;
            //the current diagram 
            DDT.DDTDiagram currentDFDDiagram = DDT.DDTHelper.manager.getDDTDiagramById(diagramId);


            DDT.ConversionHelper.objectIdList=new List<int>();

            foreach (DDT.DDTObjectReference objr in currentDFDDiagram.ObjRefList)
            {
                DDT.ConversionHelper.objectIdList.Add(objr.ID);            
            }


            Netron.NetronLight.Demo.TransactionDrivenFrom tdf = new TransactionDrivenFrom();
            tdf.ShowDialog(this);

            if (DDT.ConversionHelper.processingObjectId <= 0 || DDT.ConversionHelper.OutputObjectId <= 0)
                return;
            else
            {
                processingObjectId = DDT.ConversionHelper.processingObjectId;
                outputObjectId = DDT.ConversionHelper.OutputObjectId;
            }


            toolStripProgressBar1.Visible = true;
            for (int i = 0; i <= 4; i++)
                toolStripProgressBar1.Value = 25 * i;


 

            // TODO - Bryan add logic here to retrieve the Data Flow Diagram.

            // TODO - replace null with a DDTdiagram.

            DDT.TransformDFDConverter.displayChart(currentDFDDiagram, processingObjectId, outputObjectId);
        }

        private void DFDConversion2_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to process it without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            if (!YorN)
            { return; }

            toolStripProgressBar1.Visible = true;
            for (int i = 0; i <= 4; i++)
                toolStripProgressBar1.Value = 25 * i;


            int diagramId = this.getDiagramControl().diagramID;

            //the current diagram 
            DDT.DDTDiagram DFDDiagram = DDT.DDTHelper.manager.getDDTDiagramById(diagramId);
            // TODO - Bryan add logic here to retrieve the Data Flow Diagram.

            // TODO - replace null with a DDTdiagram.
            DDT.TransactionDFDConverter.displayChart(DFDDiagram);


        }

        private void ListViewUtilities_Enter(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 0;
        }

 

        public void helpButton_Click(object sender, EventArgs e)
        {
            //string document = "C:\\Users\\bryan\\Desktop\\DDT_GUI\\WinForm.Demo\\bin\\Debug\\UserManual.docx";
            string path = Path.Combine(Environment.CurrentDirectory, @"UserManual.docx");
            try 
            {
                Word.Application Word_App = null;
                Word_App = new Word.Application();
                
                Word_App.Visible = true;
                Word_App.Documents.Open(path);
            }
            catch (Exception exc) 
            {
                MessageBox.Show("Can't open Word application (" + exc.ToString() + ")"); 
            }
        }

        private void ORV_Click(object sender, EventArgs e)
        {

            if (Selection.SelectedItems.Equals(null) || Selection.SelectedItems.Count.Equals(0))
            {
                MessageBox.Show("Please Select an C-Object, ADT-Object or SM-Object!", "NOTE");
                return;
            }

            IDDTDiagramEntity chosen = (IDDTDiagramEntity)Selection.SelectedItems[0];
            
            if (chosen == null || !chosen.GetType().IsSubclassOf(typeof(Netron.NetronLight.DDTObject)))
            {
                MessageBox.Show("Please Select an C-Object, ADT-Object or SM-Object!", "NOTE");
                return;
            }
            int objId = ((Netron.NetronLight.DDTObject)chosen).ID;


            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Make Sure You Saved Before Generating ORV?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            if (!YorN)
            { return; }


                List<DDT.DDTDiagram> ORVList = DDT.DDTHelper.manager.getORV(objId);

                if (ORVList==null||ORVList.Count <= 0) {return; }
                this.ORV_chosen();
                foreach (DDT.DDTDiagram dia in ORVList)
                {

                    DDT.DDTHelper.manager.project.diagrams.Add(dia);

                }

                this.tabmgmt.TabControl = ORVTabControl;
                this.tabmgmt.LoadDiagramList(ORVList);
                this.ProjectStatus.Text = "Object Relation View";
                toolStripProgressBar1.Visible = true;
                for (int i = 0; i <= 2; i++)
                    toolStripProgressBar1.Value = 50 * i;
                
        }

        private void diagramListBox_Enter(object sender, EventArgs e)
        {
            this.showDiagramList();
        }

        private void diagramListBox_TextChanged(object sender, EventArgs e)
        {
            if (this.diagramListBox.Text != null && this.diagramListBox.Text.Length != 0)
            {
                this.tabmgmt.showDiagram(this.diagramListBox.Text);
                hideTabControlIfNoTabPage();
            }
        }

 

        private void GraphManipulationUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.refresh();
            
            }
        }


        public void ClearDiagrams()
        {
            ClearDiagram(this.ERDTabControl);
            ClearDiagram(this.DFDTabControl);
            ClearDiagram(this.CFDTabControl);
            ClearDiagram(this.CHTabControl);
            ClearDiagram(this.DMDTabControl);
            ClearDiagram(this.ORVTabControl);

        }

 
        private void ClearDiagram(DDT.DDTTabControl tc)
        {
            this.tabControl = tc;
            this.tabmgmt.TabControl = tc;
            this.tabmgmt.removeAllPages();
            this.tabControl.Hide();
            hideTabControlIfNoTabPage();
        }

        private void openDiagramButton_Click(object sender, EventArgs e)
        {
            bool YorN = true;
            if (!DDT.DDTHelper.Saved)
            {
                YorN = MessageBox.Show("Are you sure you want to load diagram without saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            if (YorN)
            {
                loadDiagram();

                for (int i = 0; i <= 10; i++)
                    toolStripProgressBar1.Value = 10 * i;

                this.ProjectStatus.Text = "PROJECT LOADED";
            }
        }

 
    }
}
