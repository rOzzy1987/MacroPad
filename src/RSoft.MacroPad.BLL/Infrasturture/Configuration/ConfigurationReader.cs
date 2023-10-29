using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Configuration
{
    public class ConfigurationReader
    {
        Regex DeviceConfigLinePattern = new Regex(@"^([0-9]+):([0-9]+),([a-zA-Z0-9\-_]+)(?:,([01]))$");
        public Configuration Read(string fileName)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(fileName).Select(l => l.Trim()).ToArray();
            }
            catch { return null; }

            var devices = new List<(ushort VendorId, ushort ProductId, string PathPattern, ProtocolType ProtocolType)>();
            var result = new Configuration()
            {
                SupportedDevices = devices
            };

            var lineNo = 0;
            foreach (var line in lines)
            {
                lineNo++;
                if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                    continue;

                var match = DeviceConfigLinePattern.Match(line);
                if (match != null && match.Success)
                {
                    
                    var vid = ushort.Parse(match.Groups[1].Value);
                    var pid = ushort.Parse(match.Groups[2].Value);
                    var path = match.Groups[3].Value;

                    var d = (vid, pid, path, Type: ProtocolType.Extended);
                    if (match.Groups.Count > 4)
                    {
                        var type = byte.Parse(match.Groups[4].Value);
                        d.Type = type == 0 ? ProtocolType.Legacy : ProtocolType.Extended;
                    }
                    devices.Add(d);
                    continue;
                }

                throw new InvalidDataException($"Invalid line format in {fileName}({lineNo}): {line}");
            }
            return result;
        }
    }
}
