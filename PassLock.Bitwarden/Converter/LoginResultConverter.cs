using System;

namespace PassLock.Bitwarden.Converter
{
    public static class LoginResultConverter
    {
        public static string GetSessionKey(string output)
        {
            output = output.Trim();

            int lastIndex = output.LastIndexOf("--session ");
            if (lastIndex < 0)
            {
                throw new ArgumentException("No session existing");
            }

            int beginIndex = lastIndex + 10;
            if (beginIndex > output.Length)
            {
                throw new ArgumentException("The session is too short");
            }

            string session = output.Substring(beginIndex);
            return session;
        }
    }
}
