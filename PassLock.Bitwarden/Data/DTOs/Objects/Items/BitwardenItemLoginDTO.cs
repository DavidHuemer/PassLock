using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Objects.Items.Options;
using System.Collections.Generic;
using System.Linq;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenItemLoginDTO : BaseDTO<BitwardenItemLogin>
    {
        public List<BitwardenUriDTO> Uris { get; set; } = new List<BitwardenUriDTO>();
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;

        public override BitwardenItemLogin ConvertBack()
        {
            return new BitwardenItemLogin
            {
                Uris = Uris.Select(x => x.ConvertBack()).ToList(),
                Username = Username,
                Password = Password,
            };
        }
    }
}
