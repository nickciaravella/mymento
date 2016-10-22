namespace Mymento.App.Login
{
    using Mymento.App.Services;
    using Xamarin.Forms;

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            ((LoginViewModel)this.BindingContext).AlertService = new AlertService(this);
        }
    }
}
