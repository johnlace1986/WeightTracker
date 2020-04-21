using System.Windows;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for DistanceValueView.xaml
    /// </summary>
    public partial class DistanceValueView : ValueView
    {
        #region Dependency Properties

        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(DistanceValueView));

        public static readonly DependencyProperty ViewStyleProperty = DependencyProperty.Register("ViewStyle", typeof(DistanceViewStyle), typeof(DistanceValueView), new PropertyMetadata(DistanceViewStyle.Kilometers));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the distance currently displayed in the view
        /// </summary>
        public double Distance
        {
            get => (double)GetValue(DistanceProperty);
            set => SetValue(DistanceProperty, value);
        }

        /// <summary>
        /// Gets or sets the current style of the view
        /// </summary>
        public DistanceViewStyle ViewStyle
        {
            get => (DistanceViewStyle)GetValue(ViewStyleProperty);
            set => SetValue(ViewStyleProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the DistanceValueView class
        /// </summary>
        public DistanceValueView()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnDistanceViewKilometers_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = DistanceViewStyle.Miles;
        }

        private void btnDistanceViewMiles_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = DistanceViewStyle.Marathons;
        }

        private void btnDistanceViewMarathons_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = DistanceViewStyle.Kilometers;
        }

        #endregion
    }
}
