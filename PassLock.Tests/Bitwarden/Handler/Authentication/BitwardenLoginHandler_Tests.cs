using Moq;
using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Tests.Basics;
using PassLock.Tests.Helper.AuthHelper;
using Xunit;

namespace PassLock.Tests.Bitwarden.Handler.Authentication
{
    public class BitwardenLoginHandler_Tests : MoqTest
    {
        #region Logout

        [Theory]
        [InlineData(LoginHelper.CORRECT_LOGIN, LoginHelper.CORRECT_UNLOCK, AuthStatusHelper.UNLOCKED_STATUS_OUTPUT, true, null)]
        [InlineData(LoginHelper.INVALID_LOGIN, LoginHelper.CORRECT_UNLOCK, AuthStatusHelper.UNLOCKED_STATUS_OUTPUT, false, LoginHelper.INVALID_LOGIN)]
        [InlineData(LoginHelper.CORRECT_LOGIN, LoginHelper.INVALID_UNLOCK, AuthStatusHelper.UNLOCKED_STATUS_OUTPUT, false, LoginHelper.INVALID_UNLOCK)]
        public async void LoginByAuthStatus_Logout_Test(string loginResponse, string unlockResponse, 
            string authStatusResponse, bool expectedSuccess, string expectedErrorMessage)
        {
            var authStatus = AuthStatusHelper.GetAuthStatusByBitwardenStatus(BitwardenStatus.Logout);
            var mock = new Mock<IAuthService>();
            var loginTask = CreateCommandResultTaskFromOutput(loginResponse);
            var unlockTask = CreateCommandResultTaskFromOutput(unlockResponse);
            var authStatusTask = CreateCommandResultTaskFromOutput(authStatusResponse);
            mock.Setup(service => service.Login(USERNAME, PASSWORD)).Returns(loginTask);
            mock.Setup(service => service.Unlock(PASSWORD)).Returns(unlockTask);
            mock.Setup(service => service.GetAuthStatus()).Returns(authStatusTask);

            var authHandler = new BitwardenAuthHandler(mock.Object);
            var loginResult = await authHandler.LoginByAuthStatus(authStatus, USERNAME, PASSWORD);

            Assert.Equal(expectedSuccess, loginResult.IsLoggedIn);
            Assert.Equal(expectedErrorMessage, loginResult.ErrorMessage);
        }

        #endregion
    }
}
