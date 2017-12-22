using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Pages;
using LearningKit.Gui.Services;

namespace LearningKit.Gui.ViewModels
{
    

    public class MainWindowViewModel
    {
        private readonly INavigationService navigationService;
        public ICommand ShowAddNewTaskPageCommand { get; }

        public MainWindowViewModel(INavigationService navigationService) {
            this.navigationService = navigationService;
            ShowAddNewTaskPageCommand = new RelayCommand(() => navigationService.Navigate(new AddNewExcercisePage()));
        }
    }
}
