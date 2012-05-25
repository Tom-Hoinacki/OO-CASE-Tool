namespace Netron.NetronLight.Demo
{
    public partial class GraphManipulationUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphManipulationUserControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("C Objects");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ADT Objects");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("SM Objects");
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("UTILITIES", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "STORE"}, 6, System.Drawing.SystemColors.MenuHighlight, System.Drawing.Color.WhiteSmoke, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "TRANSFORM"}, 1, System.Drawing.SystemColors.MenuHighlight, System.Drawing.Color.WhiteSmoke, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "CUSTOMIZED"}, 3, System.Drawing.SystemColors.MenuHighlight, System.Drawing.Color.WhiteSmoke, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "TERMINATOR"}, 5, System.Drawing.SystemColors.MenuHighlight, System.Drawing.Color.WhiteSmoke, null);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.mainStrip = new System.Windows.Forms.ToolStrip();
            this.newDiagramButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.LoadDiagrams = new System.Windows.Forms.ToolStripButton();
            this.openDiagramButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cutButton = new System.Windows.Forms.ToolStripButton();
            this.copyButton = new System.Windows.Forms.ToolStripButton();
            this.pasteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.actionsStrip = new System.Windows.Forms.ToolStrip();
            this.sendToBackButton = new System.Windows.Forms.ToolStripButton();
            this.sendToFrontButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.groupButton = new System.Windows.Forms.ToolStripButton();
            this.ungroupButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CFDConversion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.DFDConversion1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.DFDConversion2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.ORV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnRelationship = new System.Windows.Forms.ToolStripSplitButton();
            this.btnArrow00 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrow01 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrow02 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrow11 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrow12 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrow22 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrowGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArrowControl = new System.Windows.Forms.ToolStripMenuItem();
            this.dashedArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.middlesplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.objectExplorer = new System.Windows.Forms.TreeView();
            this.ListViewUtilities = new System.Windows.Forms.ListView();
            this.shapesImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerright = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.ORVbutton = new System.Windows.Forms.Button();
            this.CHButton = new System.Windows.Forms.Button();
            this.ERDbutton = new System.Windows.Forms.Button();
            this.DFDButton = new System.Windows.Forms.Button();
            this.DMDButton = new System.Windows.Forms.Button();
            this.CFDButton = new System.Windows.Forms.Button();
            this.diagramListBox = new System.Windows.Forms.ComboBox();
            this.LableDiagramList = new System.Windows.Forms.Label();
            this.toolStripProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProjectStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.mainStrip.SuspendLayout();
            this.actionsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.middlesplitContainer)).BeginInit();
            this.middlesplitContainer.Panel1.SuspendLayout();
            this.middlesplitContainer.Panel2.SuspendLayout();
            this.middlesplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerright)).BeginInit();
            this.splitContainerright.Panel1.SuspendLayout();
            this.splitContainerright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(968, 637);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.mainStrip);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer3.Panel2.Controls.Add(this.actionsStrip);
            this.splitContainer3.Size = new System.Drawing.Size(968, 58);
            this.splitContainer3.SplitterDistance = 26;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // mainStrip
            // 
            this.mainStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDiagramButton,
            this.saveButton,
            this.LoadDiagrams,
            this.openDiagramButton,
            this.toolStripSeparator5,
            this.RefreshButton,
            this.toolStripSeparator,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.toolStripSeparator3,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator1,
            this.helpButton,
            this.toolStripSeparator2});
            this.mainStrip.Location = new System.Drawing.Point(0, 1);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Padding = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.mainStrip.Size = new System.Drawing.Size(966, 23);
            this.mainStrip.TabIndex = 6;
            // 
            // newDiagramButton
            // 
            this.newDiagramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newDiagramButton.Image = ((System.Drawing.Image)(resources.GetObject("newDiagramButton.Image")));
            this.newDiagramButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newDiagramButton.Name = "newDiagramButton";
            this.newDiagramButton.Size = new System.Drawing.Size(23, 19);
            this.newDiagramButton.Text = "New diagram";
            this.newDiagramButton.Click += new System.EventHandler(this.newDiagramButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 19);
            this.saveButton.Text = "Save diagram";
            this.saveButton.ToolTipText = "Save Project";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // LoadDiagrams
            // 
            this.LoadDiagrams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadDiagrams.Image = global::Netron.NetronLight.Demo.Properties.Resources.openfolderHS;
            this.LoadDiagrams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadDiagrams.Name = "LoadDiagrams";
            this.LoadDiagrams.Size = new System.Drawing.Size(23, 19);
            this.LoadDiagrams.Text = "Open Diagrams";
            this.LoadDiagrams.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // openDiagramButton
            // 
            this.openDiagramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openDiagramButton.Image = ((System.Drawing.Image)(resources.GetObject("openDiagramButton.Image")));
            this.openDiagramButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openDiagramButton.Name = "openDiagramButton";
            this.openDiagramButton.Size = new System.Drawing.Size(23, 19);
            this.openDiagramButton.Text = "Reload Diagrams";
            this.openDiagramButton.Click += new System.EventHandler(this.openDiagramButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 22);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 19);
            this.RefreshButton.Text = "Refresh Page";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 22);
            // 
            // cutButton
            // 
            this.cutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutButton.Enabled = false;
            this.cutButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.CutHS;
            this.cutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(23, 19);
            this.cutButton.Text = "C&ut";
            this.cutButton.Visible = false;
            // 
            // copyButton
            // 
            this.copyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyButton.Enabled = false;
            this.copyButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.CopyHS;
            this.copyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(23, 19);
            this.copyButton.Text = "&Copy";
            this.copyButton.Visible = false;
            // 
            // pasteButton
            // 
            this.pasteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteButton.Enabled = false;
            this.pasteButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.PasteHS;
            this.pasteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(23, 19);
            this.pasteButton.Text = "&Paste";
            this.pasteButton.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 22);
            this.toolStripSeparator3.Visible = false;
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.Edit_UndoHS;
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 19);
            this.undoButton.Text = "Undo";
            this.undoButton.ToolTipText = "Undo the last action";
            this.undoButton.Visible = false;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.Edit_RedoHS;
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 19);
            this.redoButton.Text = "Redo";
            this.redoButton.ToolTipText = "Redo the action that was undone.";
            this.redoButton.Visible = false;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 22);
            this.toolStripSeparator1.Visible = false;
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(23, 19);
            this.helpButton.Text = "User Manual";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 22);
            // 
            // actionsStrip
            // 
            this.actionsStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.actionsStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToBackButton,
            this.sendToFrontButton,
            this.toolStripSeparator6,
            this.groupButton,
            this.ungroupButton,
            this.toolStripSeparator7,
            this.toolStripLabel2,
            this.CFDConversion,
            this.toolStripSeparator9,
            this.toolStripLabel3,
            this.DFDConversion1,
            this.toolStripLabel4,
            this.DFDConversion2,
            this.toolStripSeparator4,
            this.toolStripLabel5,
            this.ORV,
            this.toolStripSeparator12,
            this.toolStripLabel1,
            this.btnRelationship,
            this.toolStripSeparator8});
            this.actionsStrip.Location = new System.Drawing.Point(0, 0);
            this.actionsStrip.Name = "actionsStrip";
            this.actionsStrip.Padding = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.actionsStrip.Size = new System.Drawing.Size(966, 24);
            this.actionsStrip.TabIndex = 8;
            // 
            // sendToBackButton
            // 
            this.sendToBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendToBackButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.SendToBackHS;
            this.sendToBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendToBackButton.Name = "sendToBackButton";
            this.sendToBackButton.Size = new System.Drawing.Size(23, 20);
            this.sendToBackButton.Text = "Send to back";
            this.sendToBackButton.Click += new System.EventHandler(this.sendToBackButton_Click);
            // 
            // sendToFrontButton
            // 
            this.sendToFrontButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendToFrontButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.BringToFrontHS;
            this.sendToFrontButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendToFrontButton.Name = "sendToFrontButton";
            this.sendToFrontButton.Size = new System.Drawing.Size(23, 20);
            this.sendToFrontButton.Text = "Send to front";
            this.sendToFrontButton.Click += new System.EventHandler(this.sendToFrontButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // groupButton
            // 
            this.groupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.groupButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.Group;
            this.groupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupButton.Name = "groupButton";
            this.groupButton.Size = new System.Drawing.Size(23, 20);
            this.groupButton.Text = "Group";
            this.groupButton.Click += new System.EventHandler(this.groupButton_Click);
            // 
            // ungroupButton
            // 
            this.ungroupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ungroupButton.Image = global::Netron.NetronLight.Demo.Properties.Resources.Ungroup;
            this.ungroupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ungroupButton.Name = "ungroupButton";
            this.ungroupButton.Size = new System.Drawing.Size(23, 20);
            this.ungroupButton.Text = "Ungroup";
            this.ungroupButton.Click += new System.EventHandler(this.ungroupButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 20);
            this.toolStripLabel2.Text = "STT";
            // 
            // CFDConversion
            // 
            this.CFDConversion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CFDConversion.Image = ((System.Drawing.Image)(resources.GetObject("CFDConversion.Image")));
            this.CFDConversion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CFDConversion.Name = "CFDConversion";
            this.CFDConversion.Size = new System.Drawing.Size(23, 20);
            this.CFDConversion.Text = "CFD to STT";
            this.CFDConversion.Click += new System.EventHandler(this.CFDConversion_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(93, 20);
            this.toolStripLabel3.Text = "TransformBased";
            // 
            // DFDConversion1
            // 
            this.DFDConversion1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DFDConversion1.Image = ((System.Drawing.Image)(resources.GetObject("DFDConversion1.Image")));
            this.DFDConversion1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DFDConversion1.Name = "DFDConversion1";
            this.DFDConversion1.Size = new System.Drawing.Size(23, 20);
            this.DFDConversion1.Text = "Transform Based Conversion";
            this.DFDConversion1.Click += new System.EventHandler(this.DFDConversion1_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(100, 20);
            this.toolStripLabel4.Text = "TransactionBased";
            // 
            // DFDConversion2
            // 
            this.DFDConversion2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DFDConversion2.Image = ((System.Drawing.Image)(resources.GetObject("DFDConversion2.Image")));
            this.DFDConversion2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DFDConversion2.Name = "DFDConversion2";
            this.DFDConversion2.Size = new System.Drawing.Size(23, 20);
            this.DFDConversion2.Text = "Transaction Based Conversion";
            this.DFDConversion2.Click += new System.EventHandler(this.DFDConversion2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(30, 20);
            this.toolStripLabel5.Text = "ORV";
            // 
            // ORV
            // 
            this.ORV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ORV.Image = ((System.Drawing.Image)(resources.GetObject("ORV.Image")));
            this.ORV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ORV.Name = "ORV";
            this.ORV.Size = new System.Drawing.Size(23, 20);
            this.ORV.Text = "Object Relation View";
            this.ORV.Click += new System.EventHandler(this.ORV_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 20);
            this.toolStripLabel1.Text = "Connection Type";
            // 
            // btnRelationship
            // 
            this.btnRelationship.BackColor = System.Drawing.Color.Transparent;
            this.btnRelationship.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRelationship.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnArrow00,
            this.btnArrow01,
            this.btnArrow02,
            this.btnArrow11,
            this.btnArrow12,
            this.btnArrow22,
            this.btnArrowGeneral,
            this.btnArrowControl,
            this.dashedArrowToolStripMenuItem});
            this.btnRelationship.ForeColor = System.Drawing.Color.Black;
            this.btnRelationship.Image = ((System.Drawing.Image)(resources.GetObject("btnRelationship.Image")));
            this.btnRelationship.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelationship.Name = "btnRelationship";
            this.btnRelationship.Size = new System.Drawing.Size(32, 20);
            this.btnRelationship.Text = "toolStripDropDownButton1";
            this.btnRelationship.ToolTipText = "Relationships";
            // 
            // btnArrow00
            // 
            this.btnArrow00.BackColor = System.Drawing.Color.Transparent;
            this.btnArrow00.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow00.Image")));
            this.btnArrow00.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnArrow00.Name = "btnArrow00";
            this.btnArrow00.Size = new System.Drawing.Size(168, 22);
            this.btnArrow00.Text = "Plain Relationship";
            this.btnArrow00.Click += new System.EventHandler(this.btnArrow00_Click);
            // 
            // btnArrow01
            // 
            this.btnArrow01.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow01.Image")));
            this.btnArrow01.Name = "btnArrow01";
            this.btnArrow01.Size = new System.Drawing.Size(168, 22);
            this.btnArrow01.Text = "Single Arrow";
            this.btnArrow01.Click += new System.EventHandler(this.btnArrow01_Click);
            // 
            // btnArrow02
            // 
            this.btnArrow02.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow02.Image")));
            this.btnArrow02.Name = "btnArrow02";
            this.btnArrow02.Size = new System.Drawing.Size(168, 22);
            this.btnArrow02.Text = "Double Arrow";
            this.btnArrow02.Click += new System.EventHandler(this.btnArrow02_Click);
            // 
            // btnArrow11
            // 
            this.btnArrow11.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow11.Image")));
            this.btnArrow11.Name = "btnArrow11";
            this.btnArrow11.Size = new System.Drawing.Size(168, 22);
            this.btnArrow11.Text = "1-1";
            this.btnArrow11.Click += new System.EventHandler(this.btnArrow11_Click);
            // 
            // btnArrow12
            // 
            this.btnArrow12.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow12.Image")));
            this.btnArrow12.Name = "btnArrow12";
            this.btnArrow12.Size = new System.Drawing.Size(168, 22);
            this.btnArrow12.Text = "1-M";
            this.btnArrow12.Click += new System.EventHandler(this.btnArrow12_Click);
            // 
            // btnArrow22
            // 
            this.btnArrow22.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow22.Image")));
            this.btnArrow22.Name = "btnArrow22";
            this.btnArrow22.Size = new System.Drawing.Size(168, 22);
            this.btnArrow22.Text = "M-M";
            this.btnArrow22.Click += new System.EventHandler(this.btnArrow22_Click);
            // 
            // btnArrowGeneral
            // 
            this.btnArrowGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnArrowGeneral.Image")));
            this.btnArrowGeneral.Name = "btnArrowGeneral";
            this.btnArrowGeneral.Size = new System.Drawing.Size(168, 22);
            this.btnArrowGeneral.Text = "Diamond Arrow";
            this.btnArrowGeneral.Click += new System.EventHandler(this.btnArrowGeneral_Click);
            // 
            // btnArrowControl
            // 
            this.btnArrowControl.Image = ((System.Drawing.Image)(resources.GetObject("btnArrowControl.Image")));
            this.btnArrowControl.Name = "btnArrowControl";
            this.btnArrowControl.Size = new System.Drawing.Size(168, 22);
            this.btnArrowControl.Text = "Inheritance";
            this.btnArrowControl.Click += new System.EventHandler(this.btnArrowControl_Click);
            // 
            // dashedArrowToolStripMenuItem
            // 
            this.dashedArrowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashedArrowToolStripMenuItem.Image")));
            this.dashedArrowToolStripMenuItem.Name = "dashedArrowToolStripMenuItem";
            this.dashedArrowToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.dashedArrowToolStripMenuItem.Text = "Dashed Arrow";
            this.dashedArrowToolStripMenuItem.Click += new System.EventHandler(this.dashedArrowToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 10);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.middlesplitContainer);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStripProgressBar1);
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(968, 565);
            this.splitContainer2.SplitterDistance = 534;
            this.splitContainer2.TabIndex = 0;
            // 
            // middlesplitContainer
            // 
            this.middlesplitContainer.BackColor = System.Drawing.Color.Transparent;
            this.middlesplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middlesplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.middlesplitContainer.IsSplitterFixed = true;
            this.middlesplitContainer.Location = new System.Drawing.Point(0, 0);
            this.middlesplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.middlesplitContainer.Name = "middlesplitContainer";
            // 
            // middlesplitContainer.Panel1
            // 
            this.middlesplitContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.middlesplitContainer.Panel1.Controls.Add(this.splitContainer4);
            this.middlesplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // middlesplitContainer.Panel2
            // 
            this.middlesplitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.middlesplitContainer.Panel2.Controls.Add(this.splitContainerright);
            this.middlesplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.middlesplitContainer.Size = new System.Drawing.Size(968, 529);
            this.middlesplitContainer.SplitterDistance = 173;
            this.middlesplitContainer.SplitterWidth = 15;
            this.middlesplitContainer.TabIndex = 6;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Gray;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer4.Panel2.Controls.Add(this.ListViewUtilities);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer4.Size = new System.Drawing.Size(170, 529);
            this.splitContainer4.SplitterDistance = 363;
            this.splitContainer4.SplitterWidth = 10;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer5.BackgroundImage")));
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer5.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer5.Panel2.Controls.Add(this.objectExplorer);
            this.splitContainer5.Panel2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.splitContainer5.Size = new System.Drawing.Size(170, 363);
            this.splitContainer5.SplitterDistance = 25;
            this.splitContainer5.SplitterWidth = 5;
            this.splitContainer5.TabIndex = 0;
            // 
            // objectExplorer
            // 
            this.objectExplorer.BackColor = System.Drawing.Color.White;
            this.objectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectExplorer.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.objectExplorer.FullRowSelect = true;
            this.objectExplorer.HideSelection = false;
            this.objectExplorer.HotTracking = true;
            this.objectExplorer.LineColor = System.Drawing.Color.Gray;
            this.objectExplorer.Location = new System.Drawing.Point(5, 10);
            this.objectExplorer.Name = "objectExplorer";
            treeNode1.Name = "CObject";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "C Objects";
            treeNode1.ToolTipText = "Concrete Objects";
            treeNode2.Name = "ADTObject";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "ADT Objects";
            treeNode2.ToolTipText = "Abstract Data Type Objects";
            treeNode3.Name = "SMObject";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.Text = "SM Objects";
            treeNode3.ToolTipText = "State Machine Objects";
            this.objectExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.objectExplorer.Size = new System.Drawing.Size(160, 318);
            this.objectExplorer.TabIndex = 0;
            this.objectExplorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.objectExplorer_ItemDrag);
            this.objectExplorer.Enter += new System.EventHandler(this.objectExplorer_Enter);
            // 
            // ListViewUtilities
            // 
            this.ListViewUtilities.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ListViewUtilities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewUtilities.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "UTILITIES";
            listViewGroup1.Name = "UTILITIES";
            this.ListViewUtilities.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "DataStoreObject";
            listViewItem1.ToolTipText = "Store Object";
            listViewItem2.Group = listViewGroup1;
            listViewItem2.StateImageIndex = 0;
            listViewItem2.Tag = "DataSinkObject";
            listViewItem2.ToolTipText = "Transform Object";
            listViewItem3.Group = listViewGroup1;
            listViewItem3.StateImageIndex = 0;
            listViewItem3.Tag = "CustomizedObject";
            listViewItem3.ToolTipText = "Arbitrary Object";
            listViewItem4.Group = listViewGroup1;
            listViewItem4.StateImageIndex = 0;
            listViewItem4.Tag = "Terminator";
            listViewItem4.ToolTipText = "Program End";
            this.ListViewUtilities.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.ListViewUtilities.Location = new System.Drawing.Point(5, 5);
            this.ListViewUtilities.Name = "ListViewUtilities";
            this.ListViewUtilities.Size = new System.Drawing.Size(160, 146);
            this.ListViewUtilities.SmallImageList = this.shapesImageList;
            this.ListViewUtilities.TabIndex = 0;
            this.ListViewUtilities.UseCompatibleStateImageBehavior = false;
            this.ListViewUtilities.View = System.Windows.Forms.View.SmallIcon;
            this.ListViewUtilities.Enter += new System.EventHandler(this.ListViewUtilities_Enter);
            this.ListViewUtilities.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewUtilities_MouseDown);
            // 
            // shapesImageList
            // 
            this.shapesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("shapesImageList.ImageStream")));
            this.shapesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.shapesImageList.Images.SetKeyName(0, "20110410095313313_easyicon_cn_128.png");
            this.shapesImageList.Images.SetKeyName(1, "20110410095531865_easyicon_cn_48.png");
            this.shapesImageList.Images.SetKeyName(2, "20110410095719723_easyicon_cn_64.png");
            this.shapesImageList.Images.SetKeyName(3, "20110410095802132_easyicon_cn_32.png");
            this.shapesImageList.Images.SetKeyName(4, "20110410101132819_easyicon_cn_48.png");
            this.shapesImageList.Images.SetKeyName(5, "20110418043959672_easyicon_cn_32.png");
            this.shapesImageList.Images.SetKeyName(6, "20110418044336646_easyicon_cn_24.png");
            // 
            // splitContainerright
            // 
            this.splitContainerright.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerright.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerright.IsSplitterFixed = true;
            this.splitContainerright.Location = new System.Drawing.Point(30, 0);
            this.splitContainerright.Name = "splitContainerright";
            this.splitContainerright.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerright.Panel1
            // 
            this.splitContainerright.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainerright.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainerright.Panel2
            // 
            this.splitContainerright.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerright.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainerright.Size = new System.Drawing.Size(747, 529);
            this.splitContainerright.SplitterDistance = 51;
            this.splitContainerright.TabIndex = 3;
            // 
            // splitContainer6
            // 
            this.splitContainer6.BackColor = System.Drawing.Color.Gray;
            this.splitContainer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer6.Panel1.Controls.Add(this.ORVbutton);
            this.splitContainer6.Panel1.Controls.Add(this.CHButton);
            this.splitContainer6.Panel1.Controls.Add(this.ERDbutton);
            this.splitContainer6.Panel1.Controls.Add(this.DFDButton);
            this.splitContainer6.Panel1.Controls.Add(this.DMDButton);
            this.splitContainer6.Panel1.Controls.Add(this.CFDButton);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer6.Panel2.Controls.Add(this.diagramListBox);
            this.splitContainer6.Panel2.Controls.Add(this.LableDiagramList);
            this.splitContainer6.Panel2.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.splitContainer6.Size = new System.Drawing.Size(747, 51);
            this.splitContainer6.SplitterDistance = 541;
            this.splitContainer6.TabIndex = 0;
            // 
            // ORVbutton
            // 
            this.ORVbutton.BackColor = System.Drawing.Color.Transparent;
            this.ORVbutton.Location = new System.Drawing.Point(431, 1);
            this.ORVbutton.Name = "ORVbutton";
            this.ORVbutton.Size = new System.Drawing.Size(77, 47);
            this.ORVbutton.TabIndex = 16;
            this.ORVbutton.Text = "ORV";
            this.ORVbutton.UseVisualStyleBackColor = false;
            this.ORVbutton.Click += new System.EventHandler(this.ORVbutton_Click);
            // 
            // CHButton
            // 
            this.CHButton.BackColor = System.Drawing.Color.Transparent;
            this.CHButton.Location = new System.Drawing.Point(348, 1);
            this.CHButton.Name = "CHButton";
            this.CHButton.Size = new System.Drawing.Size(77, 47);
            this.CHButton.TabIndex = 25;
            this.CHButton.Text = "CH";
            this.CHButton.UseVisualStyleBackColor = false;
            this.CHButton.Click += new System.EventHandler(this.CHButton_Click);
            // 
            // ERDbutton
            // 
            this.ERDbutton.BackColor = System.Drawing.Color.Transparent;
            this.ERDbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ERDbutton.Location = new System.Drawing.Point(16, 1);
            this.ERDbutton.Name = "ERDbutton";
            this.ERDbutton.Size = new System.Drawing.Size(77, 47);
            this.ERDbutton.TabIndex = 15;
            this.ERDbutton.Text = "ERD";
            this.ERDbutton.UseVisualStyleBackColor = false;
            this.ERDbutton.Click += new System.EventHandler(this.ERDbutton_Click);
            // 
            // DFDButton
            // 
            this.DFDButton.BackColor = System.Drawing.Color.Transparent;
            this.DFDButton.Location = new System.Drawing.Point(182, 1);
            this.DFDButton.Name = "DFDButton";
            this.DFDButton.Size = new System.Drawing.Size(77, 47);
            this.DFDButton.TabIndex = 23;
            this.DFDButton.Text = "DFD";
            this.DFDButton.UseVisualStyleBackColor = false;
            this.DFDButton.Click += new System.EventHandler(this.DFDButton_Click);
            // 
            // DMDButton
            // 
            this.DMDButton.BackColor = System.Drawing.Color.Transparent;
            this.DMDButton.Location = new System.Drawing.Point(265, 1);
            this.DMDButton.Name = "DMDButton";
            this.DMDButton.Size = new System.Drawing.Size(77, 47);
            this.DMDButton.TabIndex = 24;
            this.DMDButton.Text = "DMD";
            this.DMDButton.UseVisualStyleBackColor = false;
            this.DMDButton.Click += new System.EventHandler(this.DMDButton_Click);
            // 
            // CFDButton
            // 
            this.CFDButton.BackColor = System.Drawing.Color.Transparent;
            this.CFDButton.Location = new System.Drawing.Point(99, 1);
            this.CFDButton.Name = "CFDButton";
            this.CFDButton.Size = new System.Drawing.Size(77, 47);
            this.CFDButton.TabIndex = 22;
            this.CFDButton.Text = "CFD";
            this.CFDButton.UseVisualStyleBackColor = false;
            this.CFDButton.Click += new System.EventHandler(this.CFDButton_Click);
            // 
            // diagramListBox
            // 
            this.diagramListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diagramListBox.FormattingEnabled = true;
            this.diagramListBox.Location = new System.Drawing.Point(13, 24);
            this.diagramListBox.Name = "diagramListBox";
            this.diagramListBox.Size = new System.Drawing.Size(166, 21);
            this.diagramListBox.TabIndex = 2;
            this.diagramListBox.TextChanged += new System.EventHandler(this.diagramListBox_TextChanged);
            this.diagramListBox.Enter += new System.EventHandler(this.diagramListBox_Enter);
            // 
            // LableDiagramList
            // 
            this.LableDiagramList.AutoSize = true;
            this.LableDiagramList.BackColor = System.Drawing.Color.Transparent;
            this.LableDiagramList.Dock = System.Windows.Forms.DockStyle.Top;
            this.LableDiagramList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableDiagramList.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LableDiagramList.Location = new System.Drawing.Point(10, 1);
            this.LableDiagramList.Name = "LableDiagramList";
            this.LableDiagramList.Size = new System.Drawing.Size(95, 16);
            this.LableDiagramList.TabIndex = 1;
            this.LableDiagramList.Text = "Diagram List";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(807, 6);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(142, 19);
            this.toolStripProgressBar1.TabIndex = 1;
            this.toolStripProgressBar1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProjectStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(968, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProjectStatus
            // 
            this.ProjectStatus.Name = "ProjectStatus";
            this.ProjectStatus.Size = new System.Drawing.Size(39, 22);
            this.ProjectStatus.Text = "Ready";
            // 
            // GraphManipulationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GraphManipulationUserControl";
            this.Size = new System.Drawing.Size(968, 637);
            this.VisibleChanged += new System.EventHandler(this.GraphManipulationUserControl_VisibleChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.actionsStrip.ResumeLayout(false);
            this.actionsStrip.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.middlesplitContainer.Panel1.ResumeLayout(false);
            this.middlesplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.middlesplitContainer)).EndInit();
            this.middlesplitContainer.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainerright.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerright)).EndInit();
            this.splitContainerright.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer middlesplitContainer;
        private System.Windows.Forms.SplitContainer splitContainerright;
        private System.Windows.Forms.Button ERDbutton;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip mainStrip;
        private System.Windows.Forms.ToolStripButton newDiagramButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton openDiagramButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutButton;
        private System.Windows.Forms.ToolStripButton copyButton;
        private System.Windows.Forms.ToolStripButton pasteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.ToolStrip actionsStrip;
        private System.Windows.Forms.ToolStripButton sendToBackButton;
        private System.Windows.Forms.ToolStripButton sendToFrontButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton groupButton;
        private System.Windows.Forms.ToolStripButton ungroupButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Button CHButton;
        private System.Windows.Forms.Button DMDButton;
        private System.Windows.Forms.Button DFDButton;
        private System.Windows.Forms.Button CFDButton;
        private System.Windows.Forms.TreeView objectExplorer;
        private System.Windows.Forms.ToolStripSplitButton btnRelationship;
        private System.Windows.Forms.ToolStripMenuItem btnArrow00;
        private System.Windows.Forms.ToolStripMenuItem btnArrow01;
        private System.Windows.Forms.ToolStripMenuItem btnArrow02;
        private System.Windows.Forms.ToolStripMenuItem btnArrow11;
        private System.Windows.Forms.ToolStripMenuItem btnArrow12;
        private System.Windows.Forms.ToolStripMenuItem btnArrow22;
        private System.Windows.Forms.ToolStripMenuItem btnArrowGeneral;
        private System.Windows.Forms.ToolStripMenuItem btnArrowControl;
        private System.Windows.Forms.ToolStripMenuItem dashedArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton CFDConversion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton DFDConversion1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton DFDConversion2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView ListViewUtilities;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ImageList shapesImageList;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Label LableDiagramList;
        private System.Windows.Forms.ToolStripButton LoadDiagrams;
        private System.Windows.Forms.ToolStripStatusLabel ProjectStatus;
        private System.Windows.Forms.ProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton ORV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.Button ORVbutton;
        private System.Windows.Forms.ComboBox diagramListBox;
        System.ComponentModel.ComponentResourceManager resources;


    }
}
