using PassLock.Handler.IO.InstallationHandler;
using System.Threading.Tasks;

namespace PassLock.GUI.ViewModels.Startup.Installation
{
    public class BitwardenInstallationViewModel : BaseInstallationViewModel
    {
        private const string TITLE = "Install Bitwarden";
        private const string URI = "pack://application:,,,/PassLock.GUI;component/Resources/Icons/bitwarden_icon.svg";
        private const string COMMAND = BitwardenInstallationHandler.BITWARDEN_INSTALLATION_COMMAND;
        private const string DETAIL = "Installs the required bitwarden cli";

        public BitwardenInstallationViewModel(BitwardenInstallationHandler handler) : base(handler, TITLE, URI, COMMAND, DETAIL)
        {

        }
    }
}
