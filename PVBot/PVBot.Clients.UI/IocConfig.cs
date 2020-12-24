using Prism.Ioc;
using PVBot.Application.Factories;
using PVBot.Clients.UI.Views;
using PVBot.DataObjects.Contracts;
using PVBot.ViewModels;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

#if MOCK
using PVBot.Application.Mock.Services;
#else
using PVBot.Application.Services;
#endif

namespace PVBot.Clients.UI
{
    public static class IocConfig
    {
        public static void RegisterServices(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterScoped<IAuth0Service, Auth0Service>();
            containerRegistry.RegisterScoped<ITwilioService, TwilioService>();
            containerRegistry.RegisterScoped<IAppCenterService, AppCenterService>();
        }

        public static void RegisterFactories(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<ICommandFactory, CommandFactory>();
            containerRegistry.RegisterScoped<IQueryFactory, QueryFactory>();
        }

        public static void RegisterCommands(this IContainerRegistry containerRegistry)
        {

        }

        public static void RegisterQueries(this IContainerRegistry containerRegistry)
        {

        }

        public static void RegisterViews(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ChatView, ChatViewModel>();
        }
    }
}
