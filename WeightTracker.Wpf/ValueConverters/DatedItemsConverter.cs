using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using WeightTracker.Business;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class DatedItemsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var weightEntries = values[0] as IEnumerable<WeightEntry>;
            var exercises = values[1] as IEnumerable<Exercise>;

            var mostRecent = weightEntries.OrderByDescending(weightEntry => weightEntry.Date).FirstOrDefault();

            var items = new List<IDatedItem>();
            items.AddRange(weightEntries);
            items.AddRange(exercises.Where(exercise => 
                exercise.Date < Settings.Default.StartDate ||
                (mostRecent != null && exercise.Date > mostRecent.Date)));

            return items.OrderByDescending(p => p.Date);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
