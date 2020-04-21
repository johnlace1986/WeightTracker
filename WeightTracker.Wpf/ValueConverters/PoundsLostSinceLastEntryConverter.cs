using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using WeightTracker.Business;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsLostSinceLastEntryConverter : IMultiValueConverter
    {
        #region Static Methods

        /// <summary>
        /// Gets the weight lost in pounds of the current weight entry since the previous weight entry
        /// </summary>
        /// <param name="currentWeightEntry">Current weight entry</param>
        /// <param name="weightEntries">All weight entries in the system</param>
        /// <returns>Weight lost in pounds of the current weight entry since the previous weight entry</returns>
        public static double Convert(WeightEntry currentWeightEntry, IEnumerable<WeightEntry> weightEntries)
        {
            var previousEntry = weightEntries.OrderBy(p => p.Date).LastOrDefault(p => p.Date < currentWeightEntry.Date);
            var previousWeight = (previousEntry == null ? Settings.Default.StartWeight : previousEntry.Value);

            return previousWeight - currentWeightEntry.Value;
        }

        #endregion

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var weightEntry = (WeightEntry)values[0];
            var weightEntries = (IEnumerable<WeightEntry>)values[1];

            return Convert(weightEntry, weightEntries);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
