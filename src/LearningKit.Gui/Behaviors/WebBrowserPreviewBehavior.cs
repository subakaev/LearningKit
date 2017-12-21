using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace LearningKit.Gui.Behaviors
{
    class WebBrowserPreviewBehavior : Behavior<WebBrowser>
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(WebBrowserPreviewBehavior), new PropertyMetadata("", OnPropertyChanged));

        public string Source {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var behavior = d as WebBrowserPreviewBehavior;

            if (string.IsNullOrWhiteSpace(behavior?.Source))
                return;

            behavior.AssociatedObject?.NavigateToString(behavior.Source);
        }
    }
}
