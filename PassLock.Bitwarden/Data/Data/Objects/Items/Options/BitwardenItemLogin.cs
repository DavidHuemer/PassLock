using System.Collections.Generic;

namespace PassLock.Bitwarden.Data.Data.Objects.Items.Options
{
    public class BitwardenItemLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<BitwardenItemUri> Uris { get; set; }
    }
}
