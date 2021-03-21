using PassLock.Handler.CommandLineHandler;
using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Handler.IO.InstallationHandler.Services
{
    public class InstallationService : IInstallationService
    {
        public async Task<CommandResult> RunInstallCommand(string command)
        {
            var result = await CommandHandler.RunCommandAsync(command);
            return result;
        }

        public async Task<CommandResult> RunIsCommandInstalled(string command)
        {
            var result = await CommandHandler.RunCommandAsync(command);
            return result;
        }
    }
}
