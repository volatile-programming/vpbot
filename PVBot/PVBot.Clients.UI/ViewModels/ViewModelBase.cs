using Ardalis.GuardClauses;
using Prism.Mvvm;
using Prism.Navigation;

namespace PVBot.Clients.UI.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        public ViewModelBase() { }

        public ViewModelBase(INavigationService navigationService)
        {
            Guard.Against.Null(navigationService, nameof(navigationService));

            NavigationService = navigationService;
        }

        protected INavigationService NavigationService { get; private set; }

        public string Title { get; set; }

        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void Destroy() { }
    }
}
