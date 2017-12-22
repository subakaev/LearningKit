using System;
using System.Net.Mime;
using System.Windows.Controls;
using LearningKit.Gui.Services;

namespace LearningKit.Gui.Pages.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow
    {
        public DialogWindow(Page page, IDialogPageViewModel viewModel)
        {
            InitializeComponent();

            Owner = App.Current.MainWindow;

            Title = page.Title;

            page.DataContext = viewModel;

            viewModel.Complete += OnComplete;

            Frame.Navigate(page);
        }

        private void OnComplete(object sender, EventArgs e) {
            DialogResult = true;
            Close();
        }
    }
}
