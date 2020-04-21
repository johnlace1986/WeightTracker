using WeightTracker.Business;

namespace WeightTracker.Wpf.EventArgs
{
    public delegate void ExerciseEventHandler(object sender, ExerciseEventArgs e);

    public class ExerciseEventArgs : System.EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets or sets the exercise being raised by the event
        /// </summary>
        public Exercise Exercise { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the ExerciseEventArgs class
        /// </summary>
        /// <param name="exercise">Exercise being raised by the event</param>
        public ExerciseEventArgs(Exercise exercise)
        {
            Exercise = exercise;
        }

        #endregion
    }
}
