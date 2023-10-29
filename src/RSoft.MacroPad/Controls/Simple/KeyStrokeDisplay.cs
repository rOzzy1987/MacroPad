using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSoft.MacroPad.Infrastructure;
using RSoft.MacroPad.Model;

namespace RSoft.MacroPad.Controls.Simple
{
    public partial class KeyStrokeDisplay : UserControl
    {
        private KeyStroke stroke;

        public KeyStroke Stroke
        {
            get => stroke; set
            {
                stroke = value;
                UpdateStroke();
            }
        }

        public KeyStrokeDisplay()
        {
            InitializeComponent();

            Stroke = new KeyStroke
            {
                Key = Keys.S,
                CtrlL = true,
                AltL = true
            };
        }

        private void UpdateStroke()
        {
            lblChar.Text = KeyNameMapper.GetKeySymbol(Stroke.Key);
            var size = 26;
            switch (lblChar.Text.Length)
            {
                case 1: size = 26; break;
                case 2: size = 24; break;
                case 3: size = 20; break;
                default: size = 16; break;

            }
            var font = lblChar.Font;
            this.lblChar.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            lblChar.Font = new Font(font.FontFamily, size, font.Style, GraphicsUnit.Point, 0);

            lblDesc.Text = KeyNameMapper.GetLocalizedKeyString(Stroke.Key);

            lblModL.Text = "";
            lblModL.Text += Stroke.CtrlL ? "C" : "";
            lblModL.Text += Stroke.ShiftL ? "S" : "";
            lblModL.Text += Stroke.AltL ? "A" : "";
            lblModL.Text += Stroke.WinL ? "W" : "";

            lblModR.Text = "";
            lblModR.Text += Stroke.WinR ? "W" : "";
            lblModR.Text += Stroke.AltR ? "A" : "";
            lblModR.Text += Stroke.ShiftR ? "S" : "";
            lblModR.Text += Stroke.CtrlR ? "C" : "";

        }
    }
}
