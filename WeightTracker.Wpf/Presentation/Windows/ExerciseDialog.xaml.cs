using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using business = WeightTracker.Business;

namespace WeightTracker.Wpf.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ExerciseDialog.xaml
    /// </summary>
    public partial class ExerciseDialog : Window
    {
        #region Dependency Properties

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(ExerciseDialog));

        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance", typeof(double), typeof(ExerciseDialog));

        public static readonly DependencyProperty TimeTakenProperty = DependencyProperty.Register("TimeTaken", typeof(TimeSpan), typeof(ExerciseDialog));

        public static readonly DependencyProperty CaloriesBurnedProperty = DependencyProperty.Register("CaloriesBurned", typeof(int), typeof(ExerciseDialog));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date the exercise took place
        /// </summary>
        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        /// <summary>
        /// Gets or sets the time it took for the exercise to complete
        /// </summary>
        public TimeSpan TimeTaken
        {
            get => (TimeSpan)GetValue(TimeTakenProperty);
            set => SetValue(TimeTakenProperty, value);
        }

        /// <summary>
        /// Gets or sets the distance that was exercise in kilometers
        /// </summary>
        public double Distance
        {
            get => (double)GetValue(DistanceProperty);
            set => SetValue(DistanceProperty, value);
        }

        /// <summary>
        /// Gets or sets the number of calories that were burned during the exercise
        /// </summary>
        public int CaloriesBurned
        {
            get => (int)GetValue(CaloriesBurnedProperty);
            set => SetValue(CaloriesBurnedProperty, value);
        }

        /// <summary>
        /// Gets or sets the exercise currently displayed in the view
        /// </summary>
        public business.Exercise Exercise
        {
            get
            {
                var exercise = new business.Exercise
                {
                    Date = Date,
                    Distance = Distance, 
                    TimeTaken = TimeTaken,
                    CaloriesBurned = CaloriesBurned
                };

                return exercise;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Exercise class
        /// </summary>
        public ExerciseDialog()
        {
            InitializeComponent();

            Date = DateTime.Now;
            Distance = 0;
            TimeTaken = new TimeSpan();
            CaloriesBurned = 0;
        }

        /// <summary>
        /// Initialises a new instance of the Exercise class
        /// </summary>
        /// <param name="exercises">All exercises currently in the system</param>
        public ExerciseDialog(IEnumerable<business.Exercise> exercises)
            : this()
        {
            if (exercises.Any())
            {
                //group exercises by distance and order by number of exercises in the group
                var groups =
                (from exercise in exercises
                 group exercise by exercise.Distance into distances
                 select new { Distance = distances.Key, Excercises = distances.ToArray() })
                .OrderBy(p => p.Excercises.Length);

                if (groups.Any())
                {
                    //get the group with the most exercises (the most commonly exercised distance)
                    var exercise = groups.Last();
                    Distance = exercise.Distance;

                    //use the average time taken and calories burned across the group
                    TimeTaken = TimeSpan.FromSeconds(exercise.Excercises.Sum(p => p.TimeTaken.TotalSeconds) / exercise.Excercises.Length);
                    CaloriesBurned = exercise.Excercises.Sum(p => p.CaloriesBurned) / exercise.Excercises.Length;
                }
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Submits the exercise
        /// </summary>
        private void SubmitExercise()
        {
            if (TimeTaken.TotalSeconds == 0)
            {
                MessageBox.Show("Please enter the time taken for the exercise.", this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Distance == 0)
            {
                MessageBox.Show("Please enter the distance of the exercise.", this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (CaloriesBurned == 0)
            {
                MessageBox.Show("Please enter the number of calories burned during the exercise.", this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            SubmitExercise();
        }

        #endregion
    }
}
