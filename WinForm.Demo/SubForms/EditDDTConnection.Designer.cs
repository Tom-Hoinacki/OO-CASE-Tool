namespace Netron.NetronLight.Demo
{
    partial class EditDDTConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDDTConnection));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fromText = new System.Windows.Forms.TextBox();
            this.middleText = new System.Windows.Forms.TextBox();
            this.toText = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.CANCEL = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.PictureBox();
            this.erase = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erase)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(71, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "From:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(71, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Middle:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(71, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "To:";
            // 
            // fromText
            // 
            this.fromText.Location = new System.Drawing.Point(113, 44);
            this.fromText.Name = "fromText";
            this.fromText.Size = new System.Drawing.Size(138, 20);
            this.fromText.TabIndex = 6;
            // 
            // middleText
            // 
            this.middleText.Location = new System.Drawing.Point(113, 87);
            this.middleText.Name = "middleText";
            this.middleText.Size = new System.Drawing.Size(138, 20);
            this.middleText.TabIndex = 7;
            // 
            // toText
            // 
            this.toText.Location = new System.Drawing.Point(113, 130);
            this.toText.Name = "toText";
            this.toText.Size = new System.Drawing.Size(138, 20);
            this.toText.TabIndex = 8;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(74, 181);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 9;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // CANCEL
            // 
            this.CANCEL.Location = new System.Drawing.Point(176, 181);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(75, 23);
            this.CANCEL.TabIndex = 10;
            this.CANCEL.Text = "CANCEL";
            this.CANCEL.UseVisualStyleBackColor = true;
            this.CANCEL.Click += new System.EventHandler(this.CANCEL_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Transparent;
            this.help.Image = ((System.Drawing.Image)(resources.GetObject("help.Image")));
            this.help.Location = new System.Drawing.Point(12, 182);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(27, 24);
            this.help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help.TabIndex = 11;
            this.help.TabStop = false;
            this.help.Tag = "help";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // erase
            // 
            this.erase.BackColor = System.Drawing.Color.Transparent;
            this.erase.Image = ((System.Drawing.Image)(resources.GetObject("erase.Image")));
            this.erase.Location = new System.Drawing.Point(291, 180);
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(27, 24);
            this.erase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.erase.TabIndex = 12;
            this.erase.TabStop = false;
            this.erase.Tag = "help";
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // EditDDTConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(330, 224);
            this.Controls.Add(this.erase);
            this.Controls.Add(this.help);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.toText);
            this.Controls.Add(this.middleText);
            this.Controls.Add(this.fromText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditDDTConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Connection Text";
            ((System.ComponentModel.ISupportInitialize)(this.help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fromText;
        private System.Windows.Forms.TextBox middleText;
        private System.Windows.Forms.TextBox toText;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button CANCEL;
        private System.Windows.Forms.PictureBox help;
        private System.Windows.Forms.PictureBox erase;
    }
}