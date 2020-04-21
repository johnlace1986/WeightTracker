using System;
using System.Windows;
using WeightTracker.Wpf.Business;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for TimeValueView.xaml
    /// </summary>
    public partial class TimeValueView : ValueView
    {
        #region Dependency Properties

        public static readonly DependencyProperty StartDateProperty = DependencyProperty.Register("StartDate", typeof(DateTime), typeof(TimeValueView));

        public static readonly DependencyProperty EndDateProperty = DependencyProperty.Register("EndDate", typeof(DateTime), typeof(TimeValueView));

        public static readonly DependencyProperty ViewStyleProperty = DependencyProperty.Register("ViewStyle", typeof(TimeViewStyle), typeof(TimeValueView), new PropertyMetadata(TimeViewStyle.Weeks));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the start date of the time displayed in the view
        /// </summary>
        public DateTime StartDate
        {
            get => (DateTime)GetValue(StartDateProperty);
            set => SetValue(StartDateProperty, value);
        }

        /// <summary>
        /// Gets or sets the end date of the time displayed in the view
        /// </summary>
        public DateTime EndDate
        {
            get => (DateTime)GetValue(EndDateProperty);
            set => SetValue(EndDateProperty, value);
        }

        /// <summary>
        /// Gets or sets the current style of the view
        /// </summary>
        public TimeViewStyle ViewStyle
        {
            get => (TimeViewStyle)GetValue(ViewStyleProperty);
            set => SetValue(ViewStyleProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the TimeValueView class
        /// </summary>
        public TimeValueView()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnTimeViewDays_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = TimeViewStyle.Weeks;
        }

        private void btnTimeViewWeeks_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = TimeViewStyle.Months;
        }

        private void btnTimeViewMonths_Click(object sender, RoutedEventArgs e)
        {
            ViewStyle = TimeViewStyle.Days;
        }

        #endregion
    }
}
