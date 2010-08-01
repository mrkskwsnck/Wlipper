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
            string mutexName = string.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
            Mutex mutex = new Mutex(false, mutexName, out firstInstance);

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new WlipperForm();
                Application.Run();
            }
            else
            {
                MessageBox.Show(string.Format(Localization.INSTANCE_RUNNING, Application.ProductName, Application.ProductVersion), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
    }
}
