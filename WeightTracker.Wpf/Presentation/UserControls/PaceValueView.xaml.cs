using System;
using System.Windows;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for PaceValueView.xaml
    /// </summary>
    public partial class PaceValueView : ValueView
    {
        #region Dependency Properties

        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(PaceValueView));

        public static readonly DependencyProperty TimeTakenProperty = DependencyProperty.Register("TimeTaken", typeof(TimeSpan), typeof(PaceValueView));

        public static readonly DependencyProperty ViewStyleProperty = DependencyProperty.Register("ViewStyle", typeof(PaceViewStyle), typeof(PaceValueView), new PropertyMetadata(PaceViewStyle.MinutesPerKilometer));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the distance of the pace displayed in the view
        /// </summary>
        public double Distance
        {
            get => (double)GetValue(DistanceProperty);
            set => SetValue(DistanceProperty, value);
        }

        /// <summary>
        /// Gets or sets the time taken of the pace displayed in the view
        /// </summary>
        public TimeSpan TimeTaken
        {
            get => (TimeSpan)GetValue(TimeTakenProperty);
            set => SetValue(TimeTakenProperty, value);
        }

        /// <summary>
        /// Gets or sets the current style of the view
        /// </summary>
        public PaceViewStyle ViewStyle
        {
            get => (PaceViewStyle)GetValue(ViewStyleProperty);
            set => SetValue(ViewStyleProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the PaceValueView class
        /// </summary>
        public PaceValueView()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnPaceViewMinutesPerKilometer_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = PaceViewStyle.MinutesPerMile;
        }

        private void btnPaceViewMinutesPerMile_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = PaceViewStyle.KilometersPerHour;
        }

        private void btnPaceViewKilometersPerHour_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = PaceViewStyle.MilesPerHour;
        }

        private void btnPaceViewMilesPerHour_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = PaceViewStyle.MinutesPerKilometer;
        }

        #endregion
    }
}
