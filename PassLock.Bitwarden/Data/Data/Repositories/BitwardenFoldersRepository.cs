using Newtonsoft.Json;
using PassLock.Bitwarden.Data.Data.Objects.Folders;
using PassLock.Bitwarden.Data.DTOs.Objects.Folders;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Data.Data.Repositories
{
    public class BitwardenFoldersRepository : BaseRepository<BitwardenFolder>
    {
        #region Singleton

        private static BitwardenFoldersRepository instance;
        public static BitwardenFoldersRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new BitwardenFoldersRepository();
                return instance;
            }
        }

        private BitwardenFoldersRepository()
        {

        }

        #endregion

        public override async Task<List<BitwardenFolder>> LoadItems()
        {
            var result = await service.LoadItems();
            if (result.Status != CommandStatus.Success)
                throw new ArgumentException($"Error loading folders: {result.Output}");

            var dtos = JsonConvert.DeserializeObject<List<BitwardenFolderDTO>>(result.Output);
            return dtos.Select(x => x.ConvertBack()).ToList();
        }
    }
}
