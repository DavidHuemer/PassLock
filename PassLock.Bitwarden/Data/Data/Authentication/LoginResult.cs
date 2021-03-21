namespace PassLock.Bitwarden.Data.Data.Authentication
{
    public class LoginResult
    {
        public bool IsLoggedIn { get; set; }
        public string ErrorMessage { get; set; }
        public string UserEmail { get; set; }

        public LoginResult(bool isLoggedIn, string errorMessage, string userEmail)
        {
            IsLoggedIn = isLoggedIn;
            ErrorMessage = errorMessage;
            UserEmail = userEmail;
        }

        public static LoginResult CreateSucess(string userEmail)
        {
            return new LoginResult(true, null, userEmail);
        }

        public static LoginResult CreateFailed(string errorMessage)
        {
            return new LoginResult(false, errorMessage, null);
        }
    }
}
