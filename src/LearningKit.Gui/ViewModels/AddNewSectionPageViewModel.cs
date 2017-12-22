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

        public event EventHandler Complete;

        public AddNewSectionPageViewModel(ISectionsStorage sectionsStorage) {
            this.sectionsStorage = sectionsStorage;

            AddNewSectionCommand = new RelayCommand(OnAddNewSectionCommandExecute);
        }

        private void OnAddNewSectionCommandExecute() {
            sectionsStorage.Sections.Add(new Section(Name));
            Complete?.Invoke(this, EventArgs.Empty);
        }

        public string Name { get; set; }

        public ICommand AddNewSectionCommand { get; }
    }
}
