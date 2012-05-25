namespace Netron.NetronLight.Demo
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Version = new System.Windows.Forms.Button();
            this.HELP = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gohome = new System.Windows.Forms.Button();
            this.button_file = new System.Windows.Forms.Button();
            this.menu_panel = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.new_highlight = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.exit_highlight = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.save_highlight = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.open_highlight = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.dataEntryButton = new System.Windows.Forms.Button();
            this.drawingButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_panel)).BeginInit();
            this.menu_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1484, 762);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Version);
            this.splitContainer1.Panel1.Controls.Add(this.HELP);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.gohome);
            this.splitContainer1.Panel1.Controls.Add(this.button_file);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.menu_panel);
            this.splitContainer1.Panel2.Controls.Add(this.dataEntryButton);
            this.splitContainer1.Panel2.Controls.Add(this.drawingButton);
            this.splitContainer1.Size = new System.Drawing.Size(1484, 762);
            this.splitContainer1.SplitterDistance = 30;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 7;
            // 
            // Version
            // 
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Version.BackgroundImage")));
            this.Version.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Version.FlatAppearance.BorderSize = 0;
            this.Version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Version.Location = new System.Drawing.Point(204, 0);
            this.Version.MaximumSize = new System.Drawing.Size(96, 30);
            this.Version.MinimumSize = new System.Drawing.Size(96, 30);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(96, 30);
            this.Version.TabIndex = 6;
            this.Version.UseVisualStyleBackColor = false;
            this.Version.Click += new System.EventHandler(this.Version_Click);
            this.Version.MouseHover += new System.EventHandler(this.Version_MouseHover);
            // 
            // HELP
            // 
            this.HELP.BackColor = System.Drawing.Color.Transparent;
            this.HELP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HELP.BackgroundImage")));
            this.HELP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HELP.FlatAppearance.BorderSize = 0;
            this.HELP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HELP.Location = new System.Drawing.Point(102, 0);
            this.HELP.MaximumSize = new System.Drawing.Size(96, 30);
            this.HELP.MinimumSize = new System.Drawing.Size(96, 30);
            this.HELP.Name = "HELP";
            this.HELP.Size = new System.Drawing.Size(96, 30);
            this.HELP.TabIndex = 5;
            this.HELP.UseVisualStyleBackColor = false;
            this.HELP.Click += new System.EventHandler(this.button1_Click);
            this.HELP.MouseHover += new System.EventHandler(this.HELP_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(96, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1322, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // gohome
            // 
            this.gohome.BackColor = System.Drawing.Color.Transparent;
            this.gohome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gohome.BackgroundImage")));
            this.gohome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gohome.Dock = System.Windows.Forms.DockStyle.Right;
            this.gohome.FlatAppearance.BorderSize = 0;
            this.gohome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gohome.Location = new System.Drawing.Point(1418, 0);
            this.gohome.Name = "gohome";
            this.gohome.Size = new System.Drawing.Size(66, 30);
            this.gohome.TabIndex = 3;
            this.gohome.UseVisualStyleBackColor = false;
            this.gohome.Click += new System.EventHandler(this.gohome_Click);
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.Color.Transparent;
            this.button_file.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_file.BackgroundImage")));
            this.button_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_file.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_file.FlatAppearance.BorderSize = 0;
            this.button_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_file.Location = new System.Drawing.Point(0, 0);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(96, 30);
            this.button_file.TabIndex = 4;
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // menu_panel
            // 
            this.menu_panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.menu_panel.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.menu_panel.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.menu_panel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.menu_panel.Appearance.Options.UseBackColor = true;
            this.menu_panel.Appearance.Options.UseBorderColor = true;
            this.menu_panel.Appearance.Options.UseForeColor = true;
            this.menu_panel.Controls.Add(this.label4);
            this.menu_panel.Controls.Add(this.label3);
            this.menu_panel.Controls.Add(this.label2);
            this.menu_panel.Controls.Add(this.shapeContainer1);
            this.menu_panel.Controls.Add(this.label1);
            this.menu_panel.Location = new System.Drawing.Point(0, 0);
            this.menu_panel.LookAndFeel.SkinName = "iMaginary";
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(183, 233);
            this.menu_panel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "E&xit";
            this.label4.Click += new System.EventHandler(this.exit_highlight_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Save Project...";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Open Project...";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(2, 2);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.new_highlight,
            this.exit_highlight,
            this.save_highlight,
            this.open_highlight,
            this.lineShape2,
            this.lineShape1,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(179, 229);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // new_highlight
            // 
            this.new_highlight.BackColor = System.Drawing.Color.Transparent;
            this.new_highlight.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.new_highlight.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.new_highlight.FillColor = System.Drawing.Color.White;
            this.new_highlight.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.new_highlight.Location = new System.Drawing.Point(11, 11);
            this.new_highlight.Name = "new_highlight";
            this.new_highlight.Size = new System.Drawing.Size(153, 33);
            this.new_highlight.Click += new System.EventHandler(this.new_highlight_Click);
            this.new_highlight.MouseEnter += new System.EventHandler(this.new_highlight_MouseEnter);
            this.new_highlight.MouseLeave += new System.EventHandler(this.new_highlight_MouseLeave);
            // 
            // exit_highlight
            // 
            this.exit_highlight.BackColor = System.Drawing.Color.Transparent;
            this.exit_highlight.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.exit_highlight.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.exit_highlight.FillColor = System.Drawing.Color.White;
            this.exit_highlight.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.exit_highlight.Location = new System.Drawing.Point(13, 149);
            this.exit_highlight.Name = "exit_highlight";
            this.exit_highlight.Size = new System.Drawing.Size(153, 33);
            this.exit_highlight.Click += new System.EventHandler(this.exit_highlight_Click);
            this.exit_highlight.MouseEnter += new System.EventHandler(this.exit_highlight_MouseEnter);
            this.exit_highlight.MouseLeave += new System.EventHandler(this.exit_highlight_MouseLeave);
            // 
            // save_highlight
            // 
            this.save_highlight.BackColor = System.Drawing.Color.Transparent;
            this.save_highlight.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.save_highlight.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.save_highlight.FillColor = System.Drawing.Color.White;
            this.save_highlight.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.save_highlight.Location = new System.Drawing.Point(13, 98);
            this.save_highlight.Name = "save_highlight";
            this.save_highlight.Size = new System.Drawing.Size(153, 33);
            this.save_highlight.Click += new System.EventHandler(this.label3_Click);
            this.save_highlight.MouseEnter += new System.EventHandler(this.save_highlight_MouseEnter);
            this.save_highlight.MouseLeave += new System.EventHandler(this.save_highlight_MouseLeave);
            // 
            // open_highlight
            // 
            this.open_highlight.BackColor = System.Drawing.Color.Transparent;
            this.open_highlight.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.open_highlight.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.open_highlight.FillColor = System.Drawing.Color.White;
            this.open_highlight.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.open_highlight.Location = new System.Drawing.Point(13, 57);
            this.open_highlight.Name = "open_highlight";
            this.open_highlight.Size = new System.Drawing.Size(153, 33);
            this.open_highlight.Click += new System.EventHandler(this.label2_Click);
            this.open_highlight.MouseEnter += new System.EventHandler(this.open_highlight_MouseEnter_1);
            this.open_highlight.MouseLeave += new System.EventHandler(this.open_highlight_MouseLeave);
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Silver;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 13;
            this.lineShape2.X2 = 165;
            this.lineShape2.Y1 = 144;
            this.lineShape2.Y2 = 144;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Silver;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 11;
            this.lineShape1.X2 = 163;
            this.lineShape1.Y1 = 51;
            this.lineShape1.Y2 = 51;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.White;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.Silver;
            this.rectangleShape1.CornerRadius = 6;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(178, 228);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "&New Project";
            this.label1.Click += new System.EventHandler(this.new_highlight_Click);
            // 
            // dataEntryButton
            // 
            this.dataEntryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dataEntryButton.FlatAppearance.BorderSize = 0;
            this.dataEntryButton.Image = ((System.Drawing.Image)(resources.GetObject("dataEntryButton.Image")));
            this.dataEntryButton.Location = new System.Drawing.Point(245, 250);
            this.dataEntryButton.Name = "dataEntryButton";
            this.dataEntryButton.Size = new System.Drawing.Size(266, 250);
            this.dataEntryButton.TabIndex = 0;
            this.dataEntryButton.UseVisualStyleBackColor = false;
            this.dataEntryButton.Click += new System.EventHandler(this.dataEntryButton_Click);
            // 
            // drawingButton
            // 
            this.drawingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingButton.FlatAppearance.BorderSize = 0;
            this.drawingButton.Image = ((System.Drawing.Image)(resources.GetObject("drawingButton.Image")));
            this.drawingButton.Location = new System.Drawing.Point(959, 250);
            this.drawingButton.Name = "drawingButton";
            this.drawingButton.Size = new System.Drawing.Size(266, 250);
            this.drawingButton.TabIndex = 1;
            this.drawingButton.UseVisualStyleBackColor = true;
            this.drawingButton.Click += new System.EventHandler(this.drawingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 762);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamic Diagramming Tool (DDT) - Work in Progress";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu_panel)).EndInit();
            this.menu_panel.ResumeLayout(false);
            this.menu_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button drawingButton;
        private System.Windows.Forms.Button dataEntryButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button gohome;
        private System.Windows.Forms.Button button_file;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape new_highlight;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape exit_highlight;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape save_highlight;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape open_highlight;
        public DevExpress.XtraEditors.PanelControl menu_panel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button HELP;
        private System.Windows.Forms.Button Version;
    }
}