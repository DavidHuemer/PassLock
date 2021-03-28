using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenUriDTO : BaseDTO<BitwardenItemUri>
    {
        public string Url { get; set; }

        public override BitwardenItemUri ConvertBack()
        {
            return new BitwardenItemUri
            {
                Url = Url
            };
        }
    }
}
