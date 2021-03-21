using System;

namespace PassLock.Bitwarden.Data.Data.Authentication
{
    public class BitwardenAuthStatus
    {
        public string ServerUrl { get; set; }
        public DateTime? LastSync { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public BitwardenStatus Status { get; set; }
    }
}
