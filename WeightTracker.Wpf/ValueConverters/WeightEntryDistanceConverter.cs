using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeightEntryDistanceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var allExercises = values[0] as IEnumerable<Exercise>;
            var allWeightEntries = values[1] as IEnumerable<WeightEntry>;
            var currentWeightEntry = values[2] as WeightEntry;

            var exercise = WeightEntryExercisesConverter.Convert(allExercises, allWeightEntries, currentWeightEntry);

            var distanceRun = exercise.Sum(p => p.Distance);
            return distanceRun;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
