using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.GUI.ViewModels.Basics;
using PassLock.Handler.Data.Diagnostics;
using System;
using System.Windows.Input;

namespace PassLock.GUI.ViewModels.Startup
{
    public class LoginViewModel : WindowViewModel
    {
        #region Private variables

        private readonly BitwardenAuthHandler bitwardenAuthHandler;
        private readonly Func<string> getPassFunc;
        private string originalEmail = "";

        #endregion

        #region Init

        public LoginViewModel(IAuthService authService, Func<string> getPassFunc)
        {
            Title = "Login";
            bitwardenAuthHandler = new BitwardenAuthHandler(authService);
            this.getPassFunc = getPassFunc;
        }

        /// <summary>
        /// Inititializes the begin state of the viewModel
        /// </summary>
        /// <param name="bitwardenAuthStatus">The current auth status</param>
        public void Init(BitwardenAuthStatus bitwardenAuthStatus)
        {
            originalEmail = bitwardenAuthStatus.UserEmail ?? "";
            Email = originalEmail;
        }

        #endregion

        #region Properties

        public LoginResult LoginResult { get; private set; } = LoginResult.CreateFailed("Login failed");

        private string email = "";
        private string password = "";

        public string Email
        {
            get => email;
            set
            {
                email = value;
                UpdateCanLogin();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                UpdateCanLogin();
            }
        }

        public bool IsLogginIn { get; set; } = false;

        public string ErrorText { get; set; } = "";

        public bool CanEnterText { get; set; } = true;

        #endregion

        #region Commands

        public bool CanLogin { get; private set; } = false;
        public ICommand Login => new RelayCommand(o => { DoLogin(); }, o => CanLogin);
        private async void DoLogin()
        {
            var timer = new ExecutionTimer(true);

            StartLogin();

            string email = Email;
            string password = getPassFunc();
            var loginResult = await bitwardenAuthHandler.LoginByAuthStatus(email, password);
            LoginResult = loginResult;

            if (loginResult.IsLoggedIn)
            {
                //Login was sucessfull
                Reset();
                Close();
            }
            else
            {
                //Login failed
                SetUpProperties(false, loginResult.ErrorMessage, true, GetCanLogin());
            }

            IsLogginIn = false;
            timer.StopAndWrite();
        }

        private void StartLogin()
        {
            SetUpProperties(true, "", false, false);
        }

        private void SetUpProperties(bool isLoggingIn, string errorText, bool canEnterText, bool canLogin)
        {
            IsLogginIn = isLoggingIn;
            ErrorText = errorText;
            CanEnterText = canEnterText;
            CanLogin = canLogin;
        }

        public ICommand Register => new RelayCommand(o => { DoRegister(); }, o => true);
        private async void DoRegister()
        {

        }

        #endregion

        /// <summary>
        /// Updates CanLogin, depending on if a login is possible
        /// </summary>
        private void UpdateCanLogin()
        {
            CanLogin = GetCanLogin();
        }

        /// <summary>
        /// Returns if a login is possible depending on the email and password
        /// </summary>
        /// <returns>If a login is possible depending on the email and password</returns>
        private bool GetCanLogin()
        {
            return Email.Trim().Length > 0 && getPassFunc().Trim().Length > 0;
        }

        /// <summary>
        /// Resets the viewModel
        /// </summary>
        public void Reset()
        {
            Email = "";
            Password = "";
        }
    }
}
