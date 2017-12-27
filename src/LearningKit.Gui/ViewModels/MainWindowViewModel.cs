using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using LearningKit.Data;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Events;
using LearningKit.Gui.Pages;
using LearningKit.Gui.Services;
using Prism.Events;

namespace LearningKit.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public ICommand ShowAddNewTaskPageCommand { get; }

        public string CurrentSectionName { get; set; }

        public MainWindowViewModel(INavigationService navigationService, IEventAggregator eventAggregator) {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            ShowAddNewTaskPageCommand = new RelayCommand(() => navigationService.Navigate(new AddNewExcercisePage()));

            eventAggregator.GetEvent<SectionChangedEvent>().Subscribe(OnSectionChanged);
        }

        private void OnSectionChanged(Section obj) {
            CurrentSectionName = obj?.Name ?? "root";
            OnPropertyChanged(nameof(CurrentSectionName));
        }
    }
}