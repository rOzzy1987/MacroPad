using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers;
using RSoft.MacroPad.Controls.Simple;
using RSoft.MacroPad.Infrastructure;
using RSoft.MacroPad.Model;

namespace RSoft.MacroPad.Controls.Compound
{
    public partial class KeyRecorderTextBox : UserControl
    {
        private ObservableCollection<KeyStroke> _sequence = new ObservableCollection<KeyStroke>();

        private bool _altL, _altR, _shiftL, _shiftR, _ctrlL, _ctrlR, _winL, _winR;
        private IEnumerable<Keys> _applicableKeys = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().Select(k => (Keys)k.Map());
        private int sequenceMaxLength = 18;

        private List<KeyStrokeDisplay> _sequenceDisplay = new List<KeyStrokeDisplay>();

        private List<KeyStroke> _history = new List<KeyStroke>();

        private KeyboardHook _hook;
        private bool listen = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public IEnumerable<KeyStroke> Sequence
        {
            get => _sequence.ToList();
            set { _sequence.Clear(); if (value == null) return; foreach (var item in value) _sequence.Add(item); }
        }
        public int SequenceMaxLength
        {
            get => sequenceMaxLength;
            set
            {
                sequenceMaxLength = value;
                SequenceChanged(this, EventArgs.Empty);
            }
        }

        public bool Listen
        {
            get => listen;
            set { 
                checkBox1.Checked = value; 
            }
        }
        public event EventHandler<KeyStroke> KeyStrokeAdded;
        public KeyRecorderTextBox()
        {
            Sequence = new List<KeyStroke>();
            InitializeComponent();
            _hook = new KeyboardHook();
            _hook.OnKeyPressRelease += CaptureKey;

            _sequence.CollectionChanged += SequenceChanged;
            Resize += (s, e) => RefreshDisplayLayout();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _hook.Dispose();
            }
        }

        private bool CaptureKey(KeyInfo keyInfo)
        {
            if (Listen)
            {
                AddStroke(keyInfo, keyInfo.IsKeyRelease ? KeyStrokeOperation.Release : KeyStrokeOperation.Press);
                return false;
            }
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listen = checkBox1.Checked;
            checkBox1.Text = Listen ? "■" : "●";
            checkBox1.ForeColor = Listen ? Color.Black : Color.Red;
            panel1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sequence.Clear();
            _history.Clear();
            panel1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_sequence.Count > 0)
                _sequence.RemoveAt(_sequence.Count - 1);
            panel1.Focus();
        }

        public void SequenceChanged(object sender, EventArgs e)
        {
            if (_sequence.Count > SequenceMaxLength)
            {
                _sequence.RemoveAt(SequenceMaxLength);
                return;
            }

            if (_sequence.Any())
            {
                KeyStrokeAdded?.Invoke(this, _sequence.Last());
            }

            var displaysToDelete = _sequenceDisplay.Where(d => !_sequence.Contains(d.Stroke)).ToList();
            foreach (var item in displaysToDelete)
            {
                _sequenceDisplay.Remove(item);
                panel1.Controls.Remove(item);
            }

            var strokesToAdd = _sequence.Where(s => !_sequenceDisplay.Any(d => d.Stroke == s)).ToList();
            foreach (var item in strokesToAdd)
            {
                var d = new KeyStrokeDisplay() { Stroke = item, Top = 2 };
                panel1.Controls.Add(d);
                _sequenceDisplay.Add(d);
                toolTip1.SetToolTip(d, item.ToString());
            }

            RefreshDisplayLayout();
        }

        private void RefreshDisplayLayout()
        {
            var row = 0;
            var col = 0;
            foreach (var stroke in _sequence)
            {
                var dsp = _sequenceDisplay.First(d => d.Stroke == stroke);

                if (col * 77 + 79 > panel1.Width)
                {
                    col = 0;
                    row++;
                }
                dsp.Top = 2 + (row * 77);
                dsp.Left = 2 + (col * 77);

                col++;
            }
        }

        public void AddStroke(KeyInfo info, KeyStrokeOperation op)
        {
            if (!_applicableKeys.Contains(info.key) && !IsModifier(info.key))
                return;
            if (_history.Count > 20) _history = _history.Skip(10).ToList();

            if (IsModifier(info.key))
            {
                if (info.key == Keys.LMenu) _altL = op == KeyStrokeOperation.Press;
                if (info.key == Keys.RMenu) _altR = op == KeyStrokeOperation.Press;
                if (info.key == Keys.LShiftKey) _shiftL = op == KeyStrokeOperation.Press;
                if (info.key == Keys.RShiftKey) _shiftR = op == KeyStrokeOperation.Press;
                if (info.key == Keys.LControlKey) _ctrlL = op == KeyStrokeOperation.Press;
                if (info.key == Keys.RControlKey) _ctrlR = op == KeyStrokeOperation.Press;
                if (info.key == Keys.LWin) _winL = op == KeyStrokeOperation.Press;
                if (info.key == Keys.RWin) _winR = op == KeyStrokeOperation.Press;
            }

            var newStroke = new KeyStroke()
            {
                AltL = _altL,
                AltR = _altR,
                CtrlL = _ctrlL,
                CtrlR = _ctrlR,
                ShiftL = _shiftL,
                ShiftR = _shiftR,
                WinL = _winL,
                WinR = _winR,
                Key = info.key,
                ScanCode = info.scanCode,
                Operation = op
            };
            _history.Add(newStroke);

            if (!IsModifier(info.key) && op == KeyStrokeOperation.Press)
            {
                _sequence.Add(newStroke);
            }
            else if (IsModifier(info.key) && op == KeyStrokeOperation.Release)
            {
                var i = _history.FindLastIndex(s => s.Key == info.key && s.Operation == KeyStrokeOperation.Press);
                var midwayButtonPressed = false;
                i++;
                while (i < _history.Count - 1)
                {
                    var hi = _history[i];
                    if (IsModifier(hi.Key) ^ hi.Operation == KeyStrokeOperation.Press)
                    {
                        midwayButtonPressed = true;
                        break;
                    }
                    i++;
                }
                if (!midwayButtonPressed)
                {
                    var newModStroke = new KeyStroke
                    {
                        Key = info.key,
                        ScanCode = info.scanCode,
                        Operation = KeyStrokeOperation.Release,
                        AltL = _altL | info.key == Keys.LMenu,
                        AltR = _altR | info.key == Keys.RMenu,
                        CtrlL = _ctrlL | info.key == Keys.LControlKey,
                        CtrlR = _ctrlR | info.key == Keys.RControlKey,
                        ShiftL = _shiftL | info.key == Keys.LShiftKey,
                        ShiftR = _shiftR | info.key == Keys.RShiftKey,
                        WinL = _winL | info.key == Keys.LWin,
                        WinR = _winL | info.key == Keys.RWin,
                    };
                    _sequence.Add(newModStroke);
                }
            }
            
        }

        private bool IsModifier(Keys k)
        {
            return k == Keys.LMenu || k == Keys.RMenu ||
                k == Keys.LShiftKey || k == Keys.RShiftKey ||
                k == Keys.LControlKey || k == Keys.RControlKey ||
                k == Keys.LWin || k == Keys.RWin;
        }
    }
}
