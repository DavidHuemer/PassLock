using PassLock.GUI.ViewModels.Startup;
using PassLock.GUI.ViewModels.Startup.Installation;
using System;
using System.Windows;

namespace PassLock.GUI.Windows.StartupWindows.InstallerWindows
{
    /// <summary>
    /// Interaction logic for BaseInstallationWindow.xaml
    /// </summary>
    public partial class BaseInstallationWindow : Window
    {
        public BaseInstallationWindow()
        {
            InitializeComponent();
        }

        public bool Install()
        {
            ShowDialog();
            return true;
        }

        public BaseInstallationWindow(BaseInstallationViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Finished += ViewModel_Finished;
            DataContext = viewModel;
        }

        private void ViewModel_Finished(object sender, EventArgs e)
        {
            Close();
        }
    }
}
