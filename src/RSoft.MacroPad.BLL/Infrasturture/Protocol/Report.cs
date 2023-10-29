namespace RSoft.MacroPad.BLL.Infrasturture.Protocol
{
    public class Report
    {
        public virtual byte ReportId { get; protected set; } = 0;
        public virtual byte[] Data { get; protected set; } = new byte[65];
    }
}
