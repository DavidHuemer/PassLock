using PassLock.Bitwarden.Data.Data.Authentication;
using System;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Handler
{
    public static class BitwardenLoginHandler
    {
        private static BitwardenAuthHandler authHandler;

        public static async Task<LoginResult> LoginByAuthStatus(BitwardenAuthHandler bitwardenAuthHandler, string email, string password)
        {
            authHandler = bitwardenAuthHandler;
            var authStatus = await authHandler.GetAuthStatus();

            try
            {
                switch (authStatus.Status)
                {
                    case BitwardenStatus.Logout:
                        //Need email and password
                        return await FullLogin(email, password);
                    case BitwardenStatus.Locked:
                        return await LoginLocked(authStatus, email, password);
                    case BitwardenStatus.Unlocked:
                        return await LoginUnlocked(authStatus, email, password);
                    default:
                        throw new ArgumentException($"The status {authStatus.Status} does not exist");
                }
            }
            catch(Exception ex)
            {
                return LoginResult.CreateFailed(ex.Message);
            }
            finally
            {
                authHandler = null;
            }
        }

        private static async Task<LoginResult> LoginLocked(BitwardenAuthStatus authStatus, string email, string password)
        {
            if (email == authStatus.UserEmail)
            {
                //Login finished
                return await Unlock(password);
            }
            else
            {
                return await LogoutLogin(email, password);
            }
        }

        private static async Task<LoginResult> LoginUnlocked(BitwardenAuthStatus authStatus, string email, string password)
        {
            if (email == authStatus.UserEmail)
            {
                //Login finished
                return LoginResult.CreateSucess(authStatus.UserEmail);
            }
            else
            {
                return await LogoutLogin(email, password);
            }
        }

        private static async Task<LoginResult> LogoutLogin(string email, string password)
        {
            await authHandler.Logout();
            return await FullLogin(email, password);
        }

        private static async Task<LoginResult> FullLogin(string email, string password)
        {
            var loginResult = await authHandler.Login(email, password);
            if (loginResult.IsLoggedIn)
            {
                return await Unlock(password);
            }

            return loginResult;
        }

        private static async Task<LoginResult> Unlock(string password)
        {
            return await authHandler.Unlock(password);
        }
    }
}
