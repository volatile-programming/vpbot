using Prism.Ioc;
using PVBot.Application.Contracts;
using PVBot.Application.Factories;
using PVBot.Clients.UI.Views;
using PVBot.ViewModels;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PVBot.Clients.UI
{
    public static class IocConfig
    {
        public static void RegisterServices(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICommandFactory, CommandFactory>();
            containerRegistry.RegisterSingleton<IQueryFactory, QueryFactory>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
        }

        public static void RegisterCommands(this IContainerRegistry containerRegistry)
        {

        }

        public static void RegisterQueries(this IContainerRegistry containerRegistry)
        {

        }

        public static void RegisterViews(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ChatView, ChatViewModel>();
        }
    }
}
