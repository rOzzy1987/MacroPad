namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy
{
    internal class LayerSelectionReport : Report
    {
        private LayerSelectionReport() { }

        public static LayerSelectionReport Create(byte reportId, byte layerNo)
        {
            var r = new LayerSelectionReport();
            r.ReportId = reportId;

            r.Data[0] = 161;
            r.Data[1] = layerNo;
            return r;
        }
    }
}
