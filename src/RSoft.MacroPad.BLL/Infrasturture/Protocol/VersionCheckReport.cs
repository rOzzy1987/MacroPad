namespace RSoft.MacroPad.BLL.Infrasturture.Protocol
{

    public class VersionCheckReport : Report
    {
        private VersionCheckReport() { }

        public static VersionCheckReport Create(byte version)
        {
            var r = new VersionCheckReport();
            r.ReportId = version;

            r.Data[0] = 0;
            r.Data[1] = 0;
            return r;
        }
    }
}
