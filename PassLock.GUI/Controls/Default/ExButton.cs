using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PassLock.GUI.Controls.Default
{
    public class ExButton : Button
    {
        #region Default Values
        readonly static Brush DefaultHoverBackgroundValue = new BrushConverter().ConvertFromString("#FFBEE6FD") as Brush;
        readonly static Brush DefaultHoverBorderBrushValue = new BrushConverter().ConvertFromString("#b5b5b5") as Brush;
        readonly static CornerRadius DefaultCornerRadiusValue = new CornerRadius(0);
        #endregion

        #region Hover Background

        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register(
          nameof(HoverBackground), typeof(Brush), typeof(ExButton), new PropertyMetadata(DefaultHoverBackgroundValue));

        #endregion

        #region HoverBorderBrush

        public Brush HoverBorderBrush
        {
            get { return (Brush)GetValue(HoverBorderBrushProperty); }
            set { SetValue(HoverBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverBorderBrushProperty = DependencyProperty.Register(
          nameof(HoverBorderBrush), typeof(Brush), typeof(ExButton), new PropertyMetadata(DefaultHoverBorderBrushValue));

        #endregion

        #region CornerRadius

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
          nameof(CornerRadius), typeof(CornerRadius), typeof(ExButton), new PropertyMetadata(DefaultCornerRadiusValue));

        #endregion
    }
}
