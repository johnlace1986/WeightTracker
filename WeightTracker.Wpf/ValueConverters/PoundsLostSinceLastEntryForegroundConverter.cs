using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using WeightTracker.Business;

namespace WeightTracker.Wpf.ValueConverters
{
    public class PoundsLostSinceLastEntryForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var weightEntry = values[0] as WeightEntry;
            var weightEntries = values[1] as IEnumerable<WeightEntry>;

            var poundsLostSinceLastEntry = PoundsLostSinceLastEntryConverter.Convert(weightEntry, weightEntries);

            if (poundsLostSinceLastEntry < 0)
                return Application.Current.FindResource("errorBrush");

            return Application.Current.FindResource("textBrush");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
