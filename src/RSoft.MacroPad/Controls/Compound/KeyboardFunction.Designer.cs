namespace RSoft.MacroPad.Controls.Compound
{
    partial class KeyboardFunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardFunction));
            tabControl1 = new System.Windows.Forms.TabControl();
            tabFunction = new System.Windows.Forms.TabPage();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabSequence = new System.Windows.Forms.TabPage();
            keyTab1 = new Tabs.KeyTab();
            tabMedia = new System.Windows.Forms.TabPage();
            mediaKeyTab1 = new Tabs.MediaKeyTab();
            tabMouse = new System.Windows.Forms.TabPage();
            mouseButtonsTab1 = new Tabs.MouseButtonsTab();
            tabLed = new System.Windows.Forms.TabPage();
            ledTab1 = new Tabs.LedTab();
            tabControl1.SuspendLayout();
            tabFunction.SuspendLayout();
            tabControl2.SuspendLayout();
            tabSequence.SuspendLayout();
            tabMedia.SuspendLayout();
            tabMouse.SuspendLayout();
            tabLed.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabFunction);
            tabControl1.Controls.Add(tabLed);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1245, 517);
            tabControl1.TabIndex = 0;
            // 
            // tabFunction
            // 
            tabFunction.Controls.Add(tabControl2);
            tabFunction.Location = new System.Drawing.Point(4, 24);
            tabFunction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabFunction.Name = "tabFunction";
            tabFunction.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabFunction.Size = new System.Drawing.Size(1237, 489);
            tabFunction.TabIndex = 0;
            tabFunction.Text = "Key functions";
            tabFunction.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl2.Controls.Add(tabSequence);
            tabControl2.Controls.Add(tabMedia);
            tabControl2.Controls.Add(tabMouse);
            tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl2.Location = new System.Drawing.Point(4, 3);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(1229, 483);
            tabControl2.TabIndex = 0;
            // 
            // tabSequence
            // 
            tabSequence.Controls.Add(keyTab1);
            tabSequence.Location = new System.Drawing.Point(4, 27);
            tabSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSequence.Name = "tabSequence";
            tabSequence.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSequence.Size = new System.Drawing.Size(1221, 452);
            tabSequence.TabIndex = 0;
            tabSequence.Text = "Key sequence";
            tabSequence.UseVisualStyleBackColor = true;
            // 
            // keyTab1
            // 
            keyTab1.Delay = (ushort)6000;
            keyTab1.DelaySupported = false;
            keyTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            keyTab1.Location = new System.Drawing.Point(4, 3);
            keyTab1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            keyTab1.MaximumSize = new System.Drawing.Size(2100, 185);
            keyTab1.MinimumSize = new System.Drawing.Size(933, 185);
            keyTab1.Name = "keyTab1";
            keyTab1.SequenceMaxLength = 18;
            keyTab1.Size = new System.Drawing.Size(1213, 185);
            keyTab1.TabIndex = 0;
            // 
            // tabMedia
            // 
            tabMedia.Controls.Add(mediaKeyTab1);
            tabMedia.Location = new System.Drawing.Point(4, 27);
            tabMedia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabMedia.Name = "tabMedia";
            tabMedia.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabMedia.Size = new System.Drawing.Size(1221, 452);
            tabMedia.TabIndex = 1;
            tabMedia.Text = "Media  key";
            tabMedia.UseVisualStyleBackColor = true;
            // 
            // mediaKeyTab1
            // 
            mediaKeyTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            mediaKeyTab1.Key = System.Windows.Forms.Keys.MediaNextTrack;
            mediaKeyTab1.KeyStroke = (Model.KeyStroke)resources.GetObject("mediaKeyTab1.KeyStroke");
            mediaKeyTab1.Location = new System.Drawing.Point(4, 3);
            mediaKeyTab1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaKeyTab1.MaximumSize = new System.Drawing.Size(2100, 138);
            mediaKeyTab1.MinimumSize = new System.Drawing.Size(933, 138);
            mediaKeyTab1.Name = "mediaKeyTab1";
            mediaKeyTab1.Size = new System.Drawing.Size(1213, 138);
            mediaKeyTab1.TabIndex = 0;
            // 
            // tabMouse
            // 
            tabMouse.Controls.Add(mouseButtonsTab1);
            tabMouse.Location = new System.Drawing.Point(4, 27);
            tabMouse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabMouse.Name = "tabMouse";
            tabMouse.Size = new System.Drawing.Size(1221, 452);
            tabMouse.TabIndex = 2;
            tabMouse.Text = "Mouse";
            tabMouse.UseVisualStyleBackColor = true;
            // 
            // mouseButtonsTab1
            // 
            mouseButtonsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            mouseButtonsTab1.Location = new System.Drawing.Point(0, 0);
            mouseButtonsTab1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mouseButtonsTab1.MaximumSize = new System.Drawing.Size(2100, 138);
            mouseButtonsTab1.MinimumSize = new System.Drawing.Size(933, 138);
            mouseButtonsTab1.Modifier = BLL.Infrasturture.Model.Modifier.None;
            mouseButtonsTab1.MouseButton = BLL.Infrasturture.Model.MouseButton.Left;
            mouseButtonsTab1.Name = "mouseButtonsTab1";
            mouseButtonsTab1.Size = new System.Drawing.Size(1221, 138);
            mouseButtonsTab1.TabIndex = 0;
            // 
            // tabLed
            // 
            tabLed.Controls.Add(ledTab1);
            tabLed.Location = new System.Drawing.Point(4, 24);
            tabLed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabLed.Name = "tabLed";
            tabLed.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabLed.Size = new System.Drawing.Size(1237, 489);
            tabLed.TabIndex = 1;
            tabLed.Text = "LED mode";
            tabLed.UseVisualStyleBackColor = true;
            // 
            // ledTab1
            // 
            ledTab1.Color = BLL.Infrasturture.Model.LedColor.Random;
            ledTab1.ColorsSupported = true;
            ledTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            ledTab1.Location = new System.Drawing.Point(4, 3);
            ledTab1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            ledTab1.MaximumSize = new System.Drawing.Size(2100, 138);
            ledTab1.MinimumSize = new System.Drawing.Size(933, 138);
            ledTab1.Mode = BLL.Infrasturture.Model.LedMode.Mode0;
            ledTab1.ModeCount = 3;
            ledTab1.Name = "ledTab1";
            ledTab1.Size = new System.Drawing.Size(1229, 138);
            ledTab1.TabIndex = 0;
            // 
            // KeyboardFunction
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "KeyboardFunction";
            Size = new System.Drawing.Size(1245, 517);
            tabControl1.ResumeLayout(false);
            tabFunction.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabSequence.ResumeLayout(false);
            tabMedia.ResumeLayout(false);
            tabMouse.ResumeLayout(false);
            tabLed.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFunction;
        private System.Windows.Forms.TabPage tabLed;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabSequence;
        private System.Windows.Forms.TabPage tabMedia;
        private System.Windows.Forms.TabPage tabMouse;
        private Tabs.MediaKeyTab mediaKeyTab1;
        private Tabs.MouseButtonsTab mouseButtonsTab1;
        private Tabs.KeyTab keyTab1;
        private Tabs.LedTab ledTab1;
    }
}
