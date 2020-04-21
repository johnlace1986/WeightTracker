using System;
using System.Windows;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class ExpandedContentRowHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isExpanded = (bool)value;

            if (isExpanded)
                return GridLength.Auto;

            return new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
