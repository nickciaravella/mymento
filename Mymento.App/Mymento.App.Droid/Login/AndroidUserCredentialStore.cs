namespace Mymento.App.Droid.Login
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Mymento.App.Login;
    using Xamarin.Auth;

    public class AndroidUserCredentialStore : IUserCredentialStore
    {
        private const string ServiceName = "mymento";

        public Task<UserCredential> GetCurrentUserCredentialAsync() =>
            Task.Run(() => this
                .GetAccountStore()
                .FindAccountsForService(ServiceName)
                .Select(this.CredentialFromAccount)
                .FirstOrDefault());

        public Task SaveUserCredentialAsync(UserCredential userCredential) =>
            this.GetAccountStore()
                .SaveAsync(this.AccountFromCredential(userCredential), ServiceName);

        public Task RemoveUserCredentialAsync(UserCredential userCredential) =>
            this.GetAccountStore()
                .DeleteAsync(this.AccountFromCredential(userCredential), ServiceName);

        private AccountStore GetAccountStore() =>
            AccountStore.Create(Android.App.Application.Context);

        private Account AccountFromCredential(UserCredential credential) =>
            new Account(
                credential.EmailAddress, 
                new Dictionary<string, string>
                {
                    { "password", credential.Password }
                });

        private UserCredential CredentialFromAccount(Account account) =>
            new UserCredential(account.Username, account.Properties["password"]);
    }
}
