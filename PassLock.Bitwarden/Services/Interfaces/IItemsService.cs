using PassLock.Handler.CommandLineHandler.Data;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Services.Interfaces
{
    public interface IItemsService
    {
        Task<CommandResult> Sync();

        Task<CommandResult> LoadItems();
    }
}
