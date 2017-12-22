using System.IO;
using System.Windows;
using LearningKit.Data;
using LearningKit.Gui.Pages;
using LearningKit.Gui.Services;
using LearningKit.Gui.Startup;

namespace LearningKit.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            if (!Directory.Exists(LocationHelper.DataPath))
                Directory.CreateDirectory(LocationHelper.DataPath);

            var window = AutofacContainer.Resolve<MainWindow>();

            window.Show();

            AutofacContainer.Resolve<INavigationService>().Navigate(AutofacContainer.Resolve<MainPage>());
        }
    }
}
