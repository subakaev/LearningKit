using System.Windows;
using LearningKit.Data;

namespace LearningKit.Gui.Pages
{
    /// <summary>
    /// Interaction logic for AddNewExcercisePage.xaml
    /// </summary>
    public partial class AddNewExcercisePage
    {
        public AddNewExcercisePage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            var data = new DataStorage();
            data.Save();

            if (!string.IsNullOrWhiteSpace(TextBox.Text))
                WebBrowser.NavigateToString(TextBox.Text);
        }
    }
}
