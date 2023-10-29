namespace RSoft.MacroPad.Controls.Simple
{
    partial class KeyStrokeDisplay
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
            lblChar = new System.Windows.Forms.Label();
            lblModL = new TransparentLabel();
            lblModR = new TransparentLabel();
            lblDesc = new TransparentLabel();
            SuspendLayout();
            // 
            // lblChar
            // 
            lblChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblChar.Location = new System.Drawing.Point(1, 1);
            lblChar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblChar.Name = "lblChar";
            lblChar.Size = new System.Drawing.Size(73, 73);
            lblChar.TabIndex = 0;
            lblChar.Text = "Num Lk";
            lblChar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblModL
            // 
            lblModL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblModL.Location = new System.Drawing.Point(0, 57);
            lblModL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblModL.Name = "lblModL";
            lblModL.Size = new System.Drawing.Size(75, 15);
            lblModL.TabIndex = 1;
            lblModL.TabStop = false;
            lblModL.Text = "CA";
            lblModL.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblModR
            // 
            lblModR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblModR.Location = new System.Drawing.Point(0, 57);
            lblModR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblModR.Name = "lblModR";
            lblModR.Size = new System.Drawing.Size(75, 15);
            lblModR.TabIndex = 1;
            lblModR.TabStop = false;
            lblModR.Text = "WSAD";
            lblModR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDesc
            // 
            lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDesc.Location = new System.Drawing.Point(0, 37);
            lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new System.Drawing.Size(75, 20);
            lblDesc.TabIndex = 1;
            lblDesc.TabStop = false;
            lblDesc.Text = "AButton";
            lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // KeyStrokeDisplay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lblDesc);
            Controls.Add(lblModR);
            Controls.Add(lblModL);
            Controls.Add(lblChar);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            MaximumSize = new System.Drawing.Size(75, 75);
            MinimumSize = new System.Drawing.Size(75, 75);
            Name = "KeyStrokeDisplay";
            Size = new System.Drawing.Size(75, 75);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblChar;
        private TransparentLabel lblModL;
        private TransparentLabel lblModR;
        private TransparentLabel lblDesc;
    }
}
