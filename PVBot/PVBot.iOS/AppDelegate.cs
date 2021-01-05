using Auth0.OidcClient;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using PVBot.Clients.UI;
using PVBot.Clients.UI.Properties;
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
            global::XF.Material.iOS.Material.Init();
            AppCenter.Start("c852690c-fdfd-46fb-919b-41a3dc147168",
                   typeof(Analytics), typeof(Crashes));

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        // 
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            ActivityMediator.Instance.Send(url.AbsoluteString);

            //return base.OpenUrl(application, url, sourceApplication, annotation);
            return true;
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = Secrets.Auth0Domain,
                ClientId = Secrets.Auth0ClientId,
                Scope = "openid offline_access profile email"
            });

            containerRegistry.RegisterInstance<IAuth0Client>(client);
        }
    }
}
