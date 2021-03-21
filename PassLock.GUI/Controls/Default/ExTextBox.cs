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
