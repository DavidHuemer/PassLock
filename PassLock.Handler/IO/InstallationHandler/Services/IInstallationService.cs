using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Handler.IO.InstallationHandler.Services
{
    public interface IInstallationService
    {
        Task<CommandResult> RunIsCommandInstalled(string batchPath);

        Task<CommandResult> RunInstallCommand(string command);
    }
}
