using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassLock.Tests.Helper.AuthHelper
{
    public static class LoginHelper
    {
        public const string CORRECT_LOGIN = "You are logged in!\r\n\r\nTo unlock your vault, set your session key to the `BW_SESSION` environment variable. ex:\r\n$ export BW_SESSION=\"AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==\"\r\n> $env:BW_SESSION=\"AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==\"\r\n\r\nYou can also pass the session key to any command with the `--session` option. ex:\r\n$ bw list items --session AVi2U8sypZ/K+NCbfS5O8hpPxApqkpuCikBwNSJQ2kxQsBV8qwDyAU/Ty/sOIr1IlycTvekjWBtPtfypMGITaw==";
        public const string SECCOND_LOGIN = "You are already logged in as example.email@gmail.com";
        public const string INVALID_LOGIN = "Username or password is incorrect. Try again.";

        public const string CORRECT_UNLOCK = "Your vault is now unlocked!\r\n\r\nTo unlock your vault, set your session key to the `BW_SESSION` environment variable. ex:\r\n$ export BW_SESSION=\"p4Qv+iKLipazwetwW288Zk7UT8AsTQIcgRAroouQILltdz2WNZkyh1zv8uID84dylXQyquaurutvyzg5utQDaA==\"\r\n> $env:BW_SESSION=\"p4Qv+iKLipazwetwW288Zk7UT8AsTQIcgRAroouQILltdz2WNZkyh1zv8uID84dylXQyquaurutvyzg5utQDaA==\"\r\n\r\nYou can also pass the session key to any command with the `--session` option. ex:\r\n$ bw list items --session p4Qv+iKLipazwetwW288Zk7UT8AsTQIcgRAroouQILltdz2WNZkyh1zv8uID84dylXQyquaurutvyzg5utQDaA==";
        public const string INVALID_UNLOCK = "Invalid master password";
    }
}
