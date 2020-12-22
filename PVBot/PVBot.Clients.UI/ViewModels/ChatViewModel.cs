using Prism.Navigation;

namespace PVBot.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public ChatViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Chat Page";
        }
    }
}
