using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PVBot.Clients.UI.Properties;

namespace PVBot.Clients.UI
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            XF.Material.Forms.Material.Init(this);
            Portable.PVBotPortable.Init(this);

#if DEBUG
            // Resets access credentials for Auth0 testing.
            //var appConfig = Container.Resolve<IApplicationConfig>();
            //appConfig.ResetTokens();
#endif

            var local = await NavigationService.NavigateAsync("LoginView");
        }



        protected override async void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices();

            containerRegistry.RegisterFactories();

            containerRegistry.RegisterCommands();

            containerRegistry.RegisterQueries();

            containerRegistry.RegisterViews();
        }
    }
}
