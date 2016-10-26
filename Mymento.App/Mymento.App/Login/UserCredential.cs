namespace Mymento.App.Login
{
    using Mymento.Common.Validation;

    public class UserCredential
    {
        public UserCredential(string emailAddress, string password)
        {
            emailAddress.ArgumentShouldNotBeNullOrWhitespace(nameof(emailAddress));
            password.ArgumentShouldNotBeNullOrWhitespace(nameof(password));

            this.EmailAddress = emailAddress;
            this.Password = password;
        }

        public string EmailAddress { get; }

        public string Password { get; }
    }
}
