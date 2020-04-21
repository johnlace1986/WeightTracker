using System;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class MinutesPerKilometerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var distance = (double)values[0];
            var timeTaken = (TimeSpan)values[1];

            var minutes = 0;
            var seconds = 0;

            if (distance > 0)
            {

                var secondsPerKilometer = timeTaken.TotalSeconds / distance;
                var pace = TimeSpan.FromSeconds(secondsPerKilometer);

                minutes = pace.Minutes;
                seconds = pace.Seconds;
            }

            return $"{minutes:00}:{seconds:00} min/km";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
