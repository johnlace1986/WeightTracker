using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsToStonesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WeightEntry.ConvertPoundsToStones((double)value, out var stones, out var remainingPounds, out var negative);

            var parsed = $"{stones} st {remainingPounds:0.0} lbs";

            return (negative ? "-" : "") + parsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
