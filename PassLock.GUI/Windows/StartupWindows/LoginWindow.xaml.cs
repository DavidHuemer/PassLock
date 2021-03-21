using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Services;
using PassLock.GUI.ViewModels.Startup;
using System;
using System.Windows;

namespace PassLock.GUI.Windows.StartupWindows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel viewModel;
        private LoginResult loginResult = null;
        public LoginWindow()
        {
            InitializeComponent();
            var authService = new BitwardenAuthService();
            viewModel = new LoginViewModel(authService, GetPassword);
            viewModel.Closing += ViewModel_Closing;
            DataContext = viewModel;
        }

        private void ViewModel_Closing(object sender, EventArgs e)
        {
            Close();
        }

        public LoginResult Open(BitwardenAuthStatus bitwardenAuthStatus)
        {
            viewModel.Open(bitwardenAuthStatus);
            ShowDialog();
            return loginResult;
        }

        private string GetPassword()
        {
            return passwordBox.Password;
        }

        private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            loginResult = viewModel.LoginResult;
        }
    }
}
