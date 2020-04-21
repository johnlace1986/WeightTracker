using System;
using System.Windows.Data;
using WeightTracker.Business;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class LosingPerWeekConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var weightEntry = value as WeightEntry;

            var weeksDieting = WeeksConverter.Convert(Settings.Default.StartDate, weightEntry.Date);
            var poundsLostInTotal = PoundsLostInTotalConverter.Convert(weightEntry.Value);

            return poundsLostInTotal / weeksDieting;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
