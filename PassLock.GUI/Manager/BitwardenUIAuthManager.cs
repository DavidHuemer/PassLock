using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Manager;
using PassLock.GUI.Windows.StartupWindows;
using System;
using System.Threading.Tasks;

namespace PassLock.GUI.Manager
{
    public class BitwardenUIAuthManager
    {
        public static async Task<LoginResult> Login()
        {
            var authStatus = await BitwardenAuthManager.GetAuthStatus();

            if(authStatus.Status == BitwardenStatus.Unlocked)
            {
                //Login finished
                return LoginResult.CreateSucess(authStatus.UserEmail);
            }

            var loginResult = new LoginWindow().Open(authStatus);
            return loginResult;
        }
    }
}
