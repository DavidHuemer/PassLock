using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.Data.Objects.Items
{
    public class IdentityItem : BitwardenItem
    {
        public BitwardenIdentity Identity { get; set; } = null;
    }
}
