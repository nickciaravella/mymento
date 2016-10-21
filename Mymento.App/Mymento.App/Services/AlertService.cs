namespace Mymento.App.Services
{
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class AlertService : IAlertService
    {
        private readonly Page page;

        public AlertService(Page page)
        {
            this.page = page;
        }

        public Task<bool> ShowAlertAsync(
            string title,
            string message,
            string acceptButtonText,
            string rejectButtonText) =>
                this.page.DisplayAlert(
                    title,
                    message,
                    acceptButtonText,
                    rejectButtonText);

        public Task ShowAlertAsync(
            string title,
            string message,
            string onlyButtonText) =>
                this.page.DisplayAlert(
                    title,
                    message,
                    onlyButtonText);
    }
}
