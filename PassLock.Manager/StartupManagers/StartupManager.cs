using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Manager;
using PassLock.Bitwarden.Services;
using PassLock.GUI.Manager;
using PassLock.GUI.Windows;
using PassLock.Handler.Data.Diagnostics;
using PassLock.Handler.Data.Startup;
using PassLock.Manager.StartupManagers.Installation;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PassLock.Manager.StartupManagers
{
    public class StartupManager
    {
        public static async void Startup(AppSettings appSettings)
        {
            Console.WriteLine($"****** Startup begin ******");
            var timer = new ExecutionTimer(true);

            try
            {
                await RunStartup(appSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                timer.StopAndWrite();
                Console.WriteLine($"****** Startup ending ******");
            }
        }

        private static async Task RunStartup(AppSettings appSettings)
        {
            //1. Check Installations
            await CheckInstallations(appSettings);

            //2. Login
            var loginResult = await LoginManager.Login(appSettings);

            if (loginResult.IsLoggedIn)
            {
                BitwardenItemsManager.Init(new BitwardenItemsService());
                await BitwardenItemsManager.SyncAndLoad();
                MainWindow.Instance.Show();
            }
        }

        /// <summary>
        /// Checks the installations of the required packages (bitwarden, npm)
        /// </summary>
        /// <returns></returns>
        private static async Task CheckInstallations(AppSettings appSettings)
        {
            bool checkInstallations = bool.Parse(appSettings.GetByKey(AppSetting.CheckInstallations));
            if (!checkInstallations)
                return;

            var timer = new ExecutionTimer(true);
            var installationSuccess = await InstallationManager.CheckInstallations();
            timer.StopAndWrite();
            if (!installationSuccess.Sucess)
            {
                throw new ArgumentException($"The Installation of the following software failed: {installationSuccess}");
            }
        }
    }
}
