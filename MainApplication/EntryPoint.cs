using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TextToScreen.Misc;
using TextToScreen.Windows;

namespace TextToScreen
{
    internal static class EntryPoint
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute) assembly.GetCustomAttributes(typeof (GuidAttribute), true)[0];
            var guid = attribute.Value;

            var mutex = new Mutex(true, guid);

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                CultureConfigurator.SetupCulture();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBoxes.ApplicationAlreadyRunningInfo();
            }
        }
    }
}