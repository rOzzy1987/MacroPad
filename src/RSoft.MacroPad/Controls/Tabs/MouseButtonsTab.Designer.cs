namespace RSoft.MacroPad.Controls.Tabs
{
    partial class MouseButtonsTab
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
            this.rbClickLeft = new System.Windows.Forms.RadioButton();
            this.rbClickMiddle = new System.Windows.Forms.RadioButton();
            this.rbClickRight = new System.Windows.Forms.RadioButton();
            this.rbScrollUp = new System.Windows.Forms.RadioButton();
            this.rbScrollDown = new System.Windows.Forms.RadioButton();
            this.cbShiftL = new System.Windows.Forms.CheckBox();
            this.cbCtrlL = new System.Windows.Forms.CheckBox();
            this.cbAltL = new System.Windows.Forms.CheckBox();
            this.cbWinL = new System.Windows.Forms.CheckBox();
            this.cbShiftR = new System.Windows.Forms.CheckBox();
            this.cbCtrlR = new System.Windows.Forms.CheckBox();
            this.cbAltR = new System.Windows.Forms.CheckBox();
            this.cbWinR = new System.Windows.Forms.CheckBox();
            this.gbFunction = new System.Windows.Forms.GroupBox();
            this.gbModifiers = new System.Windows.Forms.GroupBox();
            this.gbFunction.SuspendLayout();
            this.gbModifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbClickLeft
            // 
            this.rbClickLeft.AutoSize = true;
            this.rbClickLeft.Location = new System.Drawing.Point(6, 19);
            this.rbClickLeft.Name = "rbClickLeft";
            this.rbClickLeft.Size = new System.Drawing.Size(68, 17);
            this.rbClickLeft.TabIndex = 0;
            this.rbClickLeft.TabStop = true;
            this.rbClickLeft.Text = "Left click";
            this.rbClickLeft.UseVisualStyleBackColor = true;
            this.rbClickLeft.Click += new System.EventHandler(this.ButtonChanged);
            // 
            // rbClickMiddle
            // 
            this.rbClickMiddle.AutoSize = true;
            this.rbClickMiddle.Location = new System.Drawing.Point(6, 42);
            this.rbClickMiddle.Name = "rbClickMiddle";
            this.rbClickMiddle.Size = new System.Drawing.Size(81, 17);
            this.rbClickMiddle.TabIndex = 0;
            this.rbClickMiddle.TabStop = true;
            this.rbClickMiddle.Text = "Middle click";
            this.rbClickMiddle.UseVisualStyleBackColor = true;
            this.rbClickMiddle.Click += new System.EventHandler(this.ButtonChanged);
            // 
            // rbClickRight
            // 
            this.rbClickRight.AutoSize = true;
            this.rbClickRight.Location = new System.Drawing.Point(6, 65);
            this.rbClickRight.Name = "rbClickRight";
            this.rbClickRight.Size = new System.Drawing.Size(75, 17);
            this.rbClickRight.TabIndex = 0;
            this.rbClickRight.TabStop = true;
            this.rbClickRight.Text = "Right click";
            this.rbClickRight.UseVisualStyleBackColor = true;
            this.rbClickRight.Click += new System.EventHandler(this.ButtonChanged);
            // 
            // rbScrollUp
            // 
            this.rbScrollUp.AutoSize = true;
            this.rbScrollUp.Location = new System.Drawing.Point(107, 19);
            this.rbScrollUp.Name = "rbScrollUp";
            this.rbScrollUp.Size = new System.Drawing.Size(66, 17);
            this.rbScrollUp.TabIndex = 0;
            this.rbScrollUp.TabStop = true;
            this.rbScrollUp.Text = "Scroll up";
            this.rbScrollUp.UseVisualStyleBackColor = true;
            this.rbScrollUp.Click += new System.EventHandler(this.ButtonChanged);
            // 
            // rbScrollDown
            // 
            this.rbScrollDown.AutoSize = true;
            this.rbScrollDown.Location = new System.Drawing.Point(107, 42);
            this.rbScrollDown.Name = "rbScrollDown";
            this.rbScrollDown.Size = new System.Drawing.Size(80, 17);
            this.rbScrollDown.TabIndex = 0;
            this.rbScrollDown.TabStop = true;
            this.rbScrollDown.Text = "Scroll down";
            this.rbScrollDown.UseVisualStyleBackColor = true;
            this.rbScrollDown.Click += new System.EventHandler(this.ButtonChanged);
            // 
            // cbShiftL
            // 
            this.cbShiftL.AutoSize = true;
            this.cbShiftL.Location = new System.Drawing.Point(6, 19);
            this.cbShiftL.Name = "cbShiftL";
            this.cbShiftL.Size = new System.Drawing.Size(78, 17);
            this.cbShiftL.TabIndex = 1;
            this.cbShiftL.Text = "Left SHIFT";
            this.cbShiftL.UseVisualStyleBackColor = true;
            this.cbShiftL.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbCtrlL
            // 
            this.cbCtrlL.AutoSize = true;
            this.cbCtrlL.Location = new System.Drawing.Point(6, 42);
            this.cbCtrlL.Name = "cbCtrlL";
            this.cbCtrlL.Size = new System.Drawing.Size(75, 17);
            this.cbCtrlL.TabIndex = 1;
            this.cbCtrlL.Text = "Left CTRL";
            this.cbCtrlL.UseVisualStyleBackColor = true;
            this.cbCtrlL.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbAltL
            // 
            this.cbAltL.AutoSize = true;
            this.cbAltL.Location = new System.Drawing.Point(6, 65);
            this.cbAltL.Name = "cbAltL";
            this.cbAltL.Size = new System.Drawing.Size(67, 17);
            this.cbAltL.TabIndex = 1;
            this.cbAltL.Text = "Left ALT";
            this.cbAltL.UseVisualStyleBackColor = true;
            this.cbAltL.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbWinL
            // 
            this.cbWinL.AutoSize = true;
            this.cbWinL.Location = new System.Drawing.Point(6, 88);
            this.cbWinL.Name = "cbWinL";
            this.cbWinL.Size = new System.Drawing.Size(69, 17);
            this.cbWinL.TabIndex = 1;
            this.cbWinL.Text = "Left WIN";
            this.cbWinL.UseVisualStyleBackColor = true;
            this.cbWinL.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbShiftR
            // 
            this.cbShiftR.AutoSize = true;
            this.cbShiftR.Location = new System.Drawing.Point(133, 19);
            this.cbShiftR.Name = "cbShiftR";
            this.cbShiftR.Size = new System.Drawing.Size(85, 17);
            this.cbShiftR.TabIndex = 1;
            this.cbShiftR.Text = "Right SHIFT";
            this.cbShiftR.UseVisualStyleBackColor = true;
            this.cbShiftR.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbCtrlR
            // 
            this.cbCtrlR.AutoSize = true;
            this.cbCtrlR.Location = new System.Drawing.Point(133, 42);
            this.cbCtrlR.Name = "cbCtrlR";
            this.cbCtrlR.Size = new System.Drawing.Size(82, 17);
            this.cbCtrlR.TabIndex = 1;
            this.cbCtrlR.Text = "Right CTRL";
            this.cbCtrlR.UseVisualStyleBackColor = true;
            this.cbCtrlR.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbAltR
            // 
            this.cbAltR.AutoSize = true;
            this.cbAltR.Location = new System.Drawing.Point(133, 65);
            this.cbAltR.Name = "cbAltR";
            this.cbAltR.Size = new System.Drawing.Size(74, 17);
            this.cbAltR.TabIndex = 1;
            this.cbAltR.Text = "Right ALT";
            this.cbAltR.UseVisualStyleBackColor = true;
            this.cbAltR.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // cbWinR
            // 
            this.cbWinR.AutoSize = true;
            this.cbWinR.Location = new System.Drawing.Point(133, 88);
            this.cbWinR.Name = "cbWinR";
            this.cbWinR.Size = new System.Drawing.Size(76, 17);
            this.cbWinR.TabIndex = 1;
            this.cbWinR.Text = "Right WIN";
            this.cbWinR.UseVisualStyleBackColor = true;
            this.cbWinR.Click += new System.EventHandler(this.ModifierChanged);
            // 
            // gbFunction
            // 
            this.gbFunction.Controls.Add(this.rbClickMiddle);
            this.gbFunction.Controls.Add(this.rbClickLeft);
            this.gbFunction.Controls.Add(this.rbClickRight);
            this.gbFunction.Controls.Add(this.rbScrollUp);
            this.gbFunction.Controls.Add(this.rbScrollDown);
            this.gbFunction.Location = new System.Drawing.Point(3, 3);
            this.gbFunction.Name = "gbFunction";
            this.gbFunction.Size = new System.Drawing.Size(200, 109);
            this.gbFunction.TabIndex = 2;
            this.gbFunction.TabStop = false;
            this.gbFunction.Text = "Function";
            // 
            // gbModifiers
            // 
            this.gbModifiers.Controls.Add(this.cbShiftL);
            this.gbModifiers.Controls.Add(this.cbCtrlL);
            this.gbModifiers.Controls.Add(this.cbWinR);
            this.gbModifiers.Controls.Add(this.cbShiftR);
            this.gbModifiers.Controls.Add(this.cbAltR);
            this.gbModifiers.Controls.Add(this.cbAltL);
            this.gbModifiers.Controls.Add(this.cbWinL);
            this.gbModifiers.Controls.Add(this.cbCtrlR);
            this.gbModifiers.Location = new System.Drawing.Point(209, 3);
            this.gbModifiers.Name = "gbModifiers";
            this.gbModifiers.Size = new System.Drawing.Size(223, 109);
            this.gbModifiers.TabIndex = 3;
            this.gbModifiers.TabStop = false;
            this.gbModifiers.Text = "Modifiers";
            // 
            // MouseButtonsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbModifiers);
            this.Controls.Add(this.gbFunction);
            this.MaximumSize = new System.Drawing.Size(1800, 120);
            this.MinimumSize = new System.Drawing.Size(800, 120);
            this.Name = "MouseButtonsTab";
            this.Size = new System.Drawing.Size(800, 120);
            this.gbFunction.ResumeLayout(false);
            this.gbFunction.PerformLayout();
            this.gbModifiers.ResumeLayout(false);
            this.gbModifiers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbClickLeft;
        private System.Windows.Forms.RadioButton rbClickMiddle;
        private System.Windows.Forms.RadioButton rbClickRight;
        private System.Windows.Forms.RadioButton rbScrollUp;
        private System.Windows.Forms.RadioButton rbScrollDown;
        private System.Windows.Forms.CheckBox cbShiftL;
        private System.Windows.Forms.CheckBox cbCtrlL;
        private System.Windows.Forms.CheckBox cbAltL;
        private System.Windows.Forms.CheckBox cbWinL;
        private System.Windows.Forms.CheckBox cbShiftR;
        private System.Windows.Forms.CheckBox cbCtrlR;
        private System.Windows.Forms.CheckBox cbAltR;
        private System.Windows.Forms.CheckBox cbWinR;
        private System.Windows.Forms.GroupBox gbFunction;
        private System.Windows.Forms.GroupBox gbModifiers;
    }
}
