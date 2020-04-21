using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class MilesPerHourConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var distance = (double)values[0];
            var timeTaken = (TimeSpan)values[1];

            var kilometersPerHour = KilometersPerHourConverter.Convert(distance, timeTaken);
            return Exercise.ConvertKilometersToMiles(kilometersPerHour);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
