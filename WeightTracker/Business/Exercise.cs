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

        #region Instance Methods

        /// <summary>
        /// Converts the exercise to an XML element
        /// </summary>
        /// <param name="document">XML document the element will be added to</param>
        /// <returns>XML element containing the data for the exercise</returns>
        public XmlElement ToXml(XmlDocument document)
        {
            var exercise = document.CreateElement("EXCERCISE");

            var date = document.CreateAttribute("Date");
            date.Value = Date.ToString();
            exercise.Attributes.Append(date);

            var timeTaken = document.CreateAttribute("TimeTaken");
            timeTaken.Value = TimeTaken.TotalSeconds.ToString();
            exercise.Attributes.Append(timeTaken);

            var distance = document.CreateAttribute("Distance");
            distance.Value = Distance.ToString();
            exercise.Attributes.Append(distance);

            var caloriesBurned = document.CreateAttribute("CaloriesBurned");
            caloriesBurned.Value = CaloriesBurned.ToString();
            exercise.Attributes.Append(caloriesBurned);

            return exercise;
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
        /// Loads a weight entry from the data found in the specified XML node
        /// </summary>
        /// <param name="xml">XML node containing the data for the weight entry</param>
        /// <returns>Weight entry loaded from the data found in the specified XML node</returns>
        public static Exercise FromXml(XmlNode xml)
        {
            var date = DateTime.Parse(xml.Attributes["Date"].Value);
            var timeTaken = TimeSpan.FromSeconds(int.Parse(xml.Attributes["TimeTaken"].Value));
            var distance = double.Parse(xml.Attributes["Distance"].Value);
            var caloriesBurned = int.Parse(xml.Attributes["CaloriesBurned"].Value);

            var exercise = new Exercise
            {
                Date = date,
                TimeTaken = timeTaken, 
                Distance = distance, 
                CaloriesBurned = caloriesBurned
            };

            return exercise;
        }

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
