using HidLibrary;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using System.Collections.Generic;
using System.Linq;

namespace RSoft.MacroPad.BLL.Infrasturture.UsbDevice
{
    public class HidLib
    {
        private bool _deviceStatus;
        private List<HidDevice> _deviceList = new List<HidDevice>();
        private HidDevice _hidDevice;

        public ProtocolType? ProtocolType { get; private set; }

        public ushort VendorId { get; private set; }
        public ushort ProductId { get; private set; }

        public bool DeviceStatus => _deviceStatus;


        public bool ConnectDevice(params (ushort VendorId, ushort ProductId, string PathFragment, ProtocolType ProtocolType)[] supportedProducts)
        {
            foreach (var supportedProduct in supportedProducts)
            {
                _hidDevice = HidDevices.Enumerate(supportedProduct.VendorId, supportedProduct.ProductId).FirstOrDefault();
                if (_hidDevice != null)
                {
                    foreach (HidDevice hidDevice in HidDevices.Enumerate(supportedProduct.VendorId).ToList())
                    {
                        if (hidDevice.DevicePath.IndexOf(supportedProduct.PathFragment) != -1)
                        {
                            _deviceList.Add(hidDevice);
                            _hidDevice = hidDevice;
                            _hidDevice.OpenDevice();
                            //// Somehow this is not supported in .net6 but doesn't seem to make any difference
                            //_hidDevice.MonitorDeviceEvents = true;

                            ProtocolType = supportedProduct.ProtocolType;
                            VendorId = supportedProduct.VendorId;
                            ProductId = supportedProduct.ProductId;

                            _deviceStatus = true;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool CheckConnection()
        {
            if (_hidDevice.IsConnected)
                return true;
            _hidDevice.CloseDevice();
            _deviceStatus = false;
            return false;
        }

        public bool WriteDevice(byte reportId, byte[] buffer)
        {
            var report = _hidDevice.CreateReport();
            report.ReportId = reportId;

            var byteCount = report.Data.Length;

            for (int i = 0; i < byteCount; ++i)
                report.Data[i] = buffer[i];
           
            HidLog.AppendMsg(report.ReportId, ProtocolType == Model.ProtocolType.Legacy ? report.Data.Take(8) : report.Data);

            return _hidDevice.WriteReport(report, 500);
        }
    }
}
