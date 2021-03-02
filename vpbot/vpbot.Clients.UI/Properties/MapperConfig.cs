using AutoMapper;
using VPBot.Clients.UI.ViewModels;
using VPBot.DataObjects.Models;

namespace VPBot.Clients.UI.Properties
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ChatBoxViewModel, MessageViewModel>();

            CreateMap<MessageViewModel, TextMessage>();
            CreateMap<MessageViewModel, VoiceMessage>();
            CreateMap<MessageViewModel, ImageMessage>();
            CreateMap<MessageViewModel, FileMessage>();
        }

        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(IocConfig).Assembly);
            });

            return config;
        }
    }
}
