namespace RSoft.MacroPad.Forms
{
    partial class ConnectionForm
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
            lblVersion = new System.Windows.Forms.Label();
            nudVersion = new System.Windows.Forms.NumericUpDown();
            button1 = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudVersion).BeginInit();
            SuspendLayout();
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(12, 14);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(114, 32);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Report ID";
            // 
            // nudVersion
            // 
            nudVersion.Location = new System.Drawing.Point(184, 12);
            nudVersion.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudVersion.Name = "nudVersion";
            nudVersion.Size = new System.Drawing.Size(74, 39);
            nudVersion.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 92);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 46);
            button1.TabIndex = 2;
            button1.Text = "Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(180, 99);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(104, 32);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "lblStatus";
            // 
            // ConnectionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(668, 152);
            Controls.Add(lblStatus);
            Controls.Add(button1);
            Controls.Add(nudVersion);
            Controls.Add(lblVersion);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "ConnectionForm";
            Text = "Connection";
            ((System.ComponentModel.ISupportInitialize)nudVersion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.NumericUpDown nudVersion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
    }
}