using System;
using System.Windows;
using System.Windows.Data;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PaceViewVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var current = (PaceViewStyle)value;
            var compare = (PaceViewStyle)Enum.Parse(typeof(PaceViewStyle), parameter.ToString());

            if (current == compare)
                return Visibility.Visible;

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
