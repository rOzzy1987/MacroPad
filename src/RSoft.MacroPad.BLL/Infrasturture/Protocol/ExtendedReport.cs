using System.Collections.Generic;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol
{
    internal class ExtendedReport : Report
    {
        private ExtendedReport() { }

        public static ExtendedReport CreateKey(byte reportId, InputAction action, byte layerNo, IEnumerable<(KeyCode Key, Modifier Modifiers)> sequence, ushort delay)
        {
            var data = new byte[sequence.Count() * 2];
            var i = 0;
            foreach (var (k,m) in sequence)
            {
                data[i++] = (byte)m;
                data[i++] = (byte)k;
            }

            return Create(reportId, action, layerNo, delay, KeyType.Basic, data);
        }

        public static ExtendedReport CreateMedia(byte reportId, InputAction action, byte layerNo, MediaKey key)
        {
            var data = new byte[4];
            data[0] = 0;
            data[1] = key.B1(reportId);
            data[2] = key.B2(reportId);
            data[3] = 0;
            return Create(reportId, action, layerNo, 0, KeyType.Multimedia, data);
        }

        public static ExtendedReport CreateMouse(byte reportId, InputAction action, byte layerNo, MouseButton b, Modifier modifiers)
        {
            var data = new byte[6];
            data[0] = b.Button();
            data[1] = 0;
            data[2] = 0;
            data[3] = b.Scroll();
            data[4] = (byte)modifiers;
            data[5] = 0;

            return Create(reportId, action, layerNo, 0, KeyType.Multimedia, data);
        }
        public static ExtendedReport CreateLed(byte reportId, byte layerNo, LedMode mode, LedColor color)
        {
            var data = new byte[6];
            data[0] = layerNo;
            data[1] = (byte)(((byte)mode) | ((byte)color));

            return Create(reportId, (InputAction)176, layerNo, 0, KeyType.LED, data);
        }

        private static ExtendedReport Create(byte reportId, InputAction action, byte layerNo, ushort delay, KeyType keyType, byte[] data)
        {
            ExtendedReport r = new ExtendedReport();
            r.ReportId = reportId;

            r.Data[0] = (byte)254;
            r.Data[1] = action.MapToByte();
            r.Data[2] = (byte)layerNo;
            r.Data[3] = (byte)keyType;
            r.Data[4] = (byte)(delay & 0xFF);
            r.Data[5] = (byte)((delay >> 8) & 0xFF);
            r.Data[6] = (byte)0;
            r.Data[7] = (byte)0;
            r.Data[8] = (byte)0;

            byte count = 0;
            for(var i = 0; i < data.Length && i < r.Data.Length - 10; i++)
            {
                r.Data[10 + i] = data[i];
                if (data[i] != 0)
                    count = (byte)((i >> 1) + 1);
            }

            r.Data[9] = count;

            return r;
        }
    }
}
