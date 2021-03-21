using PassLock.Bitwarden.Data.Data.Authentication;
using System;

namespace PassLock.Bitwarden.Converter
{
    public class BitwardenStatusConverter
    {
        private const string LOGOUT = "unauthenticated";
        private const string LOCKED = "locked";
        private const string UNLOCKED = "unlocked";

        public static BitwardenStatus Convert(string strStatus)
        {
            switch (strStatus)
            {
                case LOGOUT:
                    return BitwardenStatus.Logout;
                case LOCKED:
                    return BitwardenStatus.Locked;
                case UNLOCKED:
                    return BitwardenStatus.Unlocked;
                default:
                    throw new ArgumentException($"The status {strStatus} is not known");
            }
        }
    }
}
