using Prism.Commands;
using Prism.Navigation;

namespace PVBot.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public ChatViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Chat Page";

            GotoOptions = new DelegateCommand(GotoOptionsCommand);
        }

        public DelegateCommand GotoOptions { get; }
        public DelegateCommand GotoInformation { get; }

        private void GotoOptionsCommand()
        {
        }
    }
}
