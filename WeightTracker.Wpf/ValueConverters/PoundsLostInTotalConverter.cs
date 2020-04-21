using System;
using System.Windows.Data;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsLostInTotalConverter : IValueConverter
    {
        #region Static Methods

        /// <summary>
        /// Gets the pounds that have been lost in total since the system's start date
        /// </summary>
        /// <param name="currentWeight">Current weight in pounds</param>
        /// <returns>Pounds that have been lost in total since the system's start date</returns>
        public static double Convert(double currentWeight)
        {
            return Settings.Default.StartWeight - currentWeight;
        }

        #endregion

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pounds = (double)value;
            return Convert(pounds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
