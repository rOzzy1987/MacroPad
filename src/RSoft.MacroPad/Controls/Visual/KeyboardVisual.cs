using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Physical;
using RSoft.MacroPad.Infrastructure;

namespace RSoft.MacroPad.Controls.Visual
{
    public partial class KeyboardVisual : UserControl
    {
        private KeyboardLayout keyboardLayout;
        private byte layer = 1;

        public KeyboardLayout KeyboardLayout
        {
            get => keyboardLayout;
            set {
                keyboardLayout = value;
                UpdateVisual();
            }
        }

        public event EventHandler<InputAction> FunctionSelected;
        public byte Layer
        {
            get
            {
                return layer;
            }
            set
            {
                layer = value;
                var r = Controls.As<RadioButton>().FirstOrDefault(rb => (byte)rb.Tag == value);
                if (r != null) r.Checked = true;
            }
        }
        public InputAction SelectedAction { get; set; } = InputAction.None;


        public KeyboardVisual()
        {
            InitializeComponent();

            unchecked {
                _backdropColor = Color.FromArgb((int)0xFF446688);
                _buttonColor = Color.FromArgb((int)0xFFCCCCCC);
                _textColor = Color.FromArgb((int)0xFF000020);
                _borderColor = Color.Black;
            }

            FunctionSelected += (s, e) => Highlight(e);
        }

        private void Highlight(InputAction e)
        {
            foreach (var kb in _backdrop.Controls.Cast<KbControl>())
            {
                kb.HighlightedAction = e;
            }
            SelectedAction = e;
        }

        Color _backdropColor;
        Color _buttonColor;
        Color _borderColor;
        Color _textColor;

        Panel _backdrop;

        private void UpdateVisual()
        {
            if (KeyboardLayout == null) { return; }

            var minX = KeyboardLayout.Controls.Select(c => c.Position.X).Min();
            var minY = KeyboardLayout.Controls.Select(c => c.Position.Y).Min();
            var maxX = KeyboardLayout.Controls.Select(c => c.Position.X + c.Size.X).Max();
            var maxY = KeyboardLayout.Controls.Select(c => c.Position.Y + c.Size.Y).Max();

            const int sc = 3;


            this.Controls.Clear();

            var backdrop = new Panel();
            backdrop.BackColor = _backdropColor;
            backdrop.Size = new Size((maxX + minX) * sc, (maxY + minY) *sc);
            backdrop.Left = 10;
            backdrop.Top = 32;
            Controls.Add(backdrop);
            _backdrop = backdrop;

            var nameLabel = new Label();
            nameLabel.Left = 0;
            nameLabel.Top = 4;
            nameLabel.AutoSize = true;
            var products = string.Join(", ", KeyboardLayout.Products.Select(p => $"{p.VendorId}:{p.ProductId}"));
            nameLabel.Text = $"{KeyboardLayout.Name} ({products})";
            nameLabel.PerformLayout();
            Controls.Add(nameLabel);

            var x = nameLabel.Width + 20;

            if (KeyboardLayout.LayerCount > 1)
            {
                for (var i = 0; i < KeyboardLayout.LayerCount; i++)
                {
                    var rb = new RadioButton
                    {
                        Text = $"L{i + 1}",
                        Location = new Point(x, 0),
                        Size = new Size(50, 24),
                        Checked = i == 0,
                        Tag = (byte)(i + 1)
                    };
                    rb.Click += LayerChanged;
                    Controls.Add(rb);
                    x += 50;
                }
            }
            layer = Math.Min(KeyboardLayout.LayerCount, layer);

            Size = new Size(backdrop.Width + 20, backdrop.Height + 52);

            KbControl.BorderColor = _borderColor;
            KbControl.ControlColor = _buttonColor;
            KbControl.TextColor = _textColor;
            KbControl.BorderSize = 2f;

            foreach (var control in KeyboardLayout.Controls)
            {
                KbControl c = control is PhysicalButton
                    ? (KbControl)new KbButton()
                    : new KbKnob();
                c.Left = control.Position.X * sc;
                c.Top = control.Position.Y * sc;
                c.ControlName = control.Name;
                c.InputActions = control.Actions.ToArray();
                c.Size = new Size(control.Size.X * sc, control.Size.Y * sc);
                c.ActionClicked += (s, e) => FunctionSelected?.Invoke(s, e);
                backdrop.Controls.Add(c);
            }

            SelectedAction = KeyboardLayout.Controls.First().Actions.First();
            FunctionSelected?.Invoke(this, SelectedAction);
        }

        private void LayerChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            layer = (byte)rb.Tag;
        }

    }
}
