using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using RSoft.MacroPad.Forms;

namespace RSoft.MacroPad
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler(Program.Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run((Form)new MainForm());
            }
            catch (Exception ex)
            {
                HandleException("Main()", ex);
            }
        }


        static void HandleException(string header, Exception ex)
        {
            string str1 = "Exception：" + DateTime.Now.ToString() + " at "+header+"\r\n";
            string str2 = ex == null
                ? $"NULL: {ex}"
                : $"{ex.GetType()}\r\n{ex.Message}\r\n{ex.StackTrace}\r\n\r\n";
            File.AppendAllText("error.log", $"[{DateTime.Now.ToString("g")}] {str1}{str2}");
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) 
            => HandleException($"Application_Thread ({sender})", e.Exception);

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
            => HandleException($"CurrentDomain ({sender})", e.ExceptionObject as Exception);
    }
}
