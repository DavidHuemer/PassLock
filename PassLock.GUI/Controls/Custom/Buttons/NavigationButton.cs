using PassLock.GUI.Controls.Default;
using System;
using System.Windows;

namespace PassLock.GUI.Controls.Custom.Buttons
{
    public class NavigationButton : ExButton
    {
        #region Icon Template

        public DataTemplate IconTemplate
        {
            get { return (DataTemplate)GetValue(IconTemplateProperty); }
            set { SetValue(IconTemplateProperty, value); }
        }

        public static readonly DependencyProperty IconTemplateProperty = DependencyProperty.Register(
            nameof(IconTemplate), typeof(Uri), typeof(NavigationButton), new PropertyMetadata(null));

        #endregion

        #region Is Selected

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
          nameof(IsSelected), typeof(bool), typeof(NavigationButton), new PropertyMetadata(false));

        #endregion

        #region ItemsCount

        public int? ItemsCount
        {
            get { return (int?)GetValue(ItemsCountProperty); }
            set { SetValue(ItemsCountProperty, value); }
        }

        public static readonly DependencyProperty ItemsCountProperty = DependencyProperty.Register(
          nameof(ItemsCount), typeof(int?), typeof(NavigationButton), new PropertyMetadata(null));

        #endregion
    }
}
