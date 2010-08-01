using System;
using System.Windows.Forms;
using System.Threading;

namespace Wlipper
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Single instance only allowed
            bool firstInstance = false;
            Mutex mutex = new Mutex(false, Application.ProductName, out firstInstance);

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new WlipperForm();
                Application.Run();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
