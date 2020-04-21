using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class WeightEntryTimeTakenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var allExercises = values[0] as IEnumerable<Exercise>;
            var allWeightEntries = values[1] as IEnumerable<WeightEntry>;
            var currentWeightEntry = values[2] as WeightEntry;

            var exercises = WeightEntryExercisesConverter.Convert(allExercises, allWeightEntries, currentWeightEntry);

            var timeTaken = TimeSpan.FromSeconds(exercises.Sum(p => p.TimeTaken.TotalSeconds));
            return timeTaken;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
