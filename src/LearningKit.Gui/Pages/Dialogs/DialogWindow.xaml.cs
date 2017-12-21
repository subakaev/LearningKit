using System.Windows.Controls;

namespace LearningKit.Gui.Pages.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow
    {
        public DialogWindow(Page page)
        {
            InitializeComponent();

            Title = page.Title;

            Frame.Navigate(page);
        }
    }
}
