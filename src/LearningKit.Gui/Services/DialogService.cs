using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LearningKit.Gui.Pages.Dialogs;

namespace LearningKit.Gui.Services
{
    interface IDialogService
    {
        void Show(Page page);
    }

    class DialogService : IDialogService
    {
        public void Show(Page page) {
            new DialogWindow(page) {Owner = App.Current.MainWindow}.ShowDialog();
        }
    }
}
