namespace Mymento.App.Login
{
    using System.Threading.Tasks;

    public interface IUserCredentialStore
    {
        Task<UserCredential> GetCurrentUserCredentialAsync();

        Task SaveUserCredentialAsync(UserCredential userCredential);

        Task RemoveUserCredentialAsync(UserCredential userCredential);
    }
}
