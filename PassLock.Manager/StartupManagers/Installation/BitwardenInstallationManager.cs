using PassLock.GUI.Windows.StartupWindows.InstallerWindows;
using PassLock.Handler.IO.InstallationHandler;
using PassLock.Handler.IO.InstallationHandler.Services;
using System.Threading.Tasks;

namespace PassLock.Manager.StartupManagers.Installation
{
    public class BitwardenInstallationManager
    {
        private static BitwardenInstallationManager instance = null;
        public static BitwardenInstallationManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new BitwardenInstallationManager();
                return instance;
            }
        }


        private static BitwardenInstallationHandler bitwardenInstallationHandler;

        private BitwardenInstallationManager()
        {
            bitwardenInstallationHandler = new BitwardenInstallationHandler(new InstallationService());
        }

        public bool Install()
        {
            var window = new BitwardenInstallationWindow(bitwardenInstallationHandler);
            return window.Install();
        }

        public async Task<bool> IsInstalled()
        {
            return await bitwardenInstallationHandler.IsInstalled();
        }
    }
}
