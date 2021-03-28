using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services.Interfaces
{
    public interface IBitwardenObjectsService
    {
        Task<CommandResult> LoadItems();
    }
}
