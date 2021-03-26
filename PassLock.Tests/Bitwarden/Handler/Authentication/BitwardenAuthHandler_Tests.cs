using Moq;
using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Tests.Basics;
using PassLock.Tests.Helper.AuthHelper;
using Xunit;

namespace PassLock.Tests.Bitwarden.Handler.Authentication
{
    /// <summary>
    /// Tests the BitwardenAuthHandler
    /// </summary>
    public class BitwardenAuthHandler_Tests : MoqTest
    {
        #region Get Auth Status

        [Theory]
        [InlineData(BitwardenStatus.Logout)]
        [InlineData(BitwardenStatus.Locked)]
        [InlineData(BitwardenStatus.Unlocked)]
        public async void GetAuthStatus_Tests(BitwardenStatus status)
        {
            var mock = new Mock<IAuthService>();
            string authStatusOutput = AuthStatusHelper.GetAuthStatusOutputByBitwardenStatus(status);
            var t = CreateCommandResultTaskFromOutput(authStatusOutput);
            mock.Setup(service => service.GetAuthStatus()).Returns(t);

            var authHandler = new BitwardenAuthHandler(mock.Object);
            var authStatus = await authHandler.GetAuthStatus();
            var expectedAuthStatus = AuthStatusHelper.GetAuthStatusByBitwardenStatus(status);
            Assert.Equal(status, authStatus.Status);
            Assert.Equal(expectedAuthStatus.UserEmail, authStatus.UserEmail);
            Assert.Equal(expectedAuthStatus.UserId, authStatus.UserId);
        }

        #endregion
    }
}
