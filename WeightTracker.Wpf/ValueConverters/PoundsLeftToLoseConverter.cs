using System;
using System.Globalization;
using System.Windows.Data;
using WeightTracker.Wpf.Properties;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsLeftToLoseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pounds = (double)value;
            return pounds - Settings.Default.TargetWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
