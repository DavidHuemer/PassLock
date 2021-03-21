using PassLock.GUI.ViewModels.Startup.Installation;
using PassLock.Handler.IO.InstallationHandler;
using System;

namespace PassLock.GUI.Windows.StartupWindows.InstallerWindows
{
    public class NpmInstallationWindow : BaseInstallationWindow
    {
        public NpmInstallationWindow(NPMInstallationHandler installationHandler): base(new NpmInstallationViewModel(installationHandler))
        {

        }
    }
}
