using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSoft.MacroPad.Model;

namespace RSoft.MacroPad.Controls.Tabs
{
    public partial class KeyTab : UserControl
    {
        private bool delaySupported = true;

        public bool DelaySupported
        {
            get => delaySupported;
            set
            {
                UpdateDelay(value);
                delaySupported = value;
            }
        }

        public int SequenceMaxLength
        {
            get => keyRecorderTextBox1.SequenceMaxLength;
            set
            {
                keyRecorderTextBox1.SequenceMaxLength = value;
                if (!DesignMode)
                    lblMaxStrokes.Text = SequenceMaxLength.ToString();
            }
        }

        public ushort Delay
        {
            get => (ushort)nudDelay.Value;
            set { nudDelay.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public IEnumerable<KeyStroke> Sequence
        {
            get => keyRecorderTextBox1.Sequence;
            set => keyRecorderTextBox1.Sequence = value;
        }

        public KeyTab()
        {
            InitializeComponent();
        }

        private void UpdateDelay(bool value)
        {
            if (delaySupported == value)
            {
                return;
            }
            if (value)
            {
                Controls.Add(label1);
                Controls.Add(nudDelay);
                Controls.Add(label2);
            }
            else
            {
                Controls.Remove(label1);
                Controls.Remove(nudDelay);
                Controls.Remove(label2);
            }
        }

        internal void StopRecording()
        {
            keyRecorderTextBox1.Listen = false;
        }
    }
}
