using PassLock.Handler.IO.InstallationHandler.Services;
using System;
using System.Threading.Tasks;

namespace PassLock.Handler.IO.InstallationHandler
{
    public class NPMInstallationHandler : BaseInstallationHandler
    {
        public const string NPM_INSTALLATION_CHECK_COMMAND = "@echo off npm -v >nul 2>&1 && (echo true) || (echo false)";
        public const string NPM_INSTALLATION_COMMAND = "https://nodejs.org/en/";

        public NPMInstallationHandler(IInstallationService installationService) : base(installationService)
        {

        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async override Task Install()
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var destinationurl = NPM_INSTALLATION_COMMAND;
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        public override async Task<bool> IsInstalled()
        {
            return await IsCommandInstalled(NPM_INSTALLATION_CHECK_COMMAND);
        }

        public async Task<bool> IsInstalled(IInstallationService installationService)
        {
            return await IsCommandInstalled(installationService, NPM_INSTALLATION_CHECK_COMMAND);
        }

        private static Task<bool> IsCommandInstalled(IInstallationService installationService, string nPM_INSTALLATION_CHECK_COMMAND)
        {
            throw new NotImplementedException();
        }
    }
}
