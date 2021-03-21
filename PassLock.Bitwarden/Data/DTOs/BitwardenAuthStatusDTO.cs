using PassLock.Bitwarden.Converter;
using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Authentication;
using System;

namespace PassLock.Bitwarden.Data.DTOs
{
    public class BitwardenAuthStatusDTO : BaseDTO<BitwardenAuthStatus>
    {
        public string ServerUrl { get; set; }
        public string LastSync { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }

        public override BitwardenAuthStatus ConvertBack()
        {
            var status = new BitwardenAuthStatus
            {
                ServerUrl = ServerUrl,
                UserEmail = UserEmail,
                UserId = UserId,
                Status = BitwardenStatusConverter.Convert(Status)
            };

            if (LastSync == null)
            {
                status.LastSync = null;
            }
            else
            {
                status.LastSync = DateTime.Parse(LastSync);
            }

            return status;
        }
    }
}
