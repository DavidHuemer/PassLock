using PassLock.Handler.IO.InstallationHandler;
using System.Threading.Tasks;

namespace PassLock.GUI.ViewModels.Startup.Installation
{
    public class NpmInstallationViewModel : BaseInstallationViewModel
    {
        private const string TITLE = "Install NPM";
        private const string URI = "pack://application:,,,/PassLock.GUI;component/Resources/Icons/npm_icon.svg";
        private const string COMMAND = NPMInstallationHandler.NPM_INSTALLATION_COMMAND;
        private const string DETAIL = "Installs the required node cli";

        public NpmInstallationViewModel(NPMInstallationHandler handler) : base(handler, TITLE, URI, COMMAND, DETAIL)
        {

        }
    }
}
