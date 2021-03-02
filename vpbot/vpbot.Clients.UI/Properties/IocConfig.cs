using AutoMapper;
using Prism.Ioc;
using SQLite;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

using VPBot.Application.Factories;
using VPBot.Clients.UI.Views;
using VPBot.ViewModels;
using VPBot.Application.Commands;
using VPBot.Application.Queries;
using VPBot.Clients.UI.ViewModels;
using VPBot.Application.Repositories;
using VPBot.Clients.UI.Factories;
using VPBot.Clients.Portable.Controls;
using VPBot.DataObjects.Contracts.Factories;
using VPBot.DataObjects.Contracts.Services;
using VPBot.DataObjects.Contracts.Core;
using VPBot.Clients.UI.Persistences;
using VPBot.DataObjects.Models;
using VPBot.Clients.UI.Commands;

#if MOCK
using VPBot.Application.Mock.Services;
#else
using VPBot.Application.Services;
#endif

namespace VPBot.Clients.UI.Properties
{
    public static class IocConfig
    {
        public static void RegisterServices(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IApplicationConfig, ApplicationConfig>();
            containerRegistry.RegisterScoped<IIdentityClientService, IdentityClientService>();
            containerRegistry.RegisterScoped<IChatbotService, ChatbotService>();
            containerRegistry.RegisterScoped<IAppCenterService, AppCenterService>();

            containerRegistry.RegisterInstance<IMapper>(new Mapper(MapperConfig.CreateConfiguration()));
            containerRegistry.RegisterSingleton(typeof(IRepository<>), typeof(Repository<>));
            containerRegistry.RegisterScoped<IUnitOfWork, UnitOfWork>();

            containerRegistry.RegisterScoped(typeof(IPersistence<>), typeof(SqlitePersistence<>));
            containerRegistry.RegisterInstance(
                new SQLiteConnection(PersistenceConfig.DatabasePath,
                PersistenceConfig.SqliteFlags));
            containerRegistry.RegisterInstance(
                new SQLiteAsyncConnection(PersistenceConfig.DatabasePath,
                PersistenceConfig.SqliteFlags));
        }

        public static void RegisterFactories(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<ICommandFactory, CommandFactory>();
            containerRegistry.RegisterScoped<IQueryFactory, QueryFactory>();
            containerRegistry.RegisterScoped<IPersistenceFactory, PersistenceFactory>();
        }

        public static void RegisterCommands(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<AuthenticateUserCommand>();
            containerRegistry.RegisterScoped<NavigateToChatCommand>();
            containerRegistry.RegisterScoped<SendMessageCommand>();
            containerRegistry.RegisterScoped<SaveStateCommand>();
        }

        public static void RegisterQueries(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<GetMessagesQuery>();
        }

        public static void RegisterViews(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ChatView, ChatViewModel>();
            containerRegistry.RegisterForNavigation<OptionsView, OptionsViewModel>();

            containerRegistry.RegisterScoped<MessageCard>();
            containerRegistry.RegisterScoped<ChatbotViewModel>();
            containerRegistry.RegisterScoped<IChatBoxModel, ChatBoxViewModel>();
        }
    }
}
