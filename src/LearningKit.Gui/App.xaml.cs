using System.Windows;
using LearningKit.Gui.Pages;
using LearningKit.Gui.Startup;
using LearningKit.Gui.ViewModels;

namespace LearningKit.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var window = AutofacContainer.Resolve<MainWindow>();

            window.Show();

            AutofacContainer.Resolve<INavigator>().Navigate(AutofacContainer.Resolve<MainPage>());
        }
    }
}
