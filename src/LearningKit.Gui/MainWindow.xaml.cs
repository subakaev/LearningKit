using System.Windows.Navigation;
using Autofac;
using LearningKit.Gui.Startup;
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

            Startup.AutofacContainer.Container.Resolve<INavigator>(new TypedParameter(typeof(NavigationService), Frame.NavigationService));

            DataContext = Startup.AutofacContainer.Resolve<MainWindowViewModel>();
        }
    }
}
