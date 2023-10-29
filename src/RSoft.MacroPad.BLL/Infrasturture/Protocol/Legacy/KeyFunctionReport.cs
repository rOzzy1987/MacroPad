using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HID;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Legacy
{
    internal class KeyFunctionReport : Report
    {
        private KeyFunctionReport() { }

        public static KeyFunctionReport[] Create(byte reportId, InputAction action, byte layerNo, IEnumerable<(KeyCode Key, Modifier Modifiers)> keySequence)
        {
            var keyArr = keySequence.ToArray();
            var result = new KeyFunctionReport[keyArr.Length + 1];

            for (byte index = 0; index <= keyArr.Length; ++index)
            {
                var report = new KeyFunctionReport();
                report.ReportId = reportId;

                report.Data[0] = action.MapToByte();
                report.Data[1] = (byte)KeyType.Basic;
                if (reportId != 0)
                    report.Data[1] |= (byte)(layerNo << 4 & 0xFF);
                report.Data[2] = (byte)keyArr.Length;
                report.Data[3] = index;

                if (index == 0)
                {
                    // WTF??
                    report.Data[4] = (byte)keyArr[0].Modifiers;
                    report.Data[5] = 0;
                }
                else
                {
                    report.Data[4] = (byte)keyArr[index - 1].Modifiers;
                    report.Data[5] = (byte)keyArr[index - 1].Key;
                }
                result[index] = report;
            }
            return result;
        }

        public static KeyFunctionReport CreateMultimedia(byte reportId, InputAction action, byte layerNo, MediaKey key)
        {
            var report = new KeyFunctionReport();
            report.ReportId = reportId;

            report.Data[0] = action.MapToByte();
            report.Data[1] = (byte)KeyType.Multimedia;
            if (reportId != 0)
                report.Data[1] |= (byte)(layerNo << 4 & 0xFF);
            unchecked
            {
                report.Data[2] = key.B1(reportId);
                report.Data[3] = key.B2(reportId);
            }
            return report;
        }
    }
}
