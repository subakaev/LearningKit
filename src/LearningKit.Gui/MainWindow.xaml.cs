using LearningKit.Gui.ViewModels;

namespace LearningKit.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var navigator = new Navigator(Frame.NavigationService);

            DataContext = new MainWindowViewModel(navigator);
        }
    }
}
