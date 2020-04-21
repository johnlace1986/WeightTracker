using System;
using System.Windows.Data;

namespace WeightTracker.Wpf.ValueConverters
{
    public class DaysConverter : IMultiValueConverter
    {
        #region Static Methods

        /// <summary>
        /// Gets the days between the specifed start and end dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Days between the specifed start and end dates</returns>
        public static double Convert(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays;
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
