using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PVBot.Clients.Portable.Controls;

namespace PVBot.Clients.UI
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            //var testCI = Container.Resolve<MessageCard>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            XF.Material.Forms.Material.Init(this);
            Portable.PVBotPortable.Init(this);

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
