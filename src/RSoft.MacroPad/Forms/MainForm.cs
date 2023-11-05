using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RSoft.MacroPad.BLL;
using RSoft.MacroPad.BLL.Infrasturture;
using RSoft.MacroPad.BLL.Infrasturture.Configuration;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Physical;
using RSoft.MacroPad.BLL.Infrasturture.Protocol;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers;
using RSoft.MacroPad.BLL.Infrasturture.UsbDevice;
using RSoft.MacroPad.Infrastructure;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Input.KeyboardAndMouse;

namespace RSoft.MacroPad.Forms
{
    public partial class MainForm : Form
    {
        private KeyboardLayout[] _layouts;
        private LayoutParser _parser = new LayoutParser();
        private IUsb _usb = new HidLibUsb();
        private ConfigurationReader _configReader = new ConfigurationReader();
        private ComposerRepository _composerRepository = new ComposerRepository();


        public MainForm()
        {
            InitializeComponent();

            InitializeLayouts();
            InitializeUsb();
        }


        #region Init
        private void InitializeUsb()
        {
            var config = _configReader.Read("config.txt");
            if (config != null)
                _usb.SupportedDevices = config.SupportedDevices;

            _usb.OnConnected += (s, e) =>
            {
                var layout = _layouts.FirstOrDefault(l => l.Products.Any(p => p.VendorId == _usb.VendorId && p.ProductId == _usb.ProductId));

                if (layout != null)
                {
                    keyboardVisual1.KeyboardLayout = layout;
                    keyboardFunction1.KeyboardLayout = layout;
                }

                lblCommStatus.Text = $"Connected: ({_usb.VendorId}:{_usb.ProductId}) Protocol: {_usb.ProtocolType}.id{_usb.Version}";

                ShowDisclaimerIfNeeded();
            };
        }


        private void ShowDisclaimerIfNeeded()
        {
            if (!TestedProducts.IsTested(_usb.VendorId, _usb.ProductId))
            {
                new DisclaimerForm().ShowDialog();
            }
        }

        private void SetUsbStatus(bool connected)
        {
            lblStatus.Text = connected ? "Connected" : "Disconnected";
            lblStatus.BackColor = connected ? Color.FromArgb(0, 128, 0) : Color.FromArgb(128, 0, 0);
            tsSend.Enabled = connected;
        }

        private void InitializeLayouts()
        {
            _layouts = _parser.Parse("layouts.txt");
            ((ToolStripDropDownMenu)tsLayout.DropDown).ShowImageMargin = false;
            tsLayout.DropDownItems.Clear();
            tsLayout.DropDownItems.AddRange(_layouts.Select(l =>
            {
                var result = new ToolStripMenuItem()
                {
                    Text = l.Name,
                    AutoSize = true,
                    Tag = l
                };

                result.Click += (s, e) =>
                {
                    StopRecording(s, e);
                    keyboardVisual1.KeyboardLayout = l;
                    keyboardFunction1.KeyboardLayout = l;
                };

                return result;

            }).ToArray());
        }

        private void Tick(object sender, EventArgs e)
        {
            SetUsbStatus(_usb.Connect());
        }

        private void StopRecording(object sender, EventArgs e)
        {
            keyboardFunction1.StopRecording();
        }

        #endregion;  

        private void tsSend_Click(object sender, EventArgs e)
        {
            StopRecording(sender, e);
            if (keyboardVisual1.SelectedAction == InputAction.None)
            {
                MessageBox.Show("Please select a key or knob action to map!");
            }
            var composer = _composerRepository.Get(_usb.ProtocolType, _usb.Version);

            IEnumerable<Report> reports = Enumerable.Empty<Report>();
            switch (keyboardFunction1.Function)
            {
                case Model.SetFunction.LED:
                    reports = composer.Led(keyboardVisual1.Layer, keyboardFunction1.LedMode, keyboardFunction1.LedColor);
                    break;
                case Model.SetFunction.KeySequence:
                    var currentLayout = PInvoke.GetKeyboardLayout(0);
                    var enUsLayout = PInvoke.LoadKeyboardLayout("00000409", ACTIVATE_KEYBOARD_LAYOUT_FLAGS.KLF_ACTIVATE);

                    reports = composer.Key(keyboardVisual1.SelectedAction, keyboardVisual1.Layer, keyboardFunction1.Delay,
                        keyboardFunction1.KeySequence.Select(s => (
                        KeyCodeMapper.Map((VirtualKey)PInvoke.MapVirtualKeyEx((uint)s.ScanCode, MAP_VIRTUAL_KEY_TYPE.MAPVK_VSC_TO_VK, enUsLayout)),
                        ModifierMapper.Map(s.ShiftL, s.ShiftR, s.AltL, s.AltR, s.CtrlL, s.CtrlR, s.WinL, s.WinR))));
                    PInvoke.ActivateKeyboardLayout(currentLayout, ACTIVATE_KEYBOARD_LAYOUT_FLAGS.KLF_ACTIVATE);
                    break;
                case Model.SetFunction.MediaKey:
                    reports = composer.Media(keyboardVisual1.SelectedAction, keyboardVisual1.Layer, MediaKeyMapper.Map((VirtualKey)keyboardFunction1.MediaKey));
                    break;
                case Model.SetFunction.Mouse:
                    reports = composer.Mouse(keyboardVisual1.SelectedAction, keyboardVisual1.Layer, keyboardFunction1.MouseButton, keyboardFunction1.MouseModifier);
                    break;
            }
            bool success = true;
            HidLog.ClearLog();
            foreach (var report in reports)
            {
                if (!_usb.Write(report))
                {
                    success = false;
                    break;
                }
            }
            lblCommStatus.Text = success
                ? "Writing successful"
                : "Write failed";
            lblCommStatus.Text += $" [{DateTime.Now.ToString("T")}]";
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            StopRecording(sender, e);
            var aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void tsSetParams_Click(object sender, EventArgs e)
        {
            var f = new ConnectionForm(_usb);
            f.ShowDialog();
        }
    }
}
