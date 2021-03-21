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

            new LoginWindow().Open(authStatus);
            return null;

            //switch (authStatus.Status)
            //{
            //    case BitwardenStatus.Unlocked:
            //        //Login finished
            //        return new LoginResult
            //        {
            //            IsLoggedIn = true,
            //            UserEmail = authStatus.UserEmail,
            //            UserId = authStatus.UserId
            //        };
            //    case BitwardenStatus.Locked:
            //        //Need password
            //        return null;
            //    case BitwardenStatus.Logout:
            //        //Need email and password
            //        return null;
            //    default:
            //        throw new ArgumentException($"The status {authStatus.Status} does not exist");
            //}
        }
    }
}
