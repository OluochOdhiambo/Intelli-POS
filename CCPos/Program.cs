using CCPos.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCPos
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Render the splash screen
            //frmSplashScreen splash = new frmSplashScreen();
            //splash.ShowDialog();

            Application.Run(new frmDashboard());
        }
    }
}
