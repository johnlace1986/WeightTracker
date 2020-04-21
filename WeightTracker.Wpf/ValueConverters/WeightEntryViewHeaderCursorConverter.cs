using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeightEntryViewHeaderCursorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var canExpand = (bool)value;

            return canExpand ? Cursors.Hand : Cursors.Arrow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
