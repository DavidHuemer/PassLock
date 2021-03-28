using PassLock.Bitwarden.Data.Data.Objects.Items.Options;
using System.Collections.Generic;

namespace PassLock.Bitwarden.Data.Data.Objects.Items
{
    public abstract class BitwardenItem : BitwardenObject
    {
        public bool Favorite { get; set; }
        public string Notes { get; set; }
        public List<BitwardenItemField> Fields { get; set; }
    }
}
