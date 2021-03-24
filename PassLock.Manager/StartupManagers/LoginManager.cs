using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Manager;
using PassLock.GUI.Manager;
using PassLock.Handler.Data.Diagnostics;
using PassLock.Handler.Data.Startup;
using PassLock.Handler.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PassLock.Manager.StartupManagers
{
    public static class LoginManager
    {
        /// <summary>
        /// Handles the login logic
        /// </summary>
        /// <param name="appSettings">The startup settings</param>
        /// <returns>The loginResult</returns>
        public static async Task<LoginResult> Login(AppSettings appSettings)
        {
            Console.WriteLine("...Login...");

            var timer = new ExecutionTimer(true);
            LoginResult loginResult;

            try
            {
                if (RunModeHandler.IsDebugMode())
                {
                    bool fastLogin = bool.Parse(appSettings.GetByKey(AppSetting.FastLogin));
                    if (fastLogin)
                    {
                        loginResult = await FastLogin();
                    }
                    else
                    {
                        loginResult = await BitwardenUIAuthManager.Login();
                    }
                }
                else
                {
                    loginResult = await BitwardenUIAuthManager.Login();
                }

                return loginResult;
            }
            finally
            {
                timer.StopAndWrite();
            }
        }

        /// <summary>
        /// Executes the fastLogin
        /// If the fastLogin fails, a normal login is beeing executed
        /// </summary>
        /// <returns>The loginResult of the fastLogin</returns>
        private static async Task<LoginResult> FastLogin()
        {
            Console.WriteLine("...FastLogin...");
            LoginResult loginResult;

            try
            {
                string exeFolder = PathHandler.ExeFolder;
                string fastLoginFile = $@"{exeFolder}\fastLogin.txt";
                if (!File.Exists(fastLoginFile))
                    throw new FileNotFoundException($"No fastLogin file found in {exeFolder}");

                string password = File.ReadAllText(fastLoginFile);
                loginResult = await BitwardenAuthManager.Unlock(password);
                if (!loginResult.IsLoggedIn)
                    throw new ArgumentException(loginResult.ErrorMessage);

                return loginResult;
            }
            catch
            {
                loginResult = await BitwardenUIAuthManager.Login();
                return loginResult;
            }
        }
    }
}
