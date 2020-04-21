using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using WeightTracker.Business;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeightEntryExercisesConverter : IMultiValueConverter
    {
        #region Static Methods

        /// <summary>
        /// Gets the exercises for the current weight entry
        /// </summary>
        /// <param name="allExercises">All exercises in the system</param>
        /// <param name="allWeightEntries">All weight entries in the system</param>
        /// <param name="currentWeightEntry">Current weight entry</param>
        /// <returns>Exercises for the current weight entry</returns>
        public static IEnumerable<Exercise> Convert(IEnumerable<Exercise> allExercises, IEnumerable<WeightEntry> allWeightEntries, WeightEntry currentWeightEntry)
        {
            var previousWeightEntry = allWeightEntries.OrderBy(p => p.Date).LastOrDefault(p => p.Date < currentWeightEntry.Date);
            var previousWeightEntryDate = previousWeightEntry == null ? Settings.Default.StartDate : previousWeightEntry.Date;

            return allExercises.Where(p => p.Date > previousWeightEntryDate && p.Date <= currentWeightEntry.Date).OrderBy(p => p.Date);
        }

        #endregion

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var allExercises = values[0] as IEnumerable<Exercise>;
            var allWeightEntries = values[1] as IEnumerable<WeightEntry>;
            var currentWeightEntry = values[2] as WeightEntry;

            return Convert(allExercises, allWeightEntries, currentWeightEntry);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
