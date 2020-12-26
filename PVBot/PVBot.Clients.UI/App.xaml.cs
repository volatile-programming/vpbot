using Prism;
using Prism.DryIoc;
using Prism.Ioc;

namespace PVBot.Clients.UI
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("LoginView");
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
