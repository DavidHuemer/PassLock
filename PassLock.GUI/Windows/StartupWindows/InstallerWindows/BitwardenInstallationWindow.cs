using PassLock.GUI.ViewModels.Startup.Installation;
using PassLock.Handler.IO.InstallationHandler;
using PassLock.Handler.IO.InstallationHandler.Services;

namespace PassLock.GUI.Windows.StartupWindows.InstallerWindows
{
    public class BitwardenInstallationWindow : BaseInstallationWindow
    {
        public BitwardenInstallationWindow(BitwardenInstallationHandler installationHandler) : base(new BitwardenInstallationViewModel(installationHandler))
        {
            
        }
    }
}
