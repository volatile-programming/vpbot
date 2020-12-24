using Android.App;
using Android.Content.PM;
using Android.OS;
using Auth0.OidcClient;
using Prism;
using Prism.Ioc;
using PVBot.Clients.UI;
using PVBot.DataObjects.Contracts;

namespace PVBot.Droid
{
    [Activity(Theme = "@style/MainTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidInitializer(this)));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        private readonly MainActivity _mainActivity;

        public AndroidInitializer(MainActivity mainActivity)
        {
            _mainActivity = mainActivity;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var client = new Auth0Client(new Auth0ClientOptions {
                Domain = "volatile-programing.us.auth0.com",
                ClientId = "GCErWQ4I0XVGmrQOMGo2sLgSHWMb4u6Y"
            }, _mainActivity);

            containerRegistry.RegisterInstance(client);
            containerRegistry.RegisterScoped<IIdentityClient, IdentityClient>();
        }
    }
}

