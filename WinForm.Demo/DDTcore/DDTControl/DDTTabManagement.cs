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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Netron.NetronLight;
using Netron.NetronLight.Win;
using System.Drawing;

namespace DDT
{ 
    class DDTTabManagement 
    {
        //Notice: remember to assign this value when change tabcontrols
        private DDTTabControl tabControl;
        public Netron.NetronLight.Demo.GraphManipulationUserControl parent;
        #region Constructor
        public DDTTabManagement() 
        {
        }
 
        
        public DDTTabManagement(DDTTabControl tc) 
        {
            this.tabControl = tc;
            this.tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
             
        }

        #endregion
        public DDTTabControl TabControl
        {
            get { return tabControl; }
            set 
            {
                this.tabControl = value;
                //trigger event when select a tabpage
                this.tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
            }
        }

       

        #region method

        /// <summary>
        // add a canvas on tabcontrol 
        /// </summary>
        /// <param name="tabName"></param>
        public void addTabPage(string tabName)
        {
            DiagramControl dc = new DiagramControl();
            dc.AllowDrop = true;
            dc.BackColor = getTabColor();
            dc.BackgroundType = Netron.NetronLight.CanvasBackgroundTypes.FlatColor;
            dc.Dock = System.Windows.Forms.DockStyle.Fill;
            dc.EnableAddConnection = true;
            dc.Location = new System.Drawing.Point(3, 3);
            dc.Name = tabName;
            dc.Size = new System.Drawing.Size(1506, 1435);
            dc.TabIndex = 0;
            dc.AutoScroll = false;
            
            dc.Text = tabName;
           

            //dc.OnShowSelectionProperties += new System.EventHandler<Netron.NetronLight.SelectionEventArgs>(this.diagramControl1_OnShowSelectionProperties);
            //dc.OnEntityAdded += new System.EventHandler<Netron.NetronLight.EntityEventArgs>(this.diagramControl1_OnEntityAdded);
            
             dc.controller.OnShowContextMenu += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.controller_OnShowContextMenu);
             dc.controller.OnShowContextMenu2 += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.controller_OnShowContextMenu2);
             
            dc.controller.OnHistoryChange += new EventHandler<HistoryChangeEventArgs>(controller_OnHistoryChange);

            System.Windows.Forms.TabPage NewTab = new TabPage();
            this.tabControl.Controls.Add(NewTab);
            NewTab.Controls.Add(dc);
             
            NewTab.Location = new System.Drawing.Point(4, 22);
            NewTab.Name = tabName;
            NewTab.Padding = new System.Windows.Forms.Padding(3);
            NewTab.Size = new System.Drawing.Size(1512, 1441);

            NewTab.AutoScroll = false;
            NewTab.AutoScrollMinSize = new System.Drawing.Size(2500, 2500);

            NewTab.BorderStyle = BorderStyle.FixedSingle;
            NewTab.TabIndex = 0;
            NewTab.Text = tabName;
            NewTab.UseVisualStyleBackColor = true;

            //save NewTab
            this.tabControl.savePage(NewTab);

            //select NewTab
            this.tabControl.SelectedTab = NewTab;
        
        
        }

        public void addTabPage(DDT.DDTDiagram diagram)
        {
            DiagramControl dc = new DiagramControl();

            //syncronize Diagram and DiagramControl
            dc.diagramID = diagram.ID;
            dc.AllowDrop = true;
            dc.BackColor = getTabColor();
            dc.BackgroundType = Netron.NetronLight.CanvasBackgroundTypes.FlatColor;
            dc.Dock = System.Windows.Forms.DockStyle.Fill;
            dc.EnableAddConnection = true;
            dc.Location = new System.Drawing.Point(3, 3);
            dc.Name = diagram.name;
            //dc.Size = new System.Drawing.Size(506, 435);
            dc.Size = new System.Drawing.Size(1506, 1435);
            dc.AutoScroll = false;
            dc.TabIndex = 0;
            dc.Text = diagram.name;


            //dc.OnShowSelectionProperties += new System.EventHandler<Netron.NetronLight.SelectionEventArgs>(this.diagramControl1_OnShowSelectionProperties);
            //dc.OnEntityAdded += new System.EventHandler<Netron.NetronLight.EntityEventArgs>(this.diagramControl1_OnEntityAdded);

            dc.controller.OnShowContextMenu += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.controller_OnShowContextMenu);
            dc.controller.OnShowContextMenu2 += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.controller_OnShowContextMenu2);
             
              dc.controller.OnHistoryChange+=new EventHandler<HistoryChangeEventArgs>(controller_OnHistoryChange);

            System.Windows.Forms.TabPage NewTab = new TabPage();
            this.tabControl.Controls.Add(NewTab);
            NewTab.Controls.Add(dc);
            NewTab.Location = new System.Drawing.Point(4, 22);
            NewTab.Name = diagram.name;
            NewTab.Padding = new System.Windows.Forms.Padding(3);
            //NewTab.Size = new System.Drawing.Size(512, 441);
            NewTab.Size = new System.Drawing.Size(1512, 1441);

            NewTab.BorderStyle = BorderStyle.FixedSingle;
            NewTab.AutoScroll = false;
            NewTab.AutoScrollMinSize = new System.Drawing.Size(2500, 2500);


            NewTab.TabIndex = 0;
            NewTab.Text = diagram.name;
            NewTab.UseVisualStyleBackColor = true;

            //save NewTab
            this.tabControl.savePage(NewTab);

            //select NewTab
            this.tabControl.SelectedTab = NewTab;

            DDT.DDTHelper.UNSAVED(); 

        }







        //getDiagramControls in a tabcontrol
        public List<DiagramControl> getDiagramControls() 
        {
            List<DiagramControl> list = new List<DiagramControl>();
            foreach (TabPage tp in this.tabControl.TabPages)
            {  
                 if (tp.Controls!=null&&tp.Controls.Count>0)
                {
                    list.Add((DiagramControl)tp.Controls[0]);
                    //MessageBox.Show(((DiagramControl)tp.Controls[0]).Text);
                }
            }
            return list;
        }


        private Color getTabColor()
        {
            switch (tabControl.diagramType)
            { 
                case DDT_Diagram_Type.ERD:
                    return Color.White;
                case DDT_Diagram_Type.CFD:
                    return Color.LightYellow;
                case DDT_Diagram_Type.DFD:
                    return Color.WhiteSmoke;
                case DDT_Diagram_Type.CH:
                    return Color.Azure;
                case DDT_Diagram_Type.DMD:
                    return Color.Linen;
                default: return Color.White;
            }
        }




        public void Activate(DiagramControl dc)
        {
            Selection.Clear();
            Selection.Controller = dc.Controller;
            Selection.Controller.View.ResetGhost();
            Selection.Controller.View.ResetTracker();
            Selection.Controller.View.Invalidate();
        }


        public DiagramControl getDiagramControl()
        {
            return (DiagramControl)(this.tabControl.SelectedTab.Controls[0]);
        }

        public void showDiagram(string diagramName)
        {
            foreach (TabPage tp in this.tabControl.TabPages)
            {
                //if diagram is in current tabcontrol
                if (((DiagramControl)(tp.Controls[0])).Text == diagramName)
                {
                    this.tabControl.SelectedTab = tp;
                    return;
                }
                          
            }
            //if not exist
            foreach (DDTDiagram diagram in DDTHelper.manager.project.diagrams)
            {
                if (diagramName == diagram.name)
                {
                    this.tabControl.Show();
                    this.LoadDiagram(diagram);
                    return;
                }            
            }
            //MessageBox.Show("Invalid idgram to display", "WARNING");
        
        }





        #endregion

        #region event method

        /*
        private void diagramControl1_OnShowSelectionProperties(object sender, SelectionEventArgs e)
        {

            this.propertyGrid.SelectedObjects = e.SelectedObjects;
        }

        */
        void controller_OnShowContextMenu2(object sender, MouseEventArgs e)
        {
           /*
            if (Selection.SelectedItems.Count != 0)
            {
                IDDTDiagramEntity IDDT = (IDDTDiagramEntity)Selection.SelectedItems[0];
            }
            
            if (Selection.SelectedItems != null && Selection.SelectedItems.Count == 1)
            {


                OnProperties(sender, e);
                
                
             
            }
        */
        }

        void controller_OnShowContextMenu(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.ContextMenuStrip menu = new ContextMenuStrip();

            if (Selection.SelectedItems.Count!= 0)
            {
                IDDTDiagramEntity IDDT = (IDDTDiagramEntity)Selection.SelectedItems[0];
            } 
            menu.Items.Clear();
       
         
            if (Selection.SelectedItems != null && Selection.SelectedItems.Count == 1)
            {
                menu.BackColor = System.Drawing.Color.LightYellow;
                menu.Name = "DDTDiagramEntityMenu";
                menu.Opacity = 0.9D;
                menu.Size = new System.Drawing.Size(61, 4);

                /*
                if(Selection.SelectedItems[0].GetType().IsSubclassOf(typeof(Netron.NetronLight.DDTObject))
                {
                  ToolStripItem mnuORV = new ToolStripMenuItem("GenerateORV", null, new EventHandler(OnORV));
                  menu.Items.Add(mnuORV);
                
                }
                */
                ToolStripItem mnuProps = new ToolStripMenuItem("Edit", null, new EventHandler(OnProperties));
                menu.Items.Add(mnuProps);

                ToolStripItem mnuDelete = new ToolStripMenuItem("Remove", null, new EventHandler(OnDelete));
                menu.Items.Add(mnuDelete);

            }
            else// if (Selection.SelectedItems != null && Selection.SelectedItems.Count == 1)
            {
                
                menu.BackColor = System.Drawing.Color.LightSteelBlue;
                menu.Name = "DiagramMenu";
                menu.Opacity = 0.9D;
                menu.Size = new System.Drawing.Size(61, 4);


             
                ToolStripItem mnRename = new ToolStripMenuItem("Rename Diagram", null, new EventHandler(OnRename));
                menu.Items.Add(mnRename);
                


                ToolStripItem mnClean = new ToolStripMenuItem("Clean", null, new EventHandler(OnClean));
                menu.Items.Add(mnClean);

                /*
                ToolStripItem mnSave = new ToolStripMenuItem("Save", null, new EventHandler(OnSave));
                menu.Items.Add(mnSave);
                */

                ToolStripItem mnClose = new ToolStripMenuItem("Close", null, new EventHandler(OnClose));
                menu.Items.Add(mnClose);

                ToolStripItem mnRemove = new ToolStripMenuItem("Remove Diagram", null, new EventHandler(OnRemove));
                menu.Items.Add(mnRemove);
            }
            

            if (menu.Items.Count > 0)
                //diagramcontrol1 needs change
                menu.Show(getDiagramControl(), e.Location);
        }

        private void OnProperties(object sender, EventArgs e)
        {
            IDDTDiagramEntity IDDT = (IDDTDiagramEntity)Selection.SelectedItems[0];
 
                if (Selection.SelectedItems[0].GetType().Equals(typeof(Netron.NetronLight.DDTConnection)))
                {
                    Netron.NetronLight.Demo.NetronDDTHelper.setDDTConnection((Netron.NetronLight.DDTConnection)IDDT);
                        if (this.tabControl.diagramType.Equals(DDT_Diagram_Type.CFD))
                        {
                            Netron.NetronLight.Demo.CFDEventAndAction EventAndActionWindow = new Netron.NetronLight.Demo.CFDEventAndAction();
                            EventAndActionWindow.ShowDialog(this.tabControl.Parent);
                        }
                        else
                        {
                        Netron.NetronLight.Demo.EditDDTConnection editWindow = new Netron.NetronLight.Demo.EditDDTConnection();
                        editWindow.ShowDialog(this.tabControl.Parent);
                        }
                }
                else if (Selection.SelectedItems[0].GetType().IsSubclassOf(typeof(Netron.NetronLight.SmallObject)))
                {
                    Netron.NetronLight.Demo.NetronDDTHelper.setIDDTObject((Netron.NetronLight.IDDTObject)IDDT);
                    Netron.NetronLight.Demo.EditOtherObjects editWindow = new Netron.NetronLight.Demo.EditOtherObjects();
                    editWindow.ShowDialog(this.tabControl.Parent);

                    Activate(getDiagramControl());
                    ((TabPage)(this.tabControl.SelectedTab)).Refresh();
                }
                    //edit Objects in the Explorer
                else if (Selection.SelectedItems[0].GetType().IsSubclassOf(typeof(Netron.NetronLight.DDTObject)))
                {
                    Netron.NetronLight.Demo.NetronDDTHelper.setIDDTObject((Netron.NetronLight.IDDTObject)IDDT);
                    Netron.NetronLight.Demo.EditOtherObjects editWindow = new Netron.NetronLight.Demo.EditOtherObjects();
                    editWindow.ShowDialog(this.tabControl.Parent);

                    int objId = ((Netron.NetronLight.DDTObject)Selection.SelectedItems[0]).ID;

                    DDT.DDTObject obj = DDT.DDTProjectDrawingManagement.getDDTObjectById(objId, DDT.DDTHelper.manager.project.objects);

                    obj.name = ((Netron.NetronLight.DDTObject)Selection.SelectedItems[0]).Text;

                
                    //update mapped object name
                    int mappedId = DDT.DDTHelper.manager.project.getCObjectFromDDTObjectID(objId);


                    DDT.DDTHelper.manager.renameMappedObjectById(mappedId, obj.name);

                    

                    Activate(getDiagramControl());
                    ((TabPage)(this.tabControl.SelectedTab)).Refresh();
                    parent.refresh();
                }
              

        }

 

        private void OnDelete(object sender, EventArgs e)
        {
            /*
            IDDTDiagramEntity chosenObj = (IDDTDiagramEntity)Selection.SelectedItems[0];

            if (chosenObj.GetType().IsSubclassOf(typeof(Netron.NetronLight.SmallObject)))
            {
                MessageBox.Show("type " + chosenObj.GetType().ToString());
                int objId = ((Netron.NetronLight.SmallObject)chosenObj).ID;
                if (DDT.DDTHelper.manager.DDTObjectFound(objId))
                {
                    DDT.DDTHelper.manager.removeDDTObjectById(objId);
                }
            }
            else if (chosenObj.GetType().Equals(typeof(Netron.NetronLight.DDTConnection)))
            {
                MessageBox.Show("type " + chosenObj.GetType().ToString());

                int relId = ((Netron.NetronLight.DDTConnection)chosenObj).ID;
                if (DDT.DDTHelper.manager.DDTRelationFound(relId))
                {
                    DDT.DDTHelper.manager.removeDDTRelationById(relId);
                }
            }

            */
            this.getDiagramControl().controller.Model.Remove((IDDTDiagramEntity)Selection.SelectedItems[0]);
            Selection.Clear();
     
            this.getDiagramControl().controller.View.ShowTracker();
            DDT.DDTHelper.UNSAVED(); 
        }


        private void OnRename(object sender, EventArgs e)
        {

            Netron.NetronLight.Demo.SaveProjectForm diagramName = new Netron.NetronLight.Demo.SaveProjectForm();
            diagramName.ShowDialog(this.tabControl);

            if (Netron.NetronLight.Demo.DiagramNameHelper.diagramName.Length != 0)
            { 
                this.tabControl.SelectedTab.Text = Netron.NetronLight.Demo.DiagramNameHelper.diagramName;

                //change the project diagram name
                DDT.DDTHelper.manager.getDDTDiagramById(getDiagramControl().diagramID).name = Netron.NetronLight.Demo.DiagramNameHelper.diagramName;
             
                
            }

            Netron.NetronLight.Demo.DiagramNameHelper.diagramName = null;

            DDT.DDTHelper.UNSAVED(); 


        }

        private void OnClean(object sender, EventArgs e)
        {
           // MessageBox.Show("OnClean!!!");
           ((Netron.NetronLight.Win.DiagramControl)(this.tabControl.SelectedTab.Controls[0])).controller.Model.Clear();
           ((TabPage)(this.tabControl.SelectedTab)).Refresh();
           DDT.DDTHelper.UNSAVED(); 
        }

        private void OnClose(object sender, EventArgs e)
        {
            int current = this.tabControl.SelectedIndex;
            if (!DDT.DDTHelper.Saved)
            {
                if (MessageBox.Show("Are you sure you want to close without Saving?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.TabControl.TabPages.Remove(this.tabControl.SelectedTab);
                    this.tabControl.SelectedIndex = current - 1;
                    if (this.tabControl.TabCount < 1)
                        this.tabControl.Hide();
                }
            }
            else
            {
                this.TabControl.TabPages.Remove(this.tabControl.SelectedTab);
                this.tabControl.SelectedIndex = current - 1;
                if (this.tabControl.TabCount < 1)
                    this.tabControl.Hide();
            }

            this.parent.hideTabControlIfNoTabPage();
            /*
            foreach (TabPage i in this.tabControl.CreatedTabpages)
                MessageBox.Show(i.Name);
             */
        }
        private void OnSave(object sender, EventArgs e)
        {
            MessageBox.Show("OnSave!!!");

        }

        private void OnRemove(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this diagram from the project?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DDTDiagram diagramToRemove = DDT.DDTHelper.manager.getDDTDiagramById(getDiagramControl().diagramID);

                DDT.DDTHelper.manager.removeDiagram(diagramToRemove);

                int current = this.tabControl.SelectedIndex;
                this.tabControl.removePage(this.tabControl.SelectedTab);
                this.TabControl.TabPages.Remove(this.tabControl.SelectedTab);
                this.tabControl.SelectedIndex = current - 1;

                if (this.tabControl.TabCount < 1)
                    this.tabControl.Hide();

                this.parent.hideTabControlIfNoTabPage();
            }
            /*
            foreach (TabPage i in this.tabControl.CreatedTabpages)
                MessageBox.Show(i.Name);
             */
        }


        public void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // HACK: Netron can only deal with one diagram viewer at a time,
            // so we have to activate the viewer when changing to a diagram tab
            if (this.tabControl.SelectedTab != null)
                Activate(getDiagramControl());

        }
        #endregion


        private void controller_OnHistoryChange(object sender, HistoryChangeEventArgs e)
        {
            DDT.DDTHelper.UNSAVED(); 
        }

        /*   put this in the mainform code.
        
        public void RaiseOnHistoricChange()
        {

            this.TabManager.getDiagramControl().OnHistoryChange += new System.EventHandler<Netron.NetronLight.HistoryChangeEventArgs>(this.diagramControl_OnHistoryChange);
        
        }


        private void controller_OnHistoryChange(object sender, HistoryChangeEventArgs e)
        {
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
        }
       */






        //save diagrams in current tabControl
        public void SaveDiagrams()
        {
            //get diagramControls in current TabControl
            List<DiagramControl> DiagramControlList = getDiagramControls();
            DDT.DDTDiagram diagramToSave;


            //save each diagram in each diagramControl
            foreach (DiagramControl dc in DiagramControlList)
            {
                //get the diagram corresponding to the diagram control
                diagramToSave = DDTHelper.manager.getDDTDiagramById(dc.diagramID);
                if (diagramToSave.Equals(null))
                {
                    MessageBox.Show("Invalid diagram Control ID from: "+dc.Name, "WARNING");
                    continue; 
                }
                //save diagram to the project
                DDTHelper.manager.saveDiagram(dc, diagramToSave);
            }
        }

        //create a new tabpage, load the diagram, each Diagram is corresponding to a diagramControl

        public void LoadDiagram(DDT.DDTDiagram diagram)
        {
            this.addTabPage(diagram);


            DDTHelper.manager.LoadDiagram(this.getDiagramControl(), diagram);
        }

        public void LoadDiagramList(List<DDT.DDTDiagram> list)
        {
            foreach (DDT.DDTDiagram dia in list)
            {
                this.LoadDiagram(dia);
            }
        }

        //load diagrams in current tabControl
        public void LoadDiagrams()
        {   
            //clear all tabpages
            this.tabControl.TabPages.Clear();

            List<DDTDiagram> diagramsToLoad = DDTHelper.manager.project.diagrams;

            foreach (DDTDiagram diagram in diagramsToLoad)
            {
                if (diagram.type == this.tabControl.diagramType)
                {
                    this.LoadDiagram(diagram);
                }           
            }

        }
        public void removeAllPages()
        {
            foreach (TabPage tp in this.TabControl.TabPages)
            {
                this.TabControl.TabPages.Remove(tp);
            }
        }

        
    }
}
