using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class DateItemGroupsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var item = value as IDatedItem;

            return item.Date.ToString("MMMM yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
