namespace Mymento.App.Login
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string username;
        private string password;

        public LoginViewModel()
        {
            this.OnLoginCommand = new Command(
                async (_) => await this.OnLoginAsync(),
                (_) => this.CanLogin());

            this.OnRegisterCommand = new Command(
                async (_) => await this.OnRegisterAsync());
        }

        public ICommand OnLoginCommand { get; set; }

        public ICommand OnRegisterCommand { get; set; }

        public string Username
        {
            get { return this.username; }
            set
            {
                this.username = value;
                this.OnEntryUpdated();
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.OnEntryUpdated();
            }
        }

        private void OnEntryUpdated() =>
            ((Command)this.OnLoginCommand).ChangeCanExecute();

        private Task OnLoginAsync() => Task.Delay(0);

        private bool CanLogin() =>
            !string.IsNullOrWhiteSpace(this.Username) &&
            !string.IsNullOrWhiteSpace(this.Password);

        private Task OnRegisterAsync() => Task.Delay(0);
    }
}
