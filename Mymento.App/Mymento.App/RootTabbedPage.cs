namespace Mymento.App
{
    using System.Threading.Tasks;
    using Mymento.App.Login;
    using Xamarin.Forms;

    public class RootTabbedPage : TabbedPage
    {
        public RootTabbedPage()
        {
            this.Title = "TabbedPage";

            this.ItemsSource = new NamedColor[] {
                new NamedColor ("Upcoming", Color.Red),
                new NamedColor ("Things", Color.Green)
            };

            this.ItemTemplate = new DataTemplate(() => new NamedColorPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var loginPage = new LoginPage();
            await Navigation.PushModalAsync(loginPage, false);
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