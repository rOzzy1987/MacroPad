using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.Controls.Visual
{
    public partial class KbControl : UserControl
    {
        public static Color BorderColor { get; set; }
        public static Color ControlColor { get; set; }
        public static Color TextColor { get; set; }
        public static Color HighlightedColor => Color.FromArgb(0x40800000);
        public static Color HoverColor => Color.FromArgb(0x20000000);

        public static float BorderSize { get; set; } = 2;

        public virtual string ControlName {get;set; }
        public InputAction[] InputActions { get; set; }

        public event EventHandler<InputAction> ActionClicked;

        InputAction? _highlightedAction;
        public InputAction? HighlightedAction
        {
            get => _highlightedAction; set
            {
                _highlightedAction = value;
                SetZoneBackColor();
            }
        }

        public KbControl()
        {
            Paint += (s, e) => RedrawImg(e);
            Resize += (s, e) => HandleResize();
            CreateZones();

            InitializeComponent(); 
            HandleResize();
        }

        protected virtual void CreateZones() { }

        private List<Control> _zones = new List<Control>();
        protected T CreateZone<T>(int idx)
            where T : Control, new()
        {
            var p = new T();
            p.Tag = --idx;
            p.BackColor = Color.Transparent;
            p.Font = new Font(p.Font.FontFamily, 12f, FontStyle.Bold);
            p.MouseEnter += (s, e) => p.BackColor = HoverColor;
            p.MouseLeave += (s, e) => p.BackColor = _highlightedAction == InputActions[idx] 
                ? HighlightedColor 
                : Color.Transparent;
            p.Click += (s, e) => ActionClicked?.Invoke(this, InputActions[idx]);
            _zones.Add(p);
            Controls.Add(p);

            return p;
        }

        void SetZoneBackColor()
        {
            foreach(var control in _zones)
            {
                control.BackColor = _highlightedAction == InputActions[(int)control.Tag]
                    ? HighlightedColor
                    : Color.Transparent;
            }
        }

        protected virtual void HandleResize()
        {
        }

        protected virtual void RedrawImg(PaintEventArgs e)
        {
        }
    }

    public class KbButton : KbControl
    {
        Label _zone1;
        public KbButton()
        {
        }

        public override string ControlName
        {
            get => _zone1.Text;
            set => _zone1.Text = value;
        }

        protected override void CreateZones()
        {
            _zone1 = CreateZone<Label>(1);
            _zone1.TextAlign = ContentAlignment.MiddleCenter;
            Controls.AddRange(new Control[] {_zone1});
        }

        protected override void HandleResize()
        {
            _zone1.Size = Size;
        }

        protected override void RedrawImg(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(1, 1, Size.Width - 1, Size.Height - 1);
            g.FillRectangle(Brushes.Transparent, rect);
            g.FillRectangle(new SolidBrush(ControlColor), rect);
            g.DrawRectangle(new Pen(BorderColor, BorderSize), rect);
        }
    }

    public class KbKnob : KbControl
    {
        Panel _zone1;
        Label _zone2;
        Panel _zone3;

        public KbKnob()
        {
        }

        public override string ControlName
        {
            get => _zone2.Text;
            set => _zone2.Text = value;
        }

        protected override void CreateZones()
        {
            _zone1 = CreateZone<Panel>(1);
            _zone2 = CreateZone<Label>(2);
            _zone3 = CreateZone<Panel>(3);

            _zone2.TextAlign = ContentAlignment.MiddleCenter;
            Controls.AddRange(new Control[] { _zone1, _zone2, _zone3 });
        }

        protected override void HandleResize()
        {
            var t = Size.Width / 3;
            _zone1.Width = t;
            _zone2.Width = t;
            _zone3.Width = t;
            _zone1.Left = 0;
            _zone2.Left = t;
            _zone3.Left = 2 * t;
            _zone1.Height = Size.Height;
            _zone2.Height = Size.Height;
            _zone3.Height = Size.Height;
        }

        protected override void RedrawImg(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
            g.FillRectangle(Brushes.Transparent, rect);
            g.FillEllipse(new SolidBrush(ControlColor), rect);
            g.DrawEllipse(new Pen(BorderColor, BorderSize), rect);
        }
    }
}
