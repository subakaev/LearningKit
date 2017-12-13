using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Pages;

namespace LearningKit.Gui.ViewModels
{
    public interface INavigator
    {
        void Navigate(Page page);
    }

    class Navigator : INavigator
    {
        private readonly NavigationService navigationService;

        public Navigator(NavigationService navigationService) {
            this.navigationService = navigationService;
        }

        public void Navigate(Page page) {
            navigationService.Navigate(page);
        }
    }

    public class MainWindowViewModel
    {
        private readonly INavigator navigator;
        public ICommand ShowAddNewTaskPageCommand { get; }

        public MainWindowViewModel(INavigator navigator) {
            this.navigator = navigator;
            ShowAddNewTaskPageCommand = new RelayCommand(() => navigator.Navigate(new AddNewExcercisePage()));
        }
    }
}
