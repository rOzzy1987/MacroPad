using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RSoft.MacroPad.Controls;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Foundation;

namespace RSoft.MacroPad.Infrastructure
{
    public class KeyboardHook : IDisposable
    {


        //Declaring Global objects
        private UnhookWindowsHookExSafeHandle ptrHook;
        private HOOKPROC objKeyboardProcess;

        public event KeyboardHookHandler OnKeyPressRelease;

        public bool BlockFurtherHooks { get; set; }

        public KeyboardHook()
        {
            SetHook();
        }

        private void SetHook()
        {
            if(ptrHook != null) {
                ptrHook.Dispose();
            }
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule; //Get Current Module
            objKeyboardProcess = new HOOKPROC(CaptureKey); //Assign callback function each time keyboard process
            var mHandle = PInvoke.GetModuleHandle(objCurrentModule.ModuleName);
            ptrHook = PInvoke.SetWindowsHookEx(WINDOWS_HOOK_ID.WH_KEYBOARD_LL, objKeyboardProcess, mHandle, 0); //Setting Hook of Keyboard Process for current module
        }

        private LRESULT CaptureKey(int nCode, WPARAM wp, LPARAM lp)
        {
            if (nCode >= 0)
            {
                var keyInfo = (KeyInfo)Marshal.PtrToStructure(lp, typeof(KeyInfo));
                //keyInfo.scanCode = PInvoke.MapVirtualKeyW((uint)keyInfo.key, MAPVK.MAPVK_VK_TO_VSC);
                Console.WriteLine(keyInfo);
                foreach(var i in OnKeyPressRelease.GetInvocationList().Cast<KeyboardHookHandler>())
                {
                    if (!i.Invoke(keyInfo))
                    {
                        return new LRESULT((IntPtr)1);
                    }
                }
            }
            return PInvoke.CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        public void Dispose()
        {
            if (!ptrHook?.IsClosed ?? false)
            {
                ptrHook.Dispose();
                ptrHook = null;
            }
        }

        #region Externals
        #endregion
    }

    public delegate bool KeyboardHookHandler(KeyInfo keyInfo);
}
