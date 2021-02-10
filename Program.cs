using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerVanzari.Services;
using ManagerVanzari.Views;
using ManagerVanzari.Controllers;

namespace ManagerVanzari
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool MVOpen = false;

            using (Mutex mutex = new Mutex(true, "ManagerVanzari", out MVOpen))
            {

                if (MVOpen)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    //unique instance of DB Service
                    Service Service = Service.Instance;

                    //Starting view
                    HomePage HomeView = new HomePage();

                    //main views controllers
                    HomePageController HomeViewController = new HomePageController(ref Service, HomeView);
                    VanzariAziController VanzariAziViewController = new VanzariAziController(ref Service);

                    HomeViewController.Home_VanzariAziViewController = VanzariAziViewController;

                    Application.Run(HomeViewController.getView());

                    mutex.ReleaseMutex();

                }
                else
                {
                    MessageBox.Show("Aplicatia Manager Vanzari ruleaza!", "Aplicatia este deja deschisa!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }
    }
}



