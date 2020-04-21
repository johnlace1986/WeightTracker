using System.Windows;
using System.Windows.Controls;
using WeightTracker.Wpf.EventArgs;
using business = WeightTracker.Business;

namespace WeightTracker.Wpf.Presentation.UserControls
{
    /// <summary>
    /// Interaction logic for RunView.xaml
    /// </summary>
    public partial class ExerciseView : UserControl
    {
        #region Events

        public event ExerciseEventHandler DeletedExercise;

        #endregion

        #region Dependency Properties

        public static readonly DependencyProperty ExerciseProperty = DependencyProperty.Register("Exercise", typeof(business.Exercise), typeof(ExerciseView));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the exercise currently displayed in the view
        /// </summary>
        public business.Exercise Exercise
        {
            get => GetValue(ExerciseProperty) as business.Exercise;
            set => SetValue(ExerciseProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the RunView class
        /// </summary>
        public ExerciseView()
        {
            InitializeComponent();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Fires the DeletedExercise event
        /// </summary>
        /// <param name="exercise">Exercise that was deleted</param>
        protected void OnDeletedExercise(business.Exercise exercise)
        {
            if (DeletedExercise != null)
                DeletedExercise(this, new ExerciseEventArgs(exercise));
        }

        #endregion

        #region Event Handlers

        private void btnDeleteExercise_Click(object sender, RoutedEventArgs e)
        {
            OnDeletedExercise(Exercise);
        }

        #endregion
    }
}
