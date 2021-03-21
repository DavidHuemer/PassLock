using PassLock.Bitwarden.Data.Data.Items;
using PassLock.Bitwarden.Data.DTOs.Items;
using System.Collections.Generic;
using System.Linq;

namespace PassLock.Bitwarden.Converter
{
    public static class BitwardenItemsDTOConverter
    {
        public static List<BitwardenItem> ConvertyItemsByDTOs(List<BitwardenItemDTO> itemDTOs)
        {
            return itemDTOs
                .Where(x => x.Type == 1)
                .Select(x => x.ConvertBack())
                .ToList();
        }
    }
}
