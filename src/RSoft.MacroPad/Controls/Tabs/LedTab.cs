using System;
using System.Linq;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.Infrastructure;

namespace RSoft.MacroPad.Controls.Tabs
{
    public partial class LedTab : UserControl
    {
        private bool colorsSupported;
        private int modeCount = 6;
        private int mode;
        private LedColor color = LedColor.Random;

        public int ModeCount
        {
            get => modeCount;
            set
            {
                modeCount = value;
                UpdateControls();
            }
        }
        public bool ColorsSupported
        {
            get => colorsSupported;
            set
            {
                colorsSupported = value;
                UpdateControls();
            }
        }

        public LedMode Mode
        {
            get => (LedMode)mode;
            set
            {
                mode = (int)value;
                UpdateControls();
            }
        }

        public LedColor Color
        {
            get => color;
            set
            {
                color = value;
                UpdateControls();
            }
        }


        public LedTab()
        {
            InitializeComponent();

            rbRed.Tag = LedColor.Red;
            rbOrange.Tag = LedColor.Orange;
            rbYellow.Tag = LedColor.Yellow;
            rbGreen.Tag = LedColor.Green;
            rbCyan.Tag = LedColor.Cyan;
            rbBlue.Tag = LedColor.Blue;
            rbPurple.Tag = LedColor.Purple;
            rbRandom.Tag = LedColor.Random;

            rbMode0.Tag = 0;
            rbMode1.Tag = 1;
            rbMode2.Tag = 2;
            rbMode3.Tag = 3;
            rbMode4.Tag = 4;
            rbMode5.Tag = 5;

            UpdateControls();
        }

        private void UpdateControls()
        {
            gbColors.Visible = colorsSupported;

            foreach (var rb in gbModes.Controls.As<RadioButton>())
            {
                rb.Visible = (int)rb.Tag < modeCount;
            }

            var rbMode = gbModes.Controls.As<RadioButton>().FirstOrDefault(r => (int)r.Tag == mode);
            if (rbMode != null) rbMode.Checked = true;

            var rbColor = gbColors.Controls.As<RadioButton>().FirstOrDefault(r => (LedColor)r.Tag == color);
            if(rbColor != null) rbColor.Checked = true;
        }

        public void ModeChanged(object sender, EventArgs e)
        {
            var rbMode = sender as RadioButton;
            mode = (int)rbMode.Tag;
        }

        public void ColorChanged(object sender, EventArgs e)
        {
            var rbColor = sender as RadioButton;
            Color = (LedColor)rbColor.Tag;
        }
    }
}
