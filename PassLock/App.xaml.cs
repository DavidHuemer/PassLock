using PassLock.Handler.Data.Startup;
using PassLock.Manager.StartupManagers;
using System;
using System.Configuration;
using System.Windows;

namespace PassLock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void PassLock_Startup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("Startup");

            //Starts the application
            var appSettings = new AppSettings(ConfigurationManager.AppSettings);
            StartupManager.Startup(appSettings);
        }
    }
}
