using System;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class KilometersPerHourConverter : IMultiValueConverter
    {
        #region Static Methods

        /// <summary>
        /// Gets the pace in kilometers per hour
        /// </summary>
        /// <param name="distance">Distance travelled</param>
        /// <param name="timeTaken">Time taken to travel the distance</param>
        /// <returns>Pace in kilometers per hour</returns>
        public static double Convert(double distance, TimeSpan timeTaken)
        {
            if (distance == 0)
                return 0;

            return distance / timeTaken.TotalHours;
        }

        #endregion
        
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var distance = (double)values[0];
            var timeTaken = (TimeSpan)values[1];

            var kilometersPerHour = Convert(distance, timeTaken);

            return kilometersPerHour;// String.Format("{0:00} kmph", kilometersPerHour);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
