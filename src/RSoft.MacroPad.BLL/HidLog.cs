using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSoft.MacroPad.BLL
{
    public static class HidLog
    {
        const string FILE = "hid.log";
        public static void ClearLog()
        {
            File.WriteAllText(FILE, "");
        }

        public static void AppendMsg(byte reportId, IEnumerable<byte> data)
        {
            File.AppendAllText(FILE, $"{reportId}\n\n");
            File.AppendAllText(FILE, string.Join("\n", data));
            File.AppendAllText(FILE, "\n------\n");
        }
    }
}
