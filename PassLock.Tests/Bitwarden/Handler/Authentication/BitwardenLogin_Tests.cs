using Moq;
using PassLock.Bitwarden.Handler;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Tests.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassLock.Tests.Bitwarden.Handler.Authentication
{
    public class BitwardenLogin_Tests : MoqTest
    {
        const string CORRECT_LOGIN = "You are logged in!\r\n\r\nTo unlock your vault, set your session key to the `BW_SESSION` environment variable. ex:\r\n$ export BW_SESSION=\"AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==\"\r\n> $env:BW_SESSION=\"AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==\"\r\n\r\nYou can also pass the session key to any command with the `--session` option. ex:\r\n$ bw list items --session AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==";
        const string SECCOND_LOGIN = "You are already logged in as example.email@gmail.com";
        const string INVALID_LOGIN = "Username or password is incorrect. Try again.";

        const string CORRECT_LOGOUT = "You have logged out.";
        const string SECCOND_LOGOUT = "You are not logged in.";

        [Theory]
        [InlineData(CORRECT_LOGIN, true, null)]
        [InlineData(SECCOND_LOGIN, false, SECCOND_LOGIN)]
        [InlineData(INVALID_LOGIN, false, INVALID_LOGIN)]
        public async void CheckLogin(string response, bool expectedSuccess, string expectedErrorMessage)
        {
            var mock = new Mock<IAuthService>();
            var t = CreateCommandResultTaskFromOutput(response);
            mock.Setup(service => service.Login(USERNAME, PASSWORD)).Returns(t);
            var handler = new BitwardenAuthHandler(mock.Object);
            var loginResult = await handler.Login(USERNAME, PASSWORD);

            Assert.Equal(expectedSuccess, loginResult.IsLoggedIn);
            Assert.Equal(expectedErrorMessage, loginResult.ErrorMessage);
        }

        [Theory]
        [InlineData(CORRECT_LOGOUT)]
        [InlineData(SECCOND_LOGOUT)]
        public async void CheckLogout(string response)
        {
            var mock = new Mock<IAuthService>();
            var t = CreateCommandResultTaskFromOutput(response);
            mock.Setup(service => service.Logout()).Returns(t);
            var handler = new BitwardenAuthHandler(mock.Object);
            var logoutResult = await handler.Logout();
            Assert.Equal(response, logoutResult.Output);
        }
    }
}
