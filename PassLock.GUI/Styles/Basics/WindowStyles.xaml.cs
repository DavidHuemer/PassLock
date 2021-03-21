using System.Windows;

namespace PassLock.GUI.Styles.Basics
{
    public partial class WindowStyles : ResourceDictionary
    {
        public WindowStyles()
        {
            InitializeComponent();
        }

        public void CloseClick(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(sender);
            window.Close();
        }

        public void MaximizeRestoreClick(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(sender);

            if (window.WindowState == WindowState.Normal)
                window.WindowState = WindowState.Maximized;
            else
                window.WindowState = WindowState.Normal;
        }

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(sender);
            window.WindowState = WindowState.Minimized;
        }

        private Window GetWindow(object sender)
        {
            return (Window)((FrameworkElement)sender).TemplatedParent;
        }
    }
}
