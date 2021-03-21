using Newtonsoft.Json;
using PassLock.Bitwarden.Converter;
using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Data.DTOs;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Handler.CommandLineHandler.Data;
using System;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Handler
{
    public class BitwardenAuthHandler
    {
        private const string INVALID_LOGIN = "Username or password is incorrect. Try again.";
        private const string ALREADY_LOGGED_IN = "You are already logged in as";

        private readonly IAuthService authService;

        public BitwardenAuthHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// Returns the current authentication status of bitwarden
        /// </summary>
        /// <returns>Current authentication status of bitwarden</returns>
        public async Task<BitwardenAuthStatus> GetAuthStatus()
        {
            var result = await authService.GetAuthStatus();
            if (result.Status != PassLock.Handler.CommandLineHandler.Data.CommandStatus.Success)
            {
                throw new ArgumentException("A correct response must be given");
            }

            var authDTO = JsonConvert.DeserializeObject<BitwardenAuthStatusDTO>(result.Output);
            return authDTO.ConvertBack();
        }

        /// <summary>
        /// Logs the user in with the email and the password
        /// </summary>
        /// <param name="email">The email of the bitwarden account</param>
        /// <param name="password">The password of the bitwarden account</param>
        /// <returns>The result of the login</returns>
        public async Task<LoginResult> Login(string email, string password)
        {
            var result = await authService.Login(email, password);

            if (result.Output == INVALID_LOGIN)
                return LoginResult.CreateFailed(INVALID_LOGIN);

            if (result.Output.Contains(ALREADY_LOGGED_IN))
                return LoginResult.CreateFailed(result.Output);

            //Login correct
            return LoginResult.CreateSucess(email);
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        /// <returns>The response of the logout command</returns>
        public async Task<CommandResult> Logout()
        {
            return await authService.Logout();
        }

        public async Task<LoginResult> Unlock(string password)
        {
            var result = await authService.Unlock(password);
            if (!result.Output.Contains("--session"))
            {
                return LoginResult.CreateFailed(result.Output);
            }

            string session = LoginResultConverter.GetSessionKey(result.Output);
            Environment.SetEnvironmentVariable("BW_SESSION", session);

            var authResult = await GetAuthStatus();
            if (authResult.Status == BitwardenStatus.Unlocked)
            {
                return LoginResult.CreateSucess(authResult.UserEmail);
            }
            else
            {
                return LoginResult.CreateFailed("The vault could not be unlocked");
            }
        }

        public async Task<CommandResult> Lock()
        {
            var result = await authService.Lock();
            return result;
        }
    }
}
