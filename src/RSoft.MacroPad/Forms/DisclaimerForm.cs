using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace RSoft.MacroPad.Forms
{
    public partial class DisclaimerForm : Form
    {
        public DisclaimerForm()
        {
            InitializeComponent();

            textBox1.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fswiss\fprq2\fcharset0 Calibri;}{\f1\fswiss\fprq2\fcharset238 Calibri;}{\f2\fnil Segoe UI;}}
{\colortbl ;\red192\green0\blue0;\red0\green0\blue255;\red5\green99\blue193;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\widctlpar\sa160\sl252\slmult1\cf1\kerning2\b\f0\fs44 Warning!\par
\cf0\b0\fs22 This software is a replacement for the original \b\i MINI Keyboard.exe\b0\i0  that is originally shipped with some small macro keyboards. No matter how hard I tried, it seems that I couldn't test it with your specific device.\par
Please test your keyboard's features with it, and report any bugs you find at {{\field{\*\fldinst{HYPERLINK https://github.com/rOzzy1987/MacroPad/issues }}{\fldrslt{https://github.com/rOzzy1987/MacroPad/issues\ul0\cf0}}}}\f0\fs22  or contact me at {{\field{\*\fldinst{HYPERLINK ""mailto:rozovits.mihaly@gmail.com?subject=MacroPad%20support""}}{\fldrslt{\ul\cf2\cf3\ul rozovits.mihaly@gmail.com}}}}\f0\fs22\par
Also let me know if everything works as intended, so I can extend the list of working devices, and automatically dismiss this disclaimer in future versions.\f1\lang1038  \kerning0\f2\fs18\lang1033\par
}";
            textBox1.LinkClicked += LinkClicked;
        }

        private void LinkClicked(object sender, LinkClickedEventArgs e)
        {

            ProcessStartInfo psi = new ProcessStartInfo(e.LinkText);
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void OkClicked(object sender, EventArgs e) => Close();
        private void ButtonPressed(object sender, KeyEventArgs e)
        {
            if (new[] { Keys.Return, Keys.Enter, Keys.Escape }.Contains(e.KeyCode))
                Close();
            e.SuppressKeyPress = true;
        }
    }
}
