using LearningKit.Gui.ViewModels;

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

            DataContext = new AddNewTaskPageViewModel();
        }
    }
}
