using AutoMapper;
using Prism.Ioc;
using SQLite;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

using PVBot.Application.Factories;
using PVBot.Clients.UI.Views;
using PVBot.ViewModels;
using PVBot.Application.Commands;
using PVBot.Application.Queries;
using PVBot.Clients.UI.ViewModels;
using PVBot.Application.Repositories;
using PVBot.Clients.UI.Factories;
using PVBot.Clients.Portable.Controls;
using PVBot.DataObjects.Contracts.Factories;
using PVBot.DataObjects.Contracts.Services;
using PVBot.DataObjects.Contracts.Core;
using PVBot.Clients.UI.Persistences;
using PVBot.DataObjects.Models;
using PVBot.Clients.UI.Commands;

#if MOCK
using PVBot.Application.Mock.Services;
#else
using PVBot.Application.Services;
#endif

namespace PVBot.Clients.UI.Properties
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
