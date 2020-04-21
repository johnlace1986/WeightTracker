using System.Windows;
using System.Windows.Controls;
using WeightTracker.Business;

namespace WeightTracker.Wpf.TemplateSelectors
{
    public class DatedItemTemplateSelector : DataTemplateSelector
    {
        #region Properties

        /// <summary>
        /// Gets or sets the template used for weight entries
        /// </summary>
        public DataTemplate WeightEntryTemplate { get; set; }

        public DataTemplate ExerciseTemplate { get; set; }

        #endregion

        #region DataTemplateSelector Members

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case WeightEntry _:
                    return WeightEntryTemplate;
                case Exercise _:
                    return ExerciseTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }

        #endregion
    }
}
