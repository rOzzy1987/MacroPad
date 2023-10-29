using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers
{
    public static class ModifierMapper
    {
        public static Modifier Map(bool lShft, bool rShft, bool lAlt, bool rAlt, bool lCtrl, bool rCtrl, bool lWin, bool rWin)
        {
            var result = Modifier.None;
            if (lShft) result |= Modifier.LeftShift;
            if (rShft) result |= Modifier.RightShift;
            if (lAlt) result |= Modifier.LeftAlt;
            if (rAlt) result |= Modifier.RightAlt;
            if (lCtrl) result |= Modifier.LeftCtrl;
            if (rCtrl) result |= Modifier.RightCtrl;
            if (lWin) result |= Modifier.LeftWin;
            if (rWin) result |= Modifier.RightWin;
            return result;
        }
    }
}
