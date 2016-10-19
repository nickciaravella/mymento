namespace Mymento.App.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Mymento.App.App());
        }
    }
}
