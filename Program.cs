using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new WlipperForm();
            Application.Run();
        }
    }
}
