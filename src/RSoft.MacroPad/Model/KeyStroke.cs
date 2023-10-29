using System;
using System.Text;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.Infrastructure;

namespace RSoft.MacroPad.Model
{
    [Serializable]
    public class KeyStroke
    {
        public Keys Key;
        public uint ScanCode;
        public bool ShiftL;
        public bool ShiftR;
        public bool AltL;
        public bool AltR;
        public bool CtrlL;
        public bool CtrlR;
        public bool WinL;
        public bool WinR;
        public KeyStrokeOperation Operation;

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append($"{Operation} ");
            if (ShiftL) result.Append("LeftShift+");
            if (ShiftR) result.Append("RightShift+");
            if (AltL) result.Append("LeftAlt+");
            if (AltR) result.Append("RightAltGr+");
            if (CtrlL) result.Append("LeftCtrl+");
            if (CtrlR) result.Append("RightCtrl+");
            if (WinL) result.Append("LeftWin+");
            if (WinR) result.Append("RightWin+");
            result.Append(KeyNameMapper.GetLocalizedKeyString(Key));
            result.Append($"({Key})");

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            return object.ReferenceEquals(this, obj);
        }

    }
}
