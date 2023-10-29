using System.Collections.Generic;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol
{
    public interface IReportComposer
    {
        IEnumerable<Report> Key(InputAction action, byte layerNo, ushort delay, IEnumerable<(KeyCode Key, Modifier Modifiers)> sequence);

        IEnumerable<Report> Media(InputAction action, byte layerNo, MediaKey key);

        IEnumerable<Report> Mouse(InputAction action, byte layerNo, MouseButton func, Modifier modifiers);

        IEnumerable<Report> Led(byte layerNo, LedMode mode, LedColor color);


    }

    public class ReportComposerBase
    {
        public byte ReportId { get; }
        protected ReportComposerBase(byte reportId)
        {
            ReportId = reportId;
        }
    }

    public class LegacyReportComposer : ReportComposerBase, IReportComposer
    {
        public LegacyReportComposer(byte reportId) : base(reportId) { }

        private List<Report> KeyFunctionInit(byte layerNo)
        {
            var result = new List<Report>();
            // Version 0 Doesn't support layers
            if (ReportId != 0)
            {
                result.Add(LayerSelectionReport.Create(ReportId, layerNo));
            }
            return result;
        }

        private List<Report> KeyFunctionEnd(List<Report> reports)
        {
            reports.Add(WriteFlashReport.Create(ReportId));
            return reports;
        }

        public IEnumerable<Report> Key(InputAction action, byte layerNo, ushort delay, IEnumerable<(KeyCode Key, Modifier Modifiers)> sequence) {
            if (sequence.Count()  == 0)
                sequence = new[] {(KeyCode.None, Modifier.None)};
            var result = KeyFunctionInit(layerNo);
            result.AddRange(KeyFunctionReport.Create(ReportId, action, layerNo, sequence));
            return KeyFunctionEnd(result);
        }

        public IEnumerable<Report> Media(InputAction action, byte layerNo, MediaKey key)
        {
            var result = KeyFunctionInit(layerNo);
            result.Add(KeyFunctionReport.CreateMultimedia(ReportId, action, layerNo, key));
            return KeyFunctionEnd(result);
        }

        public IEnumerable<Report> Mouse(InputAction action, byte layerNo, MouseButton func, Modifier modifiers)
        {
            var result = KeyFunctionInit(layerNo);
            result.Add(MouseFunctionReport.Create(ReportId, action, layerNo, func, modifiers));
            return KeyFunctionEnd(result);
        }

        public IEnumerable<Report> Led(byte layerNo, LedMode mode, LedColor color)
        {
            var result = new List<Report>();
            if ((byte)mode > 2 && ReportId == 0) 
                return result;
            result.Add(LedFunctionReport.Create(ReportId, mode, color));
            result.Add(WriteFlashReport.Create(ReportId, led: true));
            return result;
        }
    }

    public class ExtendedReportComposer : ReportComposerBase, IReportComposer
    {
        public ExtendedReportComposer(byte reportId) : base(reportId)
        {
        }

        public IEnumerable<Report> Key(InputAction action, byte layerNo, ushort delay, IEnumerable<(KeyCode Key, Modifier Modifiers)> sequence)
        {
            return new[] { ExtendedReport.CreateKey(ReportId, action, layerNo, sequence, delay) };
        }

        public IEnumerable<Report> Led(byte layerNo, LedMode mode, LedColor color)
        {
            return new[] { ExtendedReport.CreateLed(ReportId, layerNo, mode, color) };
        }

        public IEnumerable<Report> Media(InputAction action, byte layerNo, MediaKey key)
        {
            return new[] { ExtendedReport.CreateMedia(ReportId, action, layerNo, key) };
        }

        public IEnumerable<Report> Mouse(InputAction action, byte layerNo, MouseButton func, Modifier modifiers)
        {
            return new[] { ExtendedReport.CreateMouse(ReportId, action, layerNo,func, modifiers) };
        }
    }
}
