using Moq;
using PassLock.Handler.IO.InstallationHandler;
using PassLock.Handler.IO.InstallationHandler.Services;
using PassLock.Tests.Basics;
using System.Threading.Tasks;
using Xunit;

namespace PassLock.Tests.Handler.IO
{
    public class InstallationHandler_Tests : MoqTest
    {
        private readonly Mock<IInstallationService> mock;

        public InstallationHandler_Tests()
        {
            mock = new Mock<IInstallationService>();
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("abc", false)]
        public async void Bitwarden_IsInstalled_Tests(string commandOuput, bool expected)
        {
            mock.Reset();
            var result = CreateCommandResult(commandOuput);
            var t = Task.FromResult(result);
            mock.Setup(service => service.RunIsCommandInstalled(BitwardenInstallationHandler.BITWARDEN_INSTALLATION_CHECK_COMMAND)).Returns(t);
            var bwi = new BitwardenInstallationHandler(mock.Object);

            bool isInstalled = await bwi.IsInstalled();
            Assert.Equal(expected, isInstalled);
        }

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("abc", false)]
        public async void NPM_IsInstalled_Tests(string commandOuput, bool expected)
        {
            mock.Reset();
            var result = CreateCommandResult(commandOuput);
            var t = Task.FromResult(result);
            mock.Setup(service => service.RunIsCommandInstalled(NPMInstallationHandler.NPM_INSTALLATION_CHECK_COMMAND)).Returns(t);
            var npi = new NPMInstallationHandler(mock.Object);

            bool isInstalled = await npi.IsInstalled();
            Assert.Equal(expected, isInstalled);
        }
    }
}
