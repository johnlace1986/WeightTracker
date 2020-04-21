using System;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeeksConverter : IMultiValueConverter
    {
        #region Static Properties

        /// <summary>
        /// Gets the number of days in a week
        /// </summary>
        private static int DaysPerWeek => 7;

        #endregion

        #region Static Methods

        /// <summary>
        /// Gets the weeks between the specified start and end dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Weeks between the specified start and end dates</returns>
        public static double Convert(DateTime startDate, DateTime endDate)
        {
            var daysDieting = DaysConverter.Convert(startDate, endDate);

            return daysDieting / DaysPerWeek;
        }

        #endregion

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var startDate = (DateTime)values[0];
            var endDate = (DateTime)values[1];

            return Convert(startDate, endDate);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
