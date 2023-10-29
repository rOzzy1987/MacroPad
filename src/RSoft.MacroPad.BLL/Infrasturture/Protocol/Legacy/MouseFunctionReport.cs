using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy
{
    internal class MouseFunctionReport : Report
    {
        private MouseFunctionReport() { }

        public static MouseFunctionReport Create(byte reportId, InputAction action, byte layerNo, MouseButton button, Modifier modifiers)
        {
            var r = new MouseFunctionReport();
            r.ReportId = reportId;

            r.Data[0] = action.MapToByte();
            r.Data[1] = (byte)KeyType.Mouse;
            if (reportId != 0)
                r.Data[1] |= (byte)(layerNo << 4 & 0xFF);

            r.Data[2] = button.Button();
            r.Data[3] = 0;
            r.Data[4] = 0;
            r.Data[5] = button.Scroll();
            r.Data[6] = (byte)modifiers;
            return r;
        }

        
    }
}
