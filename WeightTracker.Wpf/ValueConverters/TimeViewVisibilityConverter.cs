using System;
using System.Windows;
using System.Windows.Data;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class TimeViewVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var current = (TimeViewStyle)value;
            var compare = (TimeViewStyle)Enum.Parse(typeof(TimeViewStyle), parameter.ToString());

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
