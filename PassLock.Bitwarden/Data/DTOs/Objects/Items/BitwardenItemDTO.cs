using PassLock.Bitwarden.Converter.ObjectConverters;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using System.Collections.Generic;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenItemDTO : BitwardenObjectDTO<BitwardenItem>
    {
        #region Properties

        //These properties are defined in all items
        public string OrganizationId { get; set; } = null;
        public string FolderId { get; set; } = null;
        public int Type { get; set; } = 1;
        public string Notes { get; set; } = "";
        public bool Favorite { get; set; } = false;
        public List<BitwardenItemFieldDTO> Fields { get; set; }
        public List<string> CollectionIds { get; set; } = new List<string>();
        public string RevisionDate { get; set; }

        //Optional objects
        public BitwardenItemLoginDTO Login { get; set; } = null;
        public SecureNote SecureNote { get; set; } = null;
        public BitwardenItemIdentityDTO Identity { get; set; } = null;
        public BitwardenItemCardDTO Card { get; set; } = null;

        #endregion

        public override BitwardenItem ConvertBack()
        {
            return BitwardenItemDtoToItemConverter.Convert(this);
        }
    }
}
