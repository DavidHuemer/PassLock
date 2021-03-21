using PassLock.Handler.CommandLineHandler.Data;
using PassLock.Handler.IO.InstallationHandler.Services;
using System.Threading.Tasks;

namespace PassLock.Handler.IO.InstallationHandler
{
    public abstract class BaseInstallationHandler
    {
        protected readonly IInstallationService installationService;

        public BaseInstallationHandler(IInstallationService installationService)
        {
            this.installationService = installationService;
        }

        public abstract Task Install();

        public abstract Task<bool> IsInstalled();

        /// <summary>
        /// Checks if a command is installed by a batch file
        /// </summary>
        /// <param name="command">The command that checks if the command is installed</param>
        /// <returns>Returns if the command is installed or not</returns>
        protected async Task<bool> IsCommandInstalled(string command)
        {
            return await IsCommandInstalled(command, installationService);
        }

        /// <summary>
        /// Checks if a command is installed by a batch file
        /// </summary>
        /// <param name="command">The command that checks if the command is installed</param>
        /// <returns>Returns if the command is installed or not</returns>
        protected static async Task<bool> IsCommandInstalled(string command, IInstallationService installationService)
        {
            var result = await installationService.RunIsCommandInstalled(command);
            if (result.Status != CommandStatus.Success)
                return false;

            return ParseResult(result.Output);
        }

        /// <summary>
        /// Parses the result from the command line to a boolean
        /// </summary>
        /// <param name="original">The original output of the command line</param>
        /// <returns>The parsed value</returns>
        private static bool ParseResult(string original)
        {
            try
            {
                var lines = original
                            .Trim()
                            .Split(new[] { '\r', '\n' });

                string result = lines[lines.Length - 1];
                return bool.Parse(result);
            }
            catch
            {
                return false;
            }
        }
    }
}
