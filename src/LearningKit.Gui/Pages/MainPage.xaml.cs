using LearningKit.Gui.ViewModels;

namespace LearningKit.Gui.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();
        }
    }
}
