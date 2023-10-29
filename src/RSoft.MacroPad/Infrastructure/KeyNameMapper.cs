using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Input.KeyboardAndMouse;

namespace RSoft.MacroPad.Infrastructure
{
    public class KeyNameMapper
    {
        public static string GetLocalizedKeyString(Keys key)
        {
            switch (key)
            {
                case Keys.None: return "";
                case Keys.Pause: return "Pause/Break";
                case Keys.LWin:
                case Keys.RWin: return "Windows";
            }
            // strip any modifier keys
            uint keyCode = (uint)key & 0xffff;
            uint scanCode = PInvoke.MapVirtualKey(keyCode, MAP_VIRTUAL_KEY_TYPE.MAPVK_VK_TO_VSC);
            var wmEvent = Extern.ToWmKeyDownEvent(scanCode, keyCode);
            unsafe
            {
                var s = new String(' ', 32).ToCharArray();
                fixed (char* sptr = s) {
                    var sb = new PWSTR(sptr);

                    PInvoke.GetKeyNameText((int)wmEvent, sb, sb.Length);
                    return sb.ToString();
                }
            }
        }

        public static string GetKeySymbol(Keys key)
        {
            switch (key)
            {
                case Keys.LControlKey:
                case Keys.RControlKey:
                    return "Ctrl";
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                    return "⇑";
                case Keys.LMenu:
                    return "Alt";
                case Keys.RMenu:
                    return "AltGr";
                case Keys.LWin:
                case Keys.RWin:
                    return "Win";
                case Keys.Left: return "←";
                case Keys.Right: return "→";
                case Keys.Up: return "↑";
                case Keys.Down: return "↓";
                case Keys.Tab: return "↦";
                case Keys.CapsLock: return "↥";
                case Keys.NumLock: return "Num Lk";
                case Keys.Scroll: return "Scrl Lk";
                case Keys.PrintScreen: return "Prnt Scr";
                   
                case Keys.Escape: return "Esc";
                case Keys.Back: return "↤";
                case Keys.Enter: 
                    return "⏎";
                case Keys.Apps: return "▤";
                case Keys.PageUp: return "PgUp";
                case Keys.PageDown: return "PgDn";
                case Keys.Insert: return "Ins";
                case Keys.Delete: return "Del";
                case Keys.Home: return "Home";
                case Keys.End: return "End";
                case Keys.NumPad0: return "0";
                case Keys.NumPad1: return "1";
                case Keys.NumPad2: return "2";
                case Keys.NumPad3: return "3";
                case Keys.NumPad4: return "4";
                case Keys.NumPad5: return "5";
                case Keys.NumPad6: return "6";
                case Keys.NumPad7: return "7";
                case Keys.NumPad8: return "8";
                case Keys.NumPad9: return "9";
                case Keys.Divide: return "/";
                case Keys.Multiply: return "*";
                case Keys.Subtract: return "-";
                case Keys.Add: return "+";
                case Keys.Decimal: return CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;
                case Keys.None: return "";
                case Keys.Pause: return "Brk";
                case Keys.Space: return "";
                default:
                    var s = GetLocalizedKeyString(key);
                    return (s.Length > 5 ? s.Substring(0,5) : s).ToUpperInvariant();

            }
        }
    }
}