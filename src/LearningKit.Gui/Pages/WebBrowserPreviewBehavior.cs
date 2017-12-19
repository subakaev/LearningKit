using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace LearningKit.Gui.Pages
{
    class WebBrowserPreviewBehavior : Behavior<WebBrowser>
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(WebBrowserPreviewBehavior), new PropertyMetadata("", OnPropertyChanged));

        public string Source {
            get => (string) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

//        public static readonly DependencyProperty CanUpdateProperty = DependencyProperty.Register("CanUpdate", typeof(bool), typeof(WebBrowserPreviewBehavior), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var behavior = d as WebBrowserPreviewBehavior;

            if (string.IsNullOrWhiteSpace(behavior?.Source))
                return;

            behavior.AssociatedObject?.NavigateToString(behavior.Source);
        }

        protected override void OnAttached() {
            base.OnAttached();
        }

        protected override void OnDetaching() {
            base.OnDetaching();
        }
    }
}
