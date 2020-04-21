using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WeightTracker.Business;
using WeightTracker.Wpf.EventArgs;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for WeightEntryView.xaml
    /// </summary>
    public partial class WeightEntryView : UserControl
    {
        #region Events

        public event WeightEntryEventHandler DeletedWeightEntry;

        public event ExerciseEventHandler DeletedExercise;

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty WeightEntryProperty = DependencyProperty.Register("WeightEntry", typeof(WeightEntry), typeof(WeightEntryView));

        public static readonly DependencyProperty WeightEntriesProperty = DependencyProperty.Register("WeightEntries", typeof(IEnumerable<WeightEntry>), typeof(WeightEntryView), new PropertyMetadata(new WeightEntry[0]));

        public static readonly DependencyProperty ExercisesProperty = DependencyProperty.Register("Exercises", typeof(IEnumerable<Exercise>), typeof(WeightEntryView), new PropertyMetadata(new Exercise[0]));

        public static readonly DependencyProperty SelectedExerciseProperty = DependencyProperty.Register("SelectedExercise", typeof(Exercise), typeof(WeightEntryView));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(WeightEntryView), new PropertyMetadata(false));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the weight entry currently displayed in the view
        /// </summary>
        public WeightEntry WeightEntry
        {
            get => GetValue(WeightEntryProperty) as WeightEntry;
            set => SetValue(WeightEntryProperty, value);
        }

        /// <summary>
        /// Gets or sets all weight entries in the system
        /// </summary>
        public IEnumerable<WeightEntry> WeightEntries
        {
            get => GetValue(WeightEntriesProperty) as IEnumerable<WeightEntry>;
            set => SetValue(WeightEntriesProperty, value);
        }

        /// <summary>
        /// Gets or sets all exercises in the system
        /// </summary>
        public IEnumerable<Exercise> Exercises
        {
            get => GetValue(ExercisesProperty) as IEnumerable<Exercise>;
            set => SetValue(ExercisesProperty, value);
        }

        /// <summary>
        /// Gets or sets the currently selected exercise
        /// </summary>
        public Exercise SelectedExercise
        {
            get => GetValue(SelectedExerciseProperty) as Exercise;
            set => SetValue(SelectedExerciseProperty, value);
        }

        /// <summary>
        /// Gets or sets a value determining whether or not the view is expanded
        /// </summary>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Intialises a new instance of the WeightEntryView class
        /// </summary>
        public WeightEntryView()
        {
            InitializeComponent();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Fires the DeletedWeightEntry event
        /// </summary>
        /// <param name="weightEntry">Weight entry being deleted</param>
        protected void OnDeletedWeightEntry(WeightEntry weightEntry)
        {
            if (DeletedWeightEntry != null)
                DeletedWeightEntry(this, new WeightEntryEventArgs(weightEntry));
        }

        protected void OnDeletedExercise(Exercise exercise)
        {
            if (DeletedExercise != null)
                DeletedExercise(this, new ExerciseEventArgs(exercise));
        }

        #endregion

        #region Event Handlers

        private void btnDeleteWeightEntry_Click(object sender, RoutedEventArgs e)
        {
            OnDeletedWeightEntry(WeightEntry);
        }

        private void btnExercise_OnClick(object sender, RoutedEventArgs e)
        {
            IsExpanded = true;
            SelectedExercise = ((FrameworkElement) e.OriginalSource).DataContext as Exercise;
        }

        private void btnDeleteExercise_Click(object sender, RoutedEventArgs e)
        {
            var btnDeleteExercise = sender as Button;
            var exercise = btnDeleteExercise.DataContext as Exercise;

            OnDeletedExercise(exercise);
        }

        #endregion
    }
}
