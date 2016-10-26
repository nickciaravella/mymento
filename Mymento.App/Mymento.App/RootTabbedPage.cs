namespace Mymento.App
{
    using Mymento.App.Login;
    using Mymento.App.Tasks;
    using Xamarin.Forms;

    public class RootTabbedPage : TabbedPage
    {
        public RootTabbedPage()
        {
            this.Title = "TabbedPage";
            Children.Add(new TimelinePage());
            Children.Add(new ContentPage() {Title = "Things"});
            Children.Add(new ContentPage() { Title = "Me" });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var credential = await DependencyService
                .Get<IUserCredentialStore>()
                .GetCurrentUserCredentialAsync();

            /*
            // For testing (until logout is implemented)
            // Issue: https://github.com/nickciaravella/mymento/issues/7
            await DependencyService
                .Get<IUserCredentialStore>()
                .RemoveUserCredentialAsync(credential);

            credential = await DependencyService
                .Get<IUserCredentialStore>()
                .GetCurrentUserCredentialAsync();
            */

            var isUserLoggedIn = credential != null;

            if (!isUserLoggedIn)
            {
                MessagingCenter.Subscribe<LoginViewModel>(this, "UserLoginComplete", this.LoginCompleted);
                var loginPage = new LoginPage();
                await Navigation.PushModalAsync(loginPage, false);
            }
        }

        private async void LoginCompleted(LoginViewModel obj)
        {
            await Navigation.PopModalAsync(true);
        }
    }

    // Data type:
    class NamedColor
    {
        public NamedColor(string name, Color color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Name { private set; get; }

        public Color Color { private set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

    // Format page
    class NamedColorPage : ContentPage
    {
        public NamedColorPage()
        {
            // This binding is necessary to label the tabs in
            // the TabbedPage.
            this.SetBinding(ContentPage.TitleProperty, "Name");
            // BoxView to show the color.
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };
            boxView.SetBinding(BoxView.ColorProperty, "Color");

            // Build the page
            this.Content = boxView;
        }
    }
}