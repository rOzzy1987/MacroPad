using System;

namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    [Flags]
    public enum Modifier : byte
    {
        Ctrl = 1,
        Shift = 1 << 1,
        Alt = 1 << 2,
        Win = 1 << 3,

        LeftCtrl = 1,
        LeftShift = 1 << 1,
        LeftAlt = 1 << 2,
        LeftWin = 1 << 3,

        RightCtrl = 1 << 4,
        RightShift = 1 << 5,
        RightAlt = 1 << 6,
        RightWin = 1 << 7,

        None = 0
    }
}
