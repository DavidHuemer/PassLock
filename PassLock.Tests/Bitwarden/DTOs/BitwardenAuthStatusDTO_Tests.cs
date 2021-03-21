using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Bitwarden.Data.DTOs;
using System;
using Xunit;

namespace PassLock.Tests.Bitwarden.DTOs
{
    public class BitwardenAuthStatusDTO_Tests
    {

        [Fact]
        public void LastSync_Null_Test()
        {
            var bitwardenAuthStatusDTO = new BitwardenAuthStatusDTO
            {
                ServerUrl = "",
                LastSync = null,
                UserEmail = "",
                UserId = "",
                Status = "locked"
            };

            var authStatus = bitwardenAuthStatusDTO.ConvertBack();
            Assert.Null(authStatus.LastSync);
        }

        [Fact]
        public void LastSync_NotNull_Test()
        {
            string date = "2021-03-01T12:40:35.047Z";

            var bitwardenAuthStatusDTO = new BitwardenAuthStatusDTO
            {
                ServerUrl = "",
                LastSync = date,
                UserEmail = "",
                UserId = "",
                Status = "locked"
            };

            var authStatus = bitwardenAuthStatusDTO.ConvertBack();
            Assert.Equal(DateTime.Parse(date), authStatus.LastSync);
        }

        [Theory]
        [InlineData("unauthenticated", BitwardenStatus.Logout)]
        [InlineData("locked", BitwardenStatus.Locked)]
        [InlineData("unlocked", BitwardenStatus.Unlocked)]
        public void Status_Tests(string statusStr, BitwardenStatus expectedStatus)
        {
            var bitwardenAuthStatusDTO = new BitwardenAuthStatusDTO
            {
                ServerUrl = "",
                LastSync = "2021-03-01T12:40:35.047Z",
                UserEmail = "",
                UserId = "",
                Status = statusStr
            };

            var authStatus = bitwardenAuthStatusDTO.ConvertBack();
            Assert.Equal(expectedStatus, authStatus.Status);
        }
    }
}
