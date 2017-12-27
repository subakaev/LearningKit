using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LearningKit.Data;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Events;
using LearningKit.Gui.Pages.Dialogs;
using LearningKit.Gui.Services;
using LearningKit.Gui.Startup;
using Prism.Events;

namespace LearningKit.Gui.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private readonly ISectionsStorage sectionsStorage;
        private readonly IEventAggregator eventAggregator;

        public ObservableCollection<Section> Sections { get; private set; }

        private Section root;

        public MainPageViewModel(ISectionsStorage sectionsStorage, IEventAggregator eventAggregator) {
            this.sectionsStorage = sectionsStorage;
            this.eventAggregator = eventAggregator;
            root = null;

            ShowAddSectionDialogCommand = new RelayCommand(() => {

                var result = AutofacContainer.Resolve<IDialogService>().Show<AddNewSectionPage>(new AddNewSectionPageViewModel(sectionsStorage, root));

                if (result == true) {
                    Sections = new ObservableCollection<Section>(root?.Children ?? sectionsStorage.Sections);
                    OnPropertyChanged(nameof(Sections));
                }
            });

            EditSectionCommand = new RelayCommand<Section>(s => {
                var result = AutofacContainer.Resolve<IDialogService>().Show<AddNewSectionPage>(new EditSectionPageViewModel(sectionsStorage, s));

                if (result == true)
                {
                    Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
                    OnPropertyChanged(nameof(Sections));
                }
            });

            DeleteSectionCommand = new RelayCommand<Guid>(guid => {
                if (MessageBox.Show("Удалить раздел, включая все подразделы?", "Удаление раздела", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    sectionsStorage.RemoveSection(guid);
                    Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
                    OnPropertyChanged(nameof(Sections));
                }
            });

            OpenSectionCommand = new RelayCommand<Section>(section => {
                Sections = new ObservableCollection<Section>(section.Children);
                root = section;
                eventAggregator.GetEvent<SectionChangedEvent>().Publish(section);
                OnPropertyChanged(nameof(Sections));
            });

            CloseSectionCommand = new RelayCommand(() => {
                if (root == null)
                    return;

                if (root.Parent == null) {
                    Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
                }
                else {
                    Sections = new ObservableCollection<Section>(root.Parent.Children ?? sectionsStorage.Sections);
                }

                OnPropertyChanged(nameof(Sections));
                root = root.Parent;

                eventAggregator.GetEvent<SectionChangedEvent>().Publish(root);
            });

            sectionsStorage.Load();
            Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
        }

        public ICommand ShowAddSectionDialogCommand { get; }

        public ICommand EditSectionCommand { get; }

        public ICommand DeleteSectionCommand { get; }

        public ICommand OpenSectionCommand { get; }

        public ICommand CloseSectionCommand { get; }
    }
}
