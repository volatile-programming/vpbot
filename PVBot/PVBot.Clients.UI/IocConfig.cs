using AutoMapper;
using Prism.Ioc;
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
            containerRegistry.RegisterScoped<IChatbotService, ChatbotService>();
            containerRegistry.RegisterScoped<IAppCenterService, AppCenterService>();

            containerRegistry.RegisterSingleton<MessagesRepository>();
            containerRegistry.RegisterScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            containerRegistry.RegisterScoped(typeof(IPersistence<>), typeof(Persistence<>));
            containerRegistry.RegisterInstance<IMapper>(new Mapper(CreateConfiguration()));
        }

        public static void RegisterFactories(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<IRepositoryFactory, RepositoryFactory>();
            containerRegistry.RegisterScoped<ICommandFactory, CommandFactory>();
            containerRegistry.RegisterScoped<IQueryFactory, QueryFactory>();
            containerRegistry.RegisterScoped<IPersistenceFactory, PersistenceFactory>();
        }

        public static void RegisterCommands(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<AuthenticateUserCommand>();
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
            containerRegistry.RegisterScoped<MessageViewModel>();
        }

        private static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(IocConfig).Assembly);
            });

            return config;
        }
    }
}
