using System.Windows;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for WeightValueView.xaml
    /// </summary>
    public partial class WeightValueView : ValueView
    {
        #region Dependency Properties

        public static readonly DependencyProperty WeightProperty = DependencyProperty.Register("Weight", typeof(double), typeof(WeightValueView));

        public static readonly DependencyProperty ViewStyleProperty = DependencyProperty.Register("ViewStyle", typeof(WeightViewStyle), typeof(WeightValueView), new PropertyMetadata(WeightViewStyle.Stones));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the weight currently displayed in the view
        /// </summary>
        public double Weight
        {
            get => (double)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }

        /// <summary>
        /// Gets or sets the current style of the view
        /// </summary>
        public WeightViewStyle ViewStyle
        {
            get => (WeightViewStyle)GetValue(ViewStyleProperty);
            set => SetValue(ViewStyleProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WeightValueView class
        /// </summary>
        public WeightValueView()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnValueViewStones_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = WeightViewStyle.StonesFraction;
        }

        private void btnValueViewStonesFraction_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = WeightViewStyle.Pounds;
        }

        private void btnValueViewPounds_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = WeightViewStyle.Kilograms;
        }

        private void btnValueViewKilograms_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = WeightViewStyle.Stones;
        }

        #endregion
    }
}
