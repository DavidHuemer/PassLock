using PassLock.Handler.Data;
using System;
using System.Threading.Tasks;

namespace PassLock.Manager.StartupManagers.Installation
{
    public class InstallationManager
    {
        /// <summary>
        /// Checks if everything is installed that is needed
        /// </summary>
        public static async Task<InstallationSucess> CheckInstallations()
        {
            Console.WriteLine($"{nameof(InstallationManager)}: {nameof(CheckInstallations)}");
            try
            {
                //Gets the installation status of bitwarden
                bool isBitwardenInstalled = await BitwardenInstallationManager.Instance.IsInstalled();

                //The result of the installations
                var installResult = await CheckBitwardenInstallation(isBitwardenInstalled);
                return installResult;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while installing: {ex.Message}");
            }
        }

        /// <summary>
        /// Installs Bitwarden if neccesary
        /// </summary>
        /// <param name="isBitwardenInstalled">If bitwarden is installed or not</param>
        /// <returns>The installation result</returns>
        private static async Task<InstallationSucess> CheckBitwardenInstallation(bool isBitwardenInstalled)
        {
            if (!isBitwardenInstalled)
            {
                //Bitwarden needs to be installed
                return await InstallBitwarden();
            }
            else
            {
                //Bitwarden is already installed
                return new InstallationSucess("Bitwarden", true);
            }
        }

        /// <summary>
        /// Installs Bitwarden and NPM if necessary
        /// </summary>
        /// <returns></returns>
        private static async Task<InstallationSucess> InstallBitwarden()
        {

            //Gets the installation status of bitwarden
            bool isNPMInstalled = await NpmInstallationManager.Instance.IsInstalled();
            Console.WriteLine($"IsNPMInstalled: {isNPMInstalled}");

            var npmInstallationSucess = CheckNPMInstallation(isNPMInstalled);
            if (!npmInstallationSucess.Sucess)
            {
                return npmInstallationSucess;
            }

            var bitwardenInstallationSuccess = BitwardenInstallationManager.Instance.Install();
            return new InstallationSucess("Bitwarden", bitwardenInstallationSuccess);
        }

        private static InstallationSucess CheckNPMInstallation(bool isNPMInstalled)
        {
            if (!isNPMInstalled)
            {
                //NPM needs to be installed
                return InstallNPM();
            }
            else
            {
                //Bitwarden is already installed
                return new InstallationSucess("NPM", true);
            }
        }

        private static InstallationSucess InstallNPM()
        {
            var npmInstallationSucess = NpmInstallationManager.Instance.Install();
            return new InstallationSucess("NPM", npmInstallationSucess);
        }
    }
}
