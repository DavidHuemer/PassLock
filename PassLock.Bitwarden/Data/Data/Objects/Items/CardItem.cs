using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.Data.Objects.Items
{
    public class CardItem : BitwardenItem
    {
        public BitwardenCard Card { get; set; } = null;
    }
}
