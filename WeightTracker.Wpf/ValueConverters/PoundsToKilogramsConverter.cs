using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsToKilogramsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var pounds = (double)value;

            return WeightEntry.ConvertPoundsToKilograms((float)pounds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}