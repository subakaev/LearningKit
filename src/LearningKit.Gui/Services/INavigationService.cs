using System.Windows.Controls;
using System.Windows.Navigation;

namespace LearningKit.Gui.Services
{
    public interface INavigationService
    {
        void Navigate(Page page);
    }

    class Navigator : INavigationService
    {
        private readonly NavigationService navigationService;

        public Navigator(NavigationService navigationService) {
            this.navigationService = navigationService;
        }

        public void Navigate(Page page) {
            navigationService.Navigate(page);
        }
    }
}