using Auth0.OidcClient;
using Foundation;
using Prism;
using Prism.Ioc;
using PVBot.Clients.UI;
using PVBot.DataObjects.Contracts;
using UIKit;


namespace PVBot.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var client = new Auth0Client(new Auth0ClientOptions {
                Domain = "volatile-programing.us.auth0.com",
                ClientId = "GCErWQ4I0XVGmrQOMGo2sLgSHWMb4u6Y"
            });

            containerRegistry.RegisterInstance(client);
            containerRegistry.RegisterScoped<IIdentityClient, IdentityClient>();
        }
    }
}
