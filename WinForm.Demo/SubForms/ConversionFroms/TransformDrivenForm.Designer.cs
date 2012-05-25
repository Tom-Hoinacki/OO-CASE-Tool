namespace Netron.NetronLight.Demo
{
    partial class TransactionDrivenFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDrivenFrom));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processingbox = new System.Windows.Forms.ComboBox();
            this.OutputProcessing = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start processing object";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output object";
            // 
            // processingbox
            // 
            this.processingbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processingbox.FormattingEnabled = true;
            this.processingbox.Location = new System.Drawing.Point(44, 53);
            this.processingbox.Name = "processingbox";
            this.processingbox.Size = new System.Drawing.Size(197, 21);
            this.processingbox.TabIndex = 2;
            this.processingbox.TextChanged += new System.EventHandler(this.processingbox_TextChanged);
            // 
            // OutputProcessing
            // 
            this.OutputProcessing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputProcessing.FormattingEnabled = true;
            this.OutputProcessing.Location = new System.Drawing.Point(44, 133);
            this.OutputProcessing.Name = "OutputProcessing";
            this.OutputProcessing.Size = new System.Drawing.Size(197, 21);
            this.OutputProcessing.TabIndex = 3;
            this.OutputProcessing.TextChanged += new System.EventHandler(this.OutputProcessing_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(44, 183);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(166, 183);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TransactionDrivenFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(287, 246);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.OutputProcessing);
            this.Controls.Add(this.processingbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TransactionDrivenFrom";
            this.Text = "TransformDriven";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox processingbox;
        private System.Windows.Forms.ComboBox OutputProcessing;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}