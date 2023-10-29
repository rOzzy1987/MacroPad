using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy
{
    internal class LedFunctionReport : Report
    {
        private LedFunctionReport() { }

        public static LedFunctionReport Create(byte reportId, LedMode mode, LedColor color)
        {
            var r = new LedFunctionReport();
            r.ReportId = reportId;

            r.Data[0] = 176;
            r.Data[1] = (byte)KeyType.LED;
            r.Data[2] = (byte)(((byte)mode) | ((byte)color));
            return r;
        }
    }
}
