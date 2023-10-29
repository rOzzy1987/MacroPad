namespace RSoft.MacroPad.Controls.Tabs
{
    partial class KeyTab
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
            label1 = new System.Windows.Forms.Label();
            nudDelay = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            keyRecorderTextBox1 = new Compound.KeyRecorderTextBox();
            label3 = new System.Windows.Forms.Label();
            lblMaxStrokes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudDelay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 155);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Delay";
            // 
            // nudDelay
            // 
            nudDelay.Location = new System.Drawing.Point(50, 152);
            nudDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudDelay.Maximum = new decimal(new int[] { 6000, 0, 0, 0 });
            nudDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDelay.Name = "nudDelay";
            nudDelay.Size = new System.Drawing.Size(55, 23);
            nudDelay.TabIndex = 2;
            nudDelay.Value = new decimal(new int[] { 6000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(107, 155);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(23, 15);
            label2.TabIndex = 1;
            label2.Text = "ms";
            // 
            // keyRecorderTextBox1
            // 
            keyRecorderTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keyRecorderTextBox1.Listen = false;
            keyRecorderTextBox1.Location = new System.Drawing.Point(0, 0);
            keyRecorderTextBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            keyRecorderTextBox1.MinimumSize = new System.Drawing.Size(467, 92);
            keyRecorderTextBox1.Name = "keyRecorderTextBox1";
            keyRecorderTextBox1.SequenceMaxLength = 18;
            keyRecorderTextBox1.Size = new System.Drawing.Size(800, 144);
            keyRecorderTextBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.SystemColors.Control;
            label3.Location = new System.Drawing.Point(632, 155);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 15);
            label3.TabIndex = 3;
            label3.Text = "Max strokes:";
            // 
            // lblMaxStrokes
            // 
            lblMaxStrokes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMaxStrokes.BackColor = System.Drawing.SystemColors.Control;
            lblMaxStrokes.Location = new System.Drawing.Point(717, 155);
            lblMaxStrokes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaxStrokes.Name = "lblMaxStrokes";
            lblMaxStrokes.Size = new System.Drawing.Size(41, 15);
            lblMaxStrokes.TabIndex = 3;
            lblMaxStrokes.Text = "18";
            // 
            // KeyTab
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblMaxStrokes);
            Controls.Add(label3);
            Controls.Add(nudDelay);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(keyRecorderTextBox1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximumSize = new System.Drawing.Size(2100, 180);
            MinimumSize = new System.Drawing.Size(800, 180);
            Name = "KeyTab";
            Size = new System.Drawing.Size(800, 180);
            ((System.ComponentModel.ISupportInitialize)nudDelay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Compound.KeyRecorderTextBox keyRecorderTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaxStrokes;
    }
}
