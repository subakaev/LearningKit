using LearningKit.Data;
using LearningKit.Gui.Startup;
using LearningKit.Gui.ViewModels;
using Prism.Events;

namespace LearningKit.Gui.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        private readonly ISectionsStorage sectionsStorage;

        public MainPage(ISectionsStorage sectionsStorage)
        {
            this.sectionsStorage = sectionsStorage;

            InitializeComponent();

            DataContext = new MainPageViewModel(sectionsStorage, AutofacContainer.Resolve<IEventAggregator>());
        }
    }
}
