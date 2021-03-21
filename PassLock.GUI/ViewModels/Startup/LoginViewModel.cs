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
        private readonly BitwardenAuthHandler bitwardenAuthHandler;
        private readonly Func<string> getPassFunc;
        private string originalEmail = "";

        public LoginResult LoginResult { get; private set; } = LoginResult.CreateFailed("Login failed");

        public LoginViewModel(IAuthService authService, Func<string> getPassFunc)
        {
            Title = "Login";
            bitwardenAuthHandler = new BitwardenAuthHandler(authService);
            this.getPassFunc = getPassFunc;
        }

        public void Open(BitwardenAuthStatus bitwardenAuthStatus)
        {
            originalEmail = bitwardenAuthStatus.UserEmail ?? "";
            Email = originalEmail;
        }

        #region Properties

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

        public string ErrorText { get; set; } = "";

        public bool CanEnterText { get; set; } = true;

        #endregion

        private void UpdateCanLogin()
        {
            CanLogin = Email.Trim().Length > 0 && getPassFunc().Trim().Length > 0;
        }

        public bool CanLogin { get; private set; } = false;
        public ICommand Login => new RelayCommand(o => { DoLogin(); }, o => CanLogin);
        private async void DoLogin()
        {
            var timer = new ExecutionTimer(true);

            CanEnterText = false;
            CanLogin = false;

            string email = Email;
            string password = getPassFunc();

            var loginResult = await BitwardenLoginHandler.LoginByAuthStatus(bitwardenAuthHandler, email, password);
            
            if (loginResult.IsLoggedIn)
            {
                //Login was sucessfull
                LoginResult = LoginResult;
                Reset();
                Close();
            }
            else
            {
                //Login failed
                CanEnterText = true;
                CanLogin = true;
                ErrorText = loginResult.ErrorMessage;
            }

            timer.StopAndWrite();
        }


        public ICommand Register => new RelayCommand(o => { DoRegister(); }, o => true);
        private async void DoRegister()
        {

        }

        private void Reset()
        {

        }
    }
}
