using System;
using System.Windows.Controls;
using LearningKit.Gui.Pages.Dialogs;

namespace LearningKit.Gui.Services
{
    public interface IDialogPageViewModel
    {
        event EventHandler Complete;
    }

    interface IDialogService
    {
        bool? Show<TPage>(IDialogPageViewModel viewModel) where TPage : Page, new();
    }

    class DialogService : IDialogService
    {
        public bool? Show<TPage>(IDialogPageViewModel viewModel) where TPage : Page, new() {
            return new DialogWindow(new TPage(), viewModel).ShowDialog();
        }
    }
}
