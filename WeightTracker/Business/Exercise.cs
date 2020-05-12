using System;
using System.Xml;
using Utilities.Business;

namespace WeightTracker.Business
{
    public class Exercise : NotifyPropertyChangedObject, IDatedItem, IComparable<Exercise>
    {        
        #region Fields

        /// <summary>
        /// Gets or sets the date the exercise took place
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Gets or sets the time it took for the exercise to complete
        /// </summary>
        private TimeSpan timeTaken;

        /// <summary>
        /// Gets or sets the distance that was exercise in kilometers
        /// </summary>
        private double distance;

        /// <summary>
        /// Gets or sets the number of calories that were burned during the exercise
        /// </summary>
        private int caloriesBurned;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the time it took for the exercise to complete
        /// </summary>
        public TimeSpan TimeTaken
        {
            get => timeTaken;
            set
            {
                timeTaken = value;
                OnPropertyChanged("TimeTaken");
            }
        }

        /// <summary>
        /// Gets or sets the distance that was exercise in kilometers
        /// </summary>
        public double Distance
        {
            get => distance;
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        /// <summary>
        /// Gets or sets the number of calories that were burned during the exercise
        /// </summary>
        public int CaloriesBurned
        {
            get => caloriesBurned;
            set
            {
                caloriesBurned = value;
                OnPropertyChanged("CaloriesBurned");
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the Exercise class
        /// </summary>
        public Exercise()
        {
            Date = DateTime.Now;
            TimeTaken = new TimeSpan();
            Distance = 0;
            CaloriesBurned = 0;
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets or sets the number of miles in a kilometer
        /// </summary>
        public static float MilesPerKilometer => 0.6213712F;

        /// <summary>
        /// Gets or sets the number of miles in a marathon
        /// </summary>
        public static double MilesPerMarathon => 26.2;

        #endregion

        #region Static Methods
        
        /// <summary>
        /// Converts the specified kilometers to miles
        /// </summary>
        /// <param name="kilometers">Kilometers being converted</param>
        /// <returns>Miles converted from the specified kilometers</returns>
        public static double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * MilesPerKilometer;
        }

        /// <summary>
        /// Converts the specified kilometers to marathons
        /// </summary>
        /// <param name="kilometers">Kilometers being converted</param>
        /// <returns>Marathons converted from the specified kilometers</returns>
        public static double ConvertKilometersToMarathons(double kilometers)
        {
            var miles = ConvertKilometersToMiles(kilometers);
            return miles / MilesPerMarathon;
        }

        #endregion

        #region IDatedItem Members

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        #endregion

        #region IComparable<Exercise> Members

        public int CompareTo(Exercise other)
        {
            return Date.CompareTo(other.Date);
        }

        #endregion
    }
}
