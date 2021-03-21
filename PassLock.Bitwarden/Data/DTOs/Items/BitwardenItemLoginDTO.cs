using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Data.DTOs.Items
{
    public class BitwardenItemLoginDTO : BaseDTO<BitwardenItemLogin>
    {
        public List<BitwardenUriDTO> Uris { get; set; } = new List<BitwardenUriDTO>();
        public string Username { get; set; }
        public string Password { get; set; }

        public override BitwardenItemLogin ConvertBack()
        {
            return new BitwardenItemLogin
            {
                Uris = Uris.Select(x => x.Uri).ToList(),
                Username = Username,
                Password = Password,
                
            };
        }
    }
}
