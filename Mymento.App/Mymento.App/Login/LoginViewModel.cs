namespace Mymento.App.Login
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Mymento.App.DataAccess;
    using Mymento.App.Services;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        private string username;
        private string password;
        private bool isCurrentlyLoggingIn;

        public LoginViewModel()
        {
            this.OnLoginCommand = new Command(
                async (_) => await this.OnLoginAsync(),
                (_) => this.CanLogin());

            this.OnRegisterCommand = new Command(
                async (_) => await this.OnRegisterAsync());
        }

        public IAlertService AlertService { get; set; }

        public ICommand OnLoginCommand { get; set; }

        public ICommand OnRegisterCommand { get; set; }

        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                this.EvaluateLoginCommand();
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.EvaluateLoginCommand();
            }
        }

        private void EvaluateLoginCommand() =>
            ((Command) this.OnLoginCommand).ChangeCanExecute();

        private async Task OnLoginAsync()
        {
            var client = new MymentoServiceClient();
            try
            {
                this.UpdateIsUserLoggingIn(true);

                AccessToken token = await client.LoginAsync(this.Username, this.Password);

                await DependencyService
                    .Get<IUserCredentialStore>()
                    .SaveUserCredentialAsync(new UserCredential(this.Username, this.Password));

                MessagingCenter.Send(this, "UserLoginComplete");
            }
            catch (Exception)
            {
                await this.AlertService.ShowAlertAsync(
                    "Login Failed",
                    "Invalid username or password.",
                    "Ok");
            }
            finally
            {
                this.UpdateIsUserLoggingIn(false);
            }
        }

        private bool CanLogin() =>
            !string.IsNullOrWhiteSpace(this.Username) &&
            !string.IsNullOrWhiteSpace(this.Password) &&
            !isCurrentlyLoggingIn;

        private Task OnRegisterAsync() => Task.Delay(0);

        private void UpdateIsUserLoggingIn(bool isUserLoggingIn)
        {
            this.isCurrentlyLoggingIn = isUserLoggingIn;
            this.EvaluateLoginCommand();
        }
    }
}
