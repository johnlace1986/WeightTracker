using System;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class MonthsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var startDate = (DateTime)values[0];
            var endDate = (DateTime)values[1];

            return (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month + (endDate.Day >= startDate.Day ? 0 : -1);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
