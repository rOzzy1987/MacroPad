namespace RSoft.MacroPad.Forms
{
    partial class DisclaimerForm
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
            textBox1 = new System.Windows.Forms.RichTextBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.Location = new System.Drawing.Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(649, 257);
            textBox1.TabIndex = 0;
            textBox1.Text = "";
            textBox1.KeyDown += ButtonPressed;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(586, 275);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OkClicked;
            // 
            // DisclaimerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(673, 310);
            Controls.Add(button1);
            Controls.Add(textBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "DisclaimerForm";
            Text = "Disclaimer";
            KeyDown += ButtonPressed;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}