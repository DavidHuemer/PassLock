using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Services;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Manager
{
    public sealed class BitwardenAuthManager
    {

        public static async Task<BitwardenAuthStatus> GetAuthStatus()
        {
            var handler = new BitwardenAuthHandler(new BitwardenAuthService());
            return await handler.GetAuthStatus();
        }

        //public static void Login(string username, string password)
        //{
        //    Logout();
        //}

        //public static void Logout()
        //{

        //}

        public static async Task<LoginResult> Unlock(string password)
        {
            var handler = new BitwardenAuthHandler(new BitwardenAuthService());
            return await handler.Unlock(password);
        }

        //public static void Lock()
        //{

        //}
    }
}
