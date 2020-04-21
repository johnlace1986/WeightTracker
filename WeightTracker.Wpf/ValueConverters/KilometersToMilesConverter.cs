using System;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class KilometersToMilesConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var kilometers = (double)value;
            return Exercise.ConvertKilometersToMiles(kilometers);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
