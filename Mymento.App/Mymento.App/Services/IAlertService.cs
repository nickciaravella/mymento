namespace Mymento.App.Services
{
    using System.Threading.Tasks;

    public interface IAlertService
    {
        Task<bool> ShowAlertAsync(
            string title,
            string message,
            string acceptButtonText,
            string rejectButtonText);

        Task ShowAlertAsync(
            string title,
            string message,
            string onlyButtonText);
    }
}
