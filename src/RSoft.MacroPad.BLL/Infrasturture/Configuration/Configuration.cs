using System.Collections.Generic;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Configuration
{
    public class Configuration
    {
        public IEnumerable<(ushort VendorId, ushort ProductId, string PathPattern, ProtocolType ProtocolType)> SupportedDevices { get; set; }
            = new (ushort, ushort, string, ProtocolType)[0];
    }
}
