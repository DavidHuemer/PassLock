using PassLock.Handler.IO.InstallationHandler.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PassLock.Handler.IO.InstallationHandler
{
    public class BitwardenInstallationHandler : BaseInstallationHandler
    {
        public const string BITWARDEN_INSTALLATION_CHECK_COMMAND = "@echo off bw --help >nul 2>&1 && (echo true) || (echo false)";
        public const string BITWARDEN_INSTALLATION_COMMAND = "npm install -g @bitwarden/cli";

        public BitwardenInstallationHandler(IInstallationService installationService) : base(installationService)
        {
            
        }

        public async override Task Install()
        {
            await installationService.RunInstallCommand(BITWARDEN_INSTALLATION_COMMAND);
        }

        public override async Task<bool> IsInstalled()
        {
            return await IsCommandInstalled(BITWARDEN_INSTALLATION_CHECK_COMMAND);
        }
    }
}
