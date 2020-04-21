using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class MinutesPerMileConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var distance = Exercise.ConvertKilometersToMiles((double)values[0]);
            var timeTaken = (TimeSpan)values[1];

            var minutes = 0;
            var seconds = 0;

            if (distance > 0)
            {

                var secondsPerMile = timeTaken.TotalSeconds / distance;
                var pace = TimeSpan.FromSeconds(secondsPerMile);

                minutes = pace.Minutes;
                seconds = pace.Seconds;
            }

            return $"{minutes:00}:{seconds:00} min/mile";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
