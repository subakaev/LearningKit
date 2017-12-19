using System.Text;
using System.Windows.Input;
using LearningKit.Gui.Commands;

namespace LearningKit.Gui.ViewModels
{
    class AddNewTaskPageViewModel : ViewModelBase
    {
        private string taskText;
        private string solutionText;
        private string answerText;

        public string TaskText {
            get => taskText;
            set {
                taskText = value;
                OnPropertyChanged();
            }
        }

        public string SolutionText {
            get => solutionText;
            set {
                solutionText = value;
                OnPropertyChanged();
            }
        }

        public string AnswerText {
            get => answerText;
            set {
                answerText = value;
                OnPropertyChanged();
            }
        }

        private string previewText;

        public string PreviewText {
            get => previewText;
            set {
                previewText = value;
                OnPropertyChanged();
            }
        }

        private bool canUpdatePreview;

        public bool CanUpdatePreview {
            get => canUpdatePreview;
            set {
                canUpdatePreview = value;
                OnPropertyChanged();
            }
        }

        public ICommand PreviewCommand { get; }

        public AddNewTaskPageViewModel() {
            PreviewCommand = new RelayCommand(BuildPreview);
        }

        private void BuildPreview() {
            PreviewText = "";

            var builder = new StringBuilder();

            builder.Append("<html><head><meta charset='UTF-8'/></head><body>");

            builder.Append("<h1>Условие:</h1>");
            builder.Append(!string.IsNullOrWhiteSpace(TaskText) ? TaskText.Replace("\r\n", "<br/>") : "<i>Ничего нет</i>");

            builder.Append("<h1>Решение:</h1>");
            builder.Append(!string.IsNullOrWhiteSpace(SolutionText) ? SolutionText : "<i>Ничего нет</i>");

            builder.Append("<h1>Ответ:</h1>");
            builder.Append(!string.IsNullOrWhiteSpace(AnswerText) ? AnswerText : "<i>Ничего нет</i>");

            builder.Append("</body></html>");

            PreviewText = builder.ToString();
        }
    }
}
