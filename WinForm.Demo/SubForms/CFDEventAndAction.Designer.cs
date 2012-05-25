namespace Netron.NetronLight.Demo{ 
    partial class CFDEventAndAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFDEventAndAction));
            this.erase = new System.Windows.Forms.PictureBox();
            this.CANCEL = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.middleText = new System.Windows.Forms.TextBox();
            this.fromText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erase)).BeginInit();
            this.SuspendLayout();
            // 
            // erase
            // 
            this.erase.BackColor = System.Drawing.Color.Transparent;
            this.erase.Image = ((System.Drawing.Image)(resources.GetObject("erase.Image")));
            this.erase.Location = new System.Drawing.Point(285, 141);
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(27, 24);
            this.erase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.erase.TabIndex = 21;
            this.erase.TabStop = false;
            this.erase.Tag = "help";
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // CANCEL
            // 
            this.CANCEL.Location = new System.Drawing.Point(170, 142);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(75, 23);
            this.CANCEL.TabIndex = 20;
            this.CANCEL.Text = "CANCEL";
            this.CANCEL.UseVisualStyleBackColor = true;
            this.CANCEL.Click += new System.EventHandler(this.CANCEL_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(68, 142);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 19;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // middleText
            // 
            this.middleText.Location = new System.Drawing.Point(107, 83);
            this.middleText.Name = "middleText";
            this.middleText.Size = new System.Drawing.Size(138, 20);
            this.middleText.TabIndex = 17;
            // 
            // fromText
            // 
            this.fromText.Location = new System.Drawing.Point(107, 40);
            this.fromText.Name = "fromText";
            this.fromText.Size = new System.Drawing.Size(138, 20);
            this.fromText.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(65, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Action:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(63, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Event:";
            // 
            // CFDEventAndAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 177);
            this.Controls.Add(this.erase);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.middleText);
            this.Controls.Add(this.fromText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CFDEventAndAction";
            this.Text = "Edit Event and Action";
            ((System.ComponentModel.ISupportInitialize)(this.erase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox erase;
        private System.Windows.Forms.Button CANCEL;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox middleText;
        private System.Windows.Forms.TextBox fromText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}