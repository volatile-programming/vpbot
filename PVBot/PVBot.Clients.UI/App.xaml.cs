using Prism;
using Prism.Ioc;

namespace PVBot.Clients.UI
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices();

            containerRegistry.RegisterCommands();

            containerRegistry.RegisterQueries();

            containerRegistry.RegisterViews();
        }
    }
}
