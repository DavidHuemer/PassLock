using PassLock.GUI.Windows.StartupWindows.InstallerWindows;
using PassLock.Handler.IO.InstallationHandler;
using PassLock.Handler.IO.InstallationHandler.Services;
using System.Threading.Tasks;

namespace PassLock.Manager.StartupManagers.Installation
{
    public class NpmInstallationManager
    {
        private static NpmInstallationManager instance = null;
        public static NpmInstallationManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new NpmInstallationManager();
                return instance;
            }
        }

        private static NPMInstallationHandler npmInstallationHandler;

        private NpmInstallationManager()
        {
            npmInstallationHandler = new NPMInstallationHandler(new InstallationService());
        }


        public bool Install()
        {
            var window = new NpmInstallationWindow(npmInstallationHandler);
            return window.Install();
        }

        public async Task<bool> IsInstalled()
        {
            return await npmInstallationHandler.IsInstalled();
        }
    }
}
