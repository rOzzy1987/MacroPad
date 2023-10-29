using System;
using System.Linq;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.Infrastructure;

namespace RSoft.MacroPad.Controls.Tabs
{
    public partial class MouseButtonsTab : UserControl
    {
        private Modifier modifier = Modifier.None;
        private MouseButton mouseButton = MouseButton.Left;

        public Modifier Modifier
        {
            get => modifier;
            set
            {
                modifier = value;
                UpdateControls();
            }
        }
        public MouseButton MouseButton
        {
            get => mouseButton;
            set
            {
                mouseButton = value;
                UpdateControls();
            }
        }

        public MouseButtonsTab()
        {
            InitializeComponent();

            rbClickLeft.Tag = MouseButton.Left;
            rbClickMiddle.Tag = MouseButton.Middle;
            rbClickRight.Tag = MouseButton.Right;

            rbScrollUp.Tag = MouseButton.ScrollUp;
            rbScrollDown.Tag = MouseButton.ScrollDown;

            cbShiftL.Tag = Modifier.LeftShift;
            cbShiftR.Tag = Modifier.RightShift;
            cbAltL.Tag = Modifier.LeftAlt;
            cbAltR.Tag = Modifier.RightAlt;
            cbCtrlL.Tag = Modifier.LeftCtrl;
            cbCtrlR.Tag = Modifier.RightCtrl;
            cbWinL.Tag = Modifier.LeftWin;
            cbWinR.Tag = Modifier.RightWin;

            UpdateControls();
        }

        private void UpdateControls()
        {
            var rb = gbFunction.Controls.As<RadioButton>().FirstOrDefault(r => (MouseButton)r.Tag == mouseButton);
            if (rb != null) rb.Checked = true;

            foreach (var item in gbModifiers.Controls.As<CheckBox>())
            {
                item.Checked = ((Modifier)item.Tag & modifier) != Modifier.None;
            }
        }

        private void ModifierChanged(object sender, EventArgs e)
        {
            var result = Modifier.None;

            foreach (var item in gbModifiers.Controls.As<CheckBox>())
            {
                if (item.Checked)
                    result |= (Modifier)item.Tag;
            }

            modifier = result;
        }

        private void ButtonChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            MouseButton = (MouseButton)rb.Tag;
        }
    }
}
