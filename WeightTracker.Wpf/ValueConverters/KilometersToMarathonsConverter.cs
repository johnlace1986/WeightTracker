using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class KilometersToMarathonsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var kilometers = (double)value;
            return Exercise.ConvertKilometersToMarathons(kilometers);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
