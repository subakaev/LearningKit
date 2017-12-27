using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LearningKit.Data;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Services;

namespace LearningKit.Gui.ViewModels
{
    class AddNewSectionPageViewModel : ViewModelBase, IDialogPageViewModel
    {
        private readonly ISectionsStorage sectionsStorage;
        private readonly Section parent;

        public event EventHandler Complete;

        public AddNewSectionPageViewModel(ISectionsStorage sectionsStorage, Section parent) {
            this.sectionsStorage = sectionsStorage;
            this.parent = parent;

            AddNewSectionCommand = new RelayCommand(OnAddNewSectionCommandExecute);
        }

        private void OnAddNewSectionCommandExecute() {
            sectionsStorage.AddSection(parent, Name);
            Complete?.Invoke(this, EventArgs.Empty);
        }

        public string Name { get; set; }

        public ICommand AddNewSectionCommand { get; }
    }

    class EditSectionPageViewModel : ViewModelBase, IDialogPageViewModel
    {
        private readonly ISectionsStorage sectionsStorage;
        private readonly Section section;

        public event EventHandler Complete;

        public EditSectionPageViewModel(ISectionsStorage sectionsStorage, Section section) {
            this.sectionsStorage = sectionsStorage;
            this.section = section;
            Name = section.Name;

            AddNewSectionCommand = new RelayCommand(() => {
                section.Name = Name;
                sectionsStorage.Save();
                Complete?.Invoke(this, EventArgs.Empty);
            });
        }

        public string Name { get; set; }

        public ICommand AddNewSectionCommand { get; }
    }
}
