using PassLock.Bitwarden.Data.Data.Authentication;
using PassLock.Tests.Basics;
using System;

namespace PassLock.Tests.Helper.AuthHelper
{
    /// <summary>
    /// Helps creating an auth status for testing purpose
    /// </summary>
    public class AuthStatusHelper
    {
        public const string LOGOUT_STATUS_OUTPUT = "{\"serverUrl\":\"https://bitwarden.com\",\"lastSync\":null,\"userEmail\":null,\"userId\":null,\"status\":\"unauthenticated\"}";
        public const string LOCKET_STATUS_OUTPUT = "{\"serverUrl\":\"https://bitwarden.com\",\"lastSync\":\"2021-03-26T20:28:12.642Z\",\"userEmail\":\"" + BaseTest.Email + "\",\"userId\":\"2cad48e5-a2h5-41a5-b00c-acbd01405774\",\"status\":\"locked\"}";
        public const string UNLOCKED_STATUS_OUTPUT = "{\"serverUrl\":\"https://bitwarden.com\",\"lastSync\":\"2021-03-26T20:28:12.642Z\",\"userEmail\":\"" + BaseTest.Email + "\",\"userId\":\"2cad48e5-a2h5-41a5-b00c-acbd01405774\",\"status\":\"unlocked\"}";

        private const string BITWARDEN_URL = "https://bitwarden.com";
        private const string USERNAME = BaseTest.Email;
        private const string USER_ID = "2cad48e5-a2h5-41a5-b00c-acbd01405774";

        public static string GetAuthStatusOutputByBitwardenStatus(BitwardenStatus status)
        {
            switch (status)
            {
                case BitwardenStatus.Logout:
                    return LOGOUT_STATUS_OUTPUT;
                case BitwardenStatus.Locked:
                    return LOCKET_STATUS_OUTPUT;
                case BitwardenStatus.Unlocked:
                    return UNLOCKED_STATUS_OUTPUT;
                default:
                    throw new ArgumentException($"The status {status} does not exist");
            }
        }

        public static BitwardenAuthStatus GetAuthStatusByBitwardenStatus(BitwardenStatus status)
        {
            switch (status)
            {
                case BitwardenStatus.Logout:
                    return CreateBitwardenAuthStatus(null, null, null, BitwardenStatus.Logout);
                case BitwardenStatus.Locked:
                    return CreateBitwardenAuthStatus(DateTime.Now, USERNAME, USER_ID, BitwardenStatus.Locked);
                case BitwardenStatus.Unlocked:
                    return CreateBitwardenAuthStatus(DateTime.Now, USERNAME, USER_ID, BitwardenStatus.Unlocked);
                default:
                    throw new ArgumentException($"The status {status} does not exist");
            }
        }

        public static BitwardenAuthStatus CreateBitwardenAuthStatus(DateTime? lastSync, string userEmail, string userId, BitwardenStatus status)
        {
            return new BitwardenAuthStatus
            {
                ServerUrl = BITWARDEN_URL,
                LastSync = lastSync,
                UserEmail = userEmail,
                UserId = userId,
                Status = status
            };
        }
    }
}
