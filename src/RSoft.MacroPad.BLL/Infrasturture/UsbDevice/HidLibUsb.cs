using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol;

namespace RSoft.MacroPad.BLL.Infrasturture.UsbDevice
{
    public class HidLibUsb : UsbBase
    {
        HidLib _hidLib = new HidLib();

        public string PathFragment { get; set; } = null;

        public override bool Write(Report report)
        {
            return _hidLib.WriteDevice(report.ReportId, report.Data);
        }

        //protected override byte KeyBoardVersionCheck()
        //{
        //    // HidLibUsb implementation order.
        //    // May or may not make sense to do it in different order
        //    // Doesn't seem to make any difference
        //    if (Write(VersionCheckReport.Create(3)))
        //        return Version = 3;
        //    if (Write(VersionCheckReport.Create(0)))
        //        return Version = 0;
        //    return Version = 2;
        //}

        protected override bool CheckIfConnectedInternal()
        {
            return IsConnected = _hidLib.DeviceStatus && _hidLib.CheckConnection();
        }

        protected override bool ConnectInternal()
        {
            if (_hidLib.ConnectDevice(SupportedDevices.ToArray()))
            {
                ProductId = _hidLib.ProductId;
                VendorId = _hidLib.VendorId;
                ProtocolType = _hidLib.ProtocolType.Value;

                Connected();
                return IsConnected = true;
            }
            return IsConnected = false;
        }
    }
}
