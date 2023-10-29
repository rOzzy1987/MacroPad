namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    /// <summary>
    /// KeyCodes used by the communication protocol. Sadly it neither matches the virtual key codes, nor the hardware scan codes. 
    /// </summary>
    public enum KeyCode : byte
    {
        [VirtualKeyMap(VirtualKey.A)] A = 4,
        [VirtualKeyMap(VirtualKey.B)] B = 5,
        [VirtualKeyMap(VirtualKey.C)] C = 6,
        [VirtualKeyMap(VirtualKey.D)] D = 7,
        [VirtualKeyMap(VirtualKey.E)] E = 8,
        [VirtualKeyMap(VirtualKey.F)] F = 9,
        [VirtualKeyMap(VirtualKey.G)] G = 10,
        [VirtualKeyMap(VirtualKey.H)] H = 11,
        [VirtualKeyMap(VirtualKey.I)] I = 12,
        [VirtualKeyMap(VirtualKey.J)] J = 13,
        [VirtualKeyMap(VirtualKey.K)] K = 14,
        [VirtualKeyMap(VirtualKey.L)] L = 15,
        [VirtualKeyMap(VirtualKey.M)] M = 16,
        [VirtualKeyMap(VirtualKey.N)] N = 17,
        [VirtualKeyMap(VirtualKey.O)] O = 18,
        [VirtualKeyMap(VirtualKey.P)] P = 19,
        [VirtualKeyMap(VirtualKey.Q)] Q = 20,
        [VirtualKeyMap(VirtualKey.R)] R = 21,
        [VirtualKeyMap(VirtualKey.S)] S = 22,
        [VirtualKeyMap(VirtualKey.T)] T = 23,
        [VirtualKeyMap(VirtualKey.U)] U = 24,
        [VirtualKeyMap(VirtualKey.V)] V = 25,
        [VirtualKeyMap(VirtualKey.W)] W = 26,
        [VirtualKeyMap(VirtualKey.X)] X = 27,
        [VirtualKeyMap(VirtualKey.Y)] Y = 28,
        [VirtualKeyMap(VirtualKey.Z)] Z = 29,
        [VirtualKeyMap(VirtualKey.D1)] D1 = 30, // Number row
        [VirtualKeyMap(VirtualKey.D2)] D2 = 31, // Number row
        [VirtualKeyMap(VirtualKey.D3)] D3 = 32, // Number row
        [VirtualKeyMap(VirtualKey.D4)] D4 = 33, // Number row
        [VirtualKeyMap(VirtualKey.D5)] D5 = 34, // Number row
        [VirtualKeyMap(VirtualKey.D6)] D6 = 35, // Number row
        [VirtualKeyMap(VirtualKey.D7)] D7 = 36, // Number row
        [VirtualKeyMap(VirtualKey.D8)] D8 = 37, // Number row
        [VirtualKeyMap(VirtualKey.D9)] D9 = 38, // Number row
        [VirtualKeyMap(VirtualKey.D0)] D0 = 39, // Number row
        [VirtualKeyMap(VirtualKey.Enter)] Enter = 40, // "Enter"
        [VirtualKeyMap(VirtualKey.Escape)] Esc = 41, // "ESC"
        [VirtualKeyMap(VirtualKey.Back)] Backspace = 42, // "
        [VirtualKeyMap(VirtualKey.Tab)] Tab = 43, // "Tab"
        [VirtualKeyMap(VirtualKey.Space)] SpaceKey = 44, // Space"
        [VirtualKeyMap(VirtualKey.OemMinus)] Minus = 45, // "￣－"
        [VirtualKeyMap(VirtualKey.Oemplus)] Plus = 46, // "+="
        [VirtualKeyMap(VirtualKey.OemOpenBrackets)] OpenBracket = 47, // "{["
        [VirtualKeyMap(VirtualKey.OemCloseBrackets)] CloseBracket = 48, // "}]"
        [VirtualKeyMap(VirtualKey.OemPipe)] Pipe = 49, // "|\"
        [VirtualKeyMap(VirtualKey.Oemtilde)] Tilde = 53, // "~、"
        [VirtualKeyMap(VirtualKey.OemSemicolon)] Colon = 51, // ":;"
        [VirtualKeyMap(VirtualKey.OemBackslash)] Backslash = 52, // ""'"
        [VirtualKeyMap(VirtualKey.Oemcomma)] Clear = 54, // "<,"
        [VirtualKeyMap(VirtualKey.OemPeriod)] Period = 55, // ">."
        [VirtualKeyMap(VirtualKey.OemQuestion)] Question = 56, // "?/"
        [VirtualKeyMap(VirtualKey.CapsLock)] CapsLock = 57, // "CapsLock"
        [VirtualKeyMap(VirtualKey.F1)] F1 = 58, // "F1"
        [VirtualKeyMap(VirtualKey.F2)] F2 = 59, // "F2"
        [VirtualKeyMap(VirtualKey.F3)] F3 = 60, // "F3"
        [VirtualKeyMap(VirtualKey.F4)] F4 = 61, // "F4"
        [VirtualKeyMap(VirtualKey.F5)] F5 = 62, // "F5"
        [VirtualKeyMap(VirtualKey.F6)] F6 = 63, // "F6"
        [VirtualKeyMap(VirtualKey.F7)] F7 = 64, // "F7"
        [VirtualKeyMap(VirtualKey.F8)] F8 = 65, // "F8"
        [VirtualKeyMap(VirtualKey.F9)] F9 = 66, // "F9"
        [VirtualKeyMap(VirtualKey.F10)] F10 = 67, // "F10"
        [VirtualKeyMap(VirtualKey.F11)] F11 = 68, // "F11"
        [VirtualKeyMap(VirtualKey.F12)] F12 = 69, // "F12"
        [VirtualKeyMap(VirtualKey.PrintScreen)] PrtSc = 70, // "PrtSc"
        [VirtualKeyMap(VirtualKey.Scroll)] ScrollLock = 71, // "ScLock"
        [VirtualKeyMap(VirtualKey.Pause)] PauseBreak = 72, // "PaBk"
        [VirtualKeyMap(VirtualKey.Insert)] Insert = 73, // "Ins"
        [VirtualKeyMap(VirtualKey.Home)] Home = 74, // "Home"
        [VirtualKeyMap(VirtualKey.PageUp)] PgUp = 75, // "PageUp"
        [VirtualKeyMap(VirtualKey.Delete)] Del = 76, // "Delete"
        [VirtualKeyMap(VirtualKey.End)] End = 77, // "End"
        [VirtualKeyMap(VirtualKey.PageDown)] PgDn = 78, // "PageDown"
        [VirtualKeyMap(VirtualKey.Right)] ArrowRight = 79, // "→"
        [VirtualKeyMap(VirtualKey.Left)] ArrowLeft = 80, // "←"
        [VirtualKeyMap(VirtualKey.Down)] ArrowDown = 81, // "↓"
        [VirtualKeyMap(VirtualKey.Up)] ArrowUp = 82, // "↑"
        [VirtualKeyMap(VirtualKey.NumLock)] Num = 83, // "NumLock"
        [VirtualKeyMap(VirtualKey.Divide)] NumDiv = 84, // "÷"
        [VirtualKeyMap(VirtualKey.Multiply)] NumMul = 85, // "×"
        [VirtualKeyMap(VirtualKey.Subtract)] NumSub = 86, // "－"
        [VirtualKeyMap(VirtualKey.Add)] NumAdd = 87, // "＋"
        [VirtualKeyMap(VirtualKey.NumPad1)] Num1 = 89, // "1"
        [VirtualKeyMap(VirtualKey.NumPad2)] Num2 = 90, // "2"
        [VirtualKeyMap(VirtualKey.NumPad3)] Num3 = 91, // "3"
        [VirtualKeyMap(VirtualKey.NumPad4)] Num4 = 92, // "4"
        [VirtualKeyMap(VirtualKey.NumPad5)] Num5 = 93, // "5"
        [VirtualKeyMap(VirtualKey.NumPad6)] Num6 = 94, // "6"
        [VirtualKeyMap(VirtualKey.NumPad7)] Num7 = 95, // "7"
        [VirtualKeyMap(VirtualKey.NumPad8)] Num8 = 96, // "8"
        [VirtualKeyMap(VirtualKey.NumPad9)] Num9 = 97, // "9"
        [VirtualKeyMap(VirtualKey.NumPad0)] Num0 = 98, // "0"
        [VirtualKeyMap(VirtualKey.Decimal)] NumDec = 99, // "▪"
        [VirtualKeyMap(VirtualKey.Return)] NumEnter = 100, // "▪"
        [VirtualKeyMap(VirtualKey.Apps)] App = 101, // "▤"
        [VirtualKeyMap(VirtualKey.Oem5)] IsoPlus1= 102, // sometimes \ other times < on ISO layouts
        [VirtualKeyMap(VirtualKey.None)] None = 0,
    }
}