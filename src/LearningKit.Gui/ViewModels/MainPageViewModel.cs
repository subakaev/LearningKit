using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LearningKit.Gui.Commands;
using LearningKit.Gui.Pages.Dialogs;
using LearningKit.Gui.Services;
using LearningKit.Gui.Startup;

namespace LearningKit.Gui.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel() {
            ShowAddSectionDialogCommand = new RelayCommand(() => {
                AutofacContainer.Resolve<IDialogService>().Show(new AddNewSectionPage());
            });
        }

        public ICommand ShowAddSectionDialogCommand { get; }
    }
}
