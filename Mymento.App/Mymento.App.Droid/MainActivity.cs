using Mymento.App.Droid.Login;
[assembly: Xamarin.Forms.Dependency(typeof(AndroidUserCredentialStore))]

namespace Mymento.App.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;

    [Activity(
        Label = "Mymento.App",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

