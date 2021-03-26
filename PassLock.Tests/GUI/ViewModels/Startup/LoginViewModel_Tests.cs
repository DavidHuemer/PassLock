using Moq;
using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.GUI.ViewModels.Startup;
using PassLock.Tests.Basics;
using System;
using Xunit;

namespace PassLock.Tests.GUI.ViewModels.Startup
{
    public class LoginViewModel_Tests : MoqTest
    {
        private string returningPassword = "";

        #region Email

        [Theory]
        [InlineData(BitwardenStatus.Logout, null, "")]
        [InlineData(BitwardenStatus.Locked, USERNAME, USERNAME)]
        [InlineData(BitwardenStatus.Unlocked, USERNAME, USERNAME)]
        public void Test_Email(BitwardenStatus status, string email, string expected)
        {
            var mock = new Mock<IAuthService>();
            var loginViewModel = new LoginViewModel(mock.Object, GetPasswordFunc);
            var bitwardenAuthStatus = new BitwardenAuthStatus
            {
                LastSync = DateTime.Now,
                ServerUrl = "bitwarden.com",
                Status = status,
                UserEmail = email,
                UserId = "afjsf4a86"
            };

            loginViewModel.Init(bitwardenAuthStatus);
            Assert.Equal(expected, loginViewModel.Email);
        }

        #endregion

        #region CanLogin

        [Theory]
        [InlineData(USERNAME, PASSWORD, true)]
        [InlineData("", PASSWORD, false)]
        [InlineData(USERNAME, "", false)]
        [InlineData("", "", false)]
        public void CanLogin_Tests(string email, string password, bool expected)
        {
            var mock = new Mock<IAuthService>();
            var loginViewModel = new LoginViewModel(mock.Object, GetPasswordFunc);
            loginViewModel.Email = email;
            returningPassword = password;
            loginViewModel.Password = "***";
            Assert.Equal(expected, loginViewModel.CanLogin);
        }

        #endregion

        #region Login

        //[Theory]
        //[InlineData(USERNAME, PASSWORD)]
        //public void Login_Tests(string email, string password, bool sucess)
        //{
        //    returningPassword = password;
        //    var mock = new Mock<IAuthService>();
        //    var loginViewModel = new LoginViewModel(mock.Object, GetPasswordFunc);
        //    loginViewModel.Init();
        //    loginViewModel.Email = email;

        //    loginViewModel.Login.Execute(null);
        //    Assert.Equal(sucess, loginViewModel.LoginResult.IsLoggedIn);
        //}

        #endregion

        #region Reset

        [Fact]
        public void Reset_Test()
        {
            returningPassword = PASSWORD;
            var mock = new Mock<IAuthService>();
            var loginViewModel = new LoginViewModel(mock.Object, GetPasswordFunc)
            {
                Email = USERNAME
            };

            loginViewModel.Reset();
            Assert.Equal("", loginViewModel.Email);
            Assert.Equal("", loginViewModel.Password);
        }

        #endregion

        private string GetPasswordFunc()
        {
            return returningPassword;
        }
    }
}
