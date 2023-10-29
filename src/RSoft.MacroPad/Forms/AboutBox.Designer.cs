namespace RSoft.MacroPad.Forms
{
    partial class AboutBox
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lblProduct = new System.Windows.Forms.Label();
            lblCopyright = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            lblCompany = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            lblDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(540, 140);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new System.Drawing.Point(12, 155);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new System.Drawing.Size(38, 15);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "label1";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Location = new System.Drawing.Point(12, 180);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new System.Drawing.Size(38, 15);
            lblCopyright.TabIndex = 1;
            lblCopyright.Text = "label1";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(284, 155);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(38, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "label1";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Location = new System.Drawing.Point(284, 180);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new System.Drawing.Size(38, 15);
            lblCompany.TabIndex = 1;
            lblCompany.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(476, 415);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblDescription
            // 
            lblDescription.Enabled = false;
            lblDescription.Location = new System.Drawing.Point(12, 205);
            lblDescription.Multiline = true;
            lblDescription.Name = "lblDescription";
            lblDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            lblDescription.Size = new System.Drawing.Size(539, 201);
            lblDescription.TabIndex = 3;
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(563, 450);
            Controls.Add(lblDescription);
            Controls.Add(button1);
            Controls.Add(lblCompany);
            Controls.Add(lblCopyright);
            Controls.Add(lblVersion);
            Controls.Add(lblProduct);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "AboutBox";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox lblDescription;
    }
}