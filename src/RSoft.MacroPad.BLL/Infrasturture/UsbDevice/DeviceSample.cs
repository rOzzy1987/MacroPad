using System.Collections.Generic;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.UsbDevice
{
    public static class DeviceSample
    {
        public static int VendorId { get; set; } = 4489;
        public static IEnumerable<(ushort VendorId, ushort ProductId, string PathFragment, ProtocolType protocolType)> Devices
            => new (ushort, ushort, string, ProtocolType)[]
        {
            (4489, 34960, "mi_01", ProtocolType.Legacy),
            (4489, 34864, "mi_00", ProtocolType.Extended),
            (4489, 34865, "mi_00", ProtocolType.Extended),
            (4489, 34866, "mi_00", ProtocolType.Extended),
            (4489, 34967, "mi_00", ProtocolType.Extended),
            (4489, 34932, "mi_00", ProtocolType.Extended)
        };
    }
}
