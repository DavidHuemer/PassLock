using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PassLock.GUI.Controls.Default
{
    public class ExTextBox : TextBox
    {
        #region Default Values

        readonly static CornerRadius DefaultCornerRadiusValue = new CornerRadius(0);
        readonly static string DefaultHintValue = "Enter Text!";
        readonly static Brush DefaultHintForegroundValue = new BrushConverter().ConvertFromString("#FFBEE6FD") as Brush;
        readonly static Brush DefaultFocusBorderBrushValue = new BrushConverter().ConvertFromString("#56c1d6") as Brush;

        #endregion

        public ExTextBox()
        {

        }

        #region CornerRadius

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
          nameof(CornerRadius), typeof(CornerRadius), typeof(ExTextBox), new PropertyMetadata(DefaultCornerRadiusValue));

        #endregion

        #region FocusBorderBrush

        public Brush FocusBorderBrush
        {
            get { return (Brush)GetValue(FocusBorderBrushProperty); }
            set { SetValue(FocusBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty FocusBorderBrushProperty = DependencyProperty.Register(
          nameof(FocusBorderBrush), typeof(Brush), typeof(ExTextBox), new PropertyMetadata(DefaultFocusBorderBrushValue));

        #endregion

        #region Hint

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty = DependencyProperty.Register(
          nameof(Hint), typeof(string), typeof(ExTextBox), new PropertyMetadata(DefaultHintValue));

        #endregion

        #region HintForeground

        public Brush HintForeground
        {
            get { return (Brush)GetValue(HintForegroundProperty); }
            set { SetValue(HintForegroundProperty, value); }
        }

        public static readonly DependencyProperty HintForegroundProperty = DependencyProperty.Register(
          nameof(HintForeground), typeof(Brush), typeof(ExTextBox), new PropertyMetadata(DefaultHintForegroundValue));

        #endregion
    }
}
