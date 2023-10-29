namespace RSoft.MacroPad.Controls.Tabs
{
    partial class MediaKeyTab
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
            this.rbTrackPrev = new System.Windows.Forms.RadioButton();
            this.rbTrackNext = new System.Windows.Forms.RadioButton();
            this.rbTrackPlay = new System.Windows.Forms.RadioButton();
            this.rbVolUp = new System.Windows.Forms.RadioButton();
            this.rbVolDown = new System.Windows.Forms.RadioButton();
            this.rbVolMute = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbTrackPrev
            // 
            this.rbTrackPrev.AutoSize = true;
            this.rbTrackPrev.Location = new System.Drawing.Point(4, 4);
            this.rbTrackPrev.Name = "rbTrackPrev";
            this.rbTrackPrev.Size = new System.Drawing.Size(93, 17);
            this.rbTrackPrev.TabIndex = 0;
            this.rbTrackPrev.TabStop = true;
            this.rbTrackPrev.Text = "Previous track";
            this.rbTrackPrev.UseVisualStyleBackColor = true;
            this.rbTrackPrev.Click += new System.EventHandler(this.KeyChanged);
            // 
            // rbTrackNext
            // 
            this.rbTrackNext.AutoSize = true;
            this.rbTrackNext.Location = new System.Drawing.Point(4, 27);
            this.rbTrackNext.Name = "rbTrackNext";
            this.rbTrackNext.Size = new System.Drawing.Size(74, 17);
            this.rbTrackNext.TabIndex = 0;
            this.rbTrackNext.TabStop = true;
            this.rbTrackNext.Text = "Next track";
            this.rbTrackNext.UseVisualStyleBackColor = true;
            this.rbTrackNext.Click += new System.EventHandler(this.KeyChanged);
            // 
            // rbTrackPlay
            // 
            this.rbTrackPlay.AutoSize = true;
            this.rbTrackPlay.Location = new System.Drawing.Point(4, 50);
            this.rbTrackPlay.Name = "rbTrackPlay";
            this.rbTrackPlay.Size = new System.Drawing.Size(86, 17);
            this.rbTrackPlay.TabIndex = 0;
            this.rbTrackPlay.TabStop = true;
            this.rbTrackPlay.Text = "Play / Pause";
            this.rbTrackPlay.UseVisualStyleBackColor = true;
            this.rbTrackPlay.Click += new System.EventHandler(this.KeyChanged);
            // 
            // rbVolUp
            // 
            this.rbVolUp.AutoSize = true;
            this.rbVolUp.Location = new System.Drawing.Point(129, 4);
            this.rbVolUp.Name = "rbVolUp";
            this.rbVolUp.Size = new System.Drawing.Size(75, 17);
            this.rbVolUp.TabIndex = 0;
            this.rbVolUp.TabStop = true;
            this.rbVolUp.Text = "Volume up";
            this.rbVolUp.UseVisualStyleBackColor = true;
            this.rbVolUp.Click += new System.EventHandler(this.KeyChanged);
            // 
            // rbVolDown
            // 
            this.rbVolDown.AutoSize = true;
            this.rbVolDown.Location = new System.Drawing.Point(129, 27);
            this.rbVolDown.Name = "rbVolDown";
            this.rbVolDown.Size = new System.Drawing.Size(89, 17);
            this.rbVolDown.TabIndex = 0;
            this.rbVolDown.TabStop = true;
            this.rbVolDown.Text = "Volume down";
            this.rbVolDown.UseVisualStyleBackColor = true;
            this.rbVolDown.Click += new System.EventHandler(this.KeyChanged);
            // 
            // rbVolMute
            // 
            this.rbVolMute.AutoSize = true;
            this.rbVolMute.Location = new System.Drawing.Point(129, 50);
            this.rbVolMute.Name = "rbVolMute";
            this.rbVolMute.Size = new System.Drawing.Size(97, 17);
            this.rbVolMute.TabIndex = 0;
            this.rbVolMute.TabStop = true;
            this.rbVolMute.Text = "Mute / Unmute";
            this.rbVolMute.UseVisualStyleBackColor = true;
            this.rbVolMute.Click += new System.EventHandler(this.KeyChanged);
            // 
            // MediaKeyTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbVolMute);
            this.Controls.Add(this.rbTrackPlay);
            this.Controls.Add(this.rbVolDown);
            this.Controls.Add(this.rbTrackNext);
            this.Controls.Add(this.rbVolUp);
            this.Controls.Add(this.rbTrackPrev);
            this.MaximumSize = new System.Drawing.Size(1800, 120);
            this.MinimumSize = new System.Drawing.Size(800, 120);
            this.Name = "MediaKeyTab";
            this.Size = new System.Drawing.Size(800, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbTrackPrev;
        private System.Windows.Forms.RadioButton rbTrackNext;
        private System.Windows.Forms.RadioButton rbTrackPlay;
        private System.Windows.Forms.RadioButton rbVolUp;
        private System.Windows.Forms.RadioButton rbVolDown;
        private System.Windows.Forms.RadioButton rbVolMute;
    }
}
