using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Handler
{
    public abstract class BitwardenLoginHandler
    {
        public async Task<LoginResult> LoginByAuthStatus(BitwardenAuthStatus authStatus, string email, string password)
        {
            try
            {
                switch (authStatus.Status)
                {
                    case BitwardenStatus.Logout:
                        //Need email and password
                        return await FullLogin(email, password);
                    case BitwardenStatus.Locked:
                        //Need only password
                        return await LoginLocked(authStatus, email, password);
                    case BitwardenStatus.Unlocked:
                        //Need only password
                        return await LoginUnlocked(authStatus, email, password);
                    default:
                        throw new ArgumentException($"The status {authStatus.Status} does not exist");
                }
            }
            catch (Exception ex)
            {
                return LoginResult.CreateFailed(ex.Message);
            }
        }

        /// <summary>
        /// Performs the login when the current auth status is locked
        /// Checks if the current email is the same as the email of the current registered user
        /// </summary>
        /// <param name="authStatus">The current authStatus</param>
        /// <param name="email">The email used for the login</param>
        /// <param name="password">The master password used for the login</param>
        /// <returns>The login result</returns>
        private async Task<LoginResult> LoginLocked(BitwardenAuthStatus authStatus, string email, string password)
        {
            if (email == authStatus.UserEmail)
            {
                //Same email as the user that is logged in
                return await Unlock(password);
            }
            else
            {
                //Must logout the current registered user first
                return await LogoutLogin(email, password);
            }
        }

        /// <summary>
        /// Performs the login when the current auth status is unlocked
        /// Checks if the current email is the same as the email of the current registered user
        /// </summary>
        /// <param name="authStatus">The current authStatus</param>
        /// <param name="email">The email used for the login</param>
        /// <param name="password">The master password used for the login</param>
        /// <returns>The login result</returns>
        private async Task<LoginResult> LoginUnlocked(BitwardenAuthStatus authStatus, string email, string password)
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

        /// <summary>
        /// Logs out the current registered user first and then performs a full login
        /// </summary>
        /// <param name="email">The email used for the login</param>
        /// <param name="password">The master password used for the login</param>
        /// <returns>The login result</returns>
        private async Task<LoginResult> LogoutLogin(string email, string password)
        {
            await Logout();
            return await FullLogin(email, password);
        }

        /// <summary>
        /// Performs a full login = login + unlock
        /// </summary>
        /// <param name="email">The email used for the login</param>
        /// <param name="password">The master password used for the login</param>
        /// <returns>The login result</returns>
        private async Task<LoginResult> FullLogin(string email, string password)
        {
            var loginResult = await Login(email, password);
            if (loginResult.IsLoggedIn)
            {
                return await Unlock(password);
            }

            return loginResult;
        }

        public abstract Task<LoginResult> Login(string email, string password);

        public abstract Task<LoginResult> Unlock(string password);

        public abstract Task<CommandResult> Logout();
    }
}
