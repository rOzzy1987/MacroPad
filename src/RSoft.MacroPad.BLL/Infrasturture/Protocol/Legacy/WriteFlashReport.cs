namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy
{
    internal class WriteFlashReport : Report
    {
        private WriteFlashReport() { }

        public static WriteFlashReport Create(byte reportId, bool led = false)
        {
            var r = new WriteFlashReport();
            r.ReportId = reportId;

            r.Data[0] = 170;
            r.Data[1] = (byte)(led ? 161 : 170);
            return r;
        }
    }
}
