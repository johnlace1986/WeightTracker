using System.Windows;
using System.Windows.Controls;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    public abstract class ValueView : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty ToggleButtonStyleProperty = DependencyProperty.Register("ToggleButtonStyle", typeof(Style), typeof(ValueView));

        #endregion

        #region Properties

        public Style ToggleButtonStyle
        {
            get => GetValue(ToggleButtonStyleProperty) as Style;
            set => SetValue(ToggleButtonStyleProperty, value);
        }

        #endregion
    }
}
