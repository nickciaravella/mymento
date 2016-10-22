namespace Mymento.App.Login
{
    using Mymento.App.Shared;

    public class UserCredential
    {
        public UserCredential(string emailAddress, string password)
        {
            Ensure.ArgumentIsNotNullOrWhitespace(nameof(emailAddress), emailAddress);
            Ensure.ArgumentIsNotNullOrWhitespace(nameof(password), password);
            this.EmailAddress = emailAddress;
            this.Password = password;
        }

        public string EmailAddress { get; }

        public string Password { get; }
    }
}
