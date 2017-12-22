using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LearningKit.Data;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Pages.Dialogs;
using LearningKit.Gui.Services;
using LearningKit.Gui.Startup;

namespace LearningKit.Gui.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private readonly ISectionsStorage sectionsStorage;

        public ObservableCollection<Section> Sections { get; private set; }

        public MainPageViewModel(ISectionsStorage sectionsStorage) {
            this.sectionsStorage = sectionsStorage;
            ShowAddSectionDialogCommand = new RelayCommand(() => {

                var result = AutofacContainer.Resolve<IDialogService>().Show<AddNewSectionPage>(new AddNewSectionPageViewModel(sectionsStorage));

                if (result == true) {
                    Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
                    OnPropertyChanged(nameof(Sections));
                }
            });

            sectionsStorage.Load();
            Sections = new ObservableCollection<Section>(sectionsStorage.Sections);
        }

        public ICommand ShowAddSectionDialogCommand { get; }
    }
}
