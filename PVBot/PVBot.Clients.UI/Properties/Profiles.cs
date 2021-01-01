using AutoMapper;

using PVBot.Clients.UI.ViewModels;
using PVBot.DataObjects.Models;

namespace PVBot.Clients.UI.Properties
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<MessageViewModel, TextMessage>();
            CreateMap<MessageViewModel, VoiceMessage>();
            CreateMap<MessageViewModel, ImageMessage>();
            CreateMap<MessageViewModel, FileMessage>();
        }
    }
}
