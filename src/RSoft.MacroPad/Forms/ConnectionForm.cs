using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Protocol;
using RSoft.MacroPad.BLL.Infrasturture.UsbDevice;

namespace RSoft.MacroPad.Forms
{
    public partial class ConnectionForm : Form
    {
        private IUsb _usb;

        public ConnectionForm(IUsb? usb = null)
        {
            _usb = usb;
            InitializeComponent();

            nudVersion.Value = _usb.Version;
            lblStatus.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblStatus.Text = $"ReportId-{nudVersion.Value}: ";
            lblStatus.ForeColor = Color.Maroon;
            if (_usb.CheckIfConnected())
            {
                var report = VersionCheckReport.Create((byte)nudVersion.Value);
                if (_usb.Write(report))
                {
                    lblStatus.Text += "Keypad responded!";
                    lblStatus.ForeColor = Color.DarkGreen;
                    _usb.Version = (byte)nudVersion.Value;
                }
                else  
                {
                    lblStatus.Text = "Keypad didn't respond!";
                }
            }
            else {
                lblStatus.Text = "No connection!";
            }
        }
    }
}
