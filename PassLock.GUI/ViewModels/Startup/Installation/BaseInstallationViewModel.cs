using PassLock.GUI.ViewModels.Basics;
using PassLock.Handler.IO.InstallationHandler;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PassLock.GUI.ViewModels.Startup.Installation
{
    public abstract class BaseInstallationViewModel : WindowViewModel
    {
        public event EventHandler<EventArgs> Finished;
        protected BaseInstallationHandler installationHandler;

        #region Properties

        public Uri IconSource { get; set; }
        public string Command { get; set; }
        public string Detail { get; set; }

        #endregion

        public BaseInstallationViewModel(BaseInstallationHandler installationHandler, string title, string uri, string command, string detail)
        {
            this.installationHandler = installationHandler;
            Title = title;
            IconSource = new Uri(uri);
            Command = command;
            Detail = detail;
        }

        #region Commands

        #region Install Button

        public bool CanInstall { get; private set; } = true;
        public ICommand Install => new RelayCommand(o => { DoInstall(); }, o => CanInstall);
        private async void DoInstall()
        {
            Console.WriteLine("DoInstall");
            CanInstall = false;
            CanTest = false;
            await installationHandler.Install();
            Console.WriteLine("Installation Finished");

            DoTest();
        }

        #endregion

        #region Test Button

        public bool CanTest { get; private set; } = true;
        public ICommand Test => new RelayCommand(o => { DoTest(); }, o => CanTest);
        private async void DoTest()
        {
            Console.WriteLine("DoTest");

            CanInstall = false;
            CanTest = false;
            var result = await IsInstalled();

            if (result)
            {
                //Command is installed
                CanInstall = false;
                CanGoNext = true;
            }
            else
            {
                //Command is not installed
                CanInstall = true;
                CanGoNext = false;
            }


            CanTest = true;
        }

        #endregion

        #region Next Button
        
        public bool CanGoNext { get; private set; } = false;
        public ICommand Next => new RelayCommand(o => { DoGoNext(); }, o => CanGoNext);
        private void DoGoNext()
        {
            Finished?.Invoke(this, new EventArgs());
        }

        #endregion

        #endregion

        private async Task<bool> IsInstalled()
        {
            return await installationHandler.IsInstalled();
        }
    }
}
