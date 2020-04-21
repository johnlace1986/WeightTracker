using System;
using System.Windows;
using System.Windows.Data;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeightViewVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var current = (WeightViewStyle)value;
            var compare = (WeightViewStyle)Enum.Parse(typeof(WeightViewStyle), parameter.ToString());

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
