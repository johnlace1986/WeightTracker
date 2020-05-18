using System;
using System.Windows;
using WeightTracker.Business;

namespace WeightTracker.Wpf.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for WeightEntryDialog.xaml
    /// </summary>
    public partial class WeightEntryDialog : Window
    {
        #region Dependency Properties

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(WeightEntryDialog), new PropertyMetadata(OnDatePropertyChanged));

        public static readonly DependencyProperty StonesProperty = DependencyProperty.Register("Stones", typeof(int), typeof(WeightEntryDialog));

        public static readonly DependencyProperty PoundsProperty = DependencyProperty.Register("Pounds", typeof(double), typeof(WeightEntryDialog));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date of the weight entry
        /// </summary>
        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        /// <summary>
        /// Gets or sets the stones component of the weight
        /// </summary>
        public int Stones
        {
            get => (int)GetValue(StonesProperty);
            set => SetValue(StonesProperty, value);
        }

        /// <summary>
        /// Gets or sets the pounds component of the weight
        /// </summary>
        public double Pounds
        {
            get => (double)GetValue(PoundsProperty);
            set => SetValue(PoundsProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WeightEntryDialog class
        /// </summary>
        /// <param name="currentWeight">Value of the most recent weight entry</param>
        public WeightEntryDialog(double currentWeight)
        {
            InitializeComponent();

            var currentDate = DateTime.Now;

            while (currentDate.DayOfWeek != DayOfWeek.Sunday)
                currentDate = currentDate.Subtract(TimeSpan.FromDays(1));

            Date = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);

            WeightEntry.ConvertPoundsToStones(currentWeight, out var stones, out var pounds, out _);

            Stones = stones;
            Pounds = pounds;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Gets the weight in pounds
        /// </summary>
        /// <returns></returns>
        public double GetWeight()
        {
            return (Stones * WeightEntry.PoundsPerStone) + Pounds;
        }

        /// <summary>
        /// Gets the weight
        /// </summary>
        /// <param name="currentWeight">Weight in pounds</param>
        public void SetWeight(double currentWeight)
        {
            WeightEntry.ConvertPoundsToStones(currentWeight, out var stones, out var pounds, out _);

            Stones = stones;
            Pounds = pounds;
        }

        /// <summary>
        /// Submits the weight entry
        /// </summary>
        private void SubmitWeightEntry()
        {
            DialogResult = true;
        }

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SubmitWeightEntry();
        }

        #endregion

        #region Static Methods

        private static void OnDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var wed = d as WeightEntryDialog;
            wed.Date = new DateTime(wed.Date.Year, wed.Date.Month, wed.Date.Day, 23, 59, 59);
        }

        #endregion
    }
}
