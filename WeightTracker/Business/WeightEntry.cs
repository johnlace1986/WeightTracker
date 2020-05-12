using System;
using System.Xml;
using Utilities.Business;

namespace WeightTracker.Business
{
    public class WeightEntry : NotifyPropertyChangedObject, IDatedItem, IComparable<WeightEntry>
    {
        #region Fields

        /// <summary>
        /// Gets or sets the date and time the weight entry was taken
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Gets or sets the value of the weight entry in pounds
        /// </summary>
        private double value;

        /// <summary>
        /// Gets or sets a value determining whether or not the weight entry can be expanded
        /// </summary>
        private bool canExpand;

        /// <summary>
        /// Gets or sets a value determining whether or not the weight entry should be saved
        /// </summary>
        private bool shouldSave;

        /// <summary>
        /// Gets or sets a value determining whether or not the run list of the weight entry has been expanded in the UI
        /// </summary>
        private bool isRunListExpanded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the weight entry in pounds
        /// </summary>
        public double Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// Gets or sets a value determining whether or not the weight entry can be expanded
        /// </summary>
        public bool CanExpand
        {
            get => canExpand;
            set
            {
                canExpand = value;
                OnPropertyChanged("CanExpand");
            }
        }

        /// <summary>
        /// Gets or sets a value determining whether or not the weight entry should be saved
        /// </summary>
        public bool ShouldSave
        {
            get => shouldSave;
            set
            {
                shouldSave = value;
                OnPropertyChanged("ShouldSave");
            }
        }

        /// <summary>
        /// Gets or sets a value determining whether or not the run list of the weight entry has been expanded in the UI
        /// </summary>
        public bool IsRunListExpanded
        {
            get => isRunListExpanded;
            set
            {
                isRunListExpanded = value;
                OnPropertyChanged("IsRunListExpanded");
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WeightEntry class
        /// </summary>
        public WeightEntry()
        {
            Date = DateTime.Now;
            Value = 0;
            CanExpand = true;
            ShouldSave = true;
            IsRunListExpanded = false;
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets the number of pounds in a stone
        /// </summary>
        public static int PoundsPerStone => 14;

        /// <summary>
        /// Gets the number of pounds in a kilogram
        /// </summary>
        public static float PoundsPerKilogram => 2.20462F;

        #endregion

        #region Static Methods

        /// <summary>
        /// Converts the specified pounds value to stones (rounded down)
        /// </summary>
        /// <param name="pounds">Pounds being converted</param>
        /// <param name="stones">Result of the conversion in stones (rounded down)</param>
        /// <param name="remainingPounds">Pounds left over after the stones have been converted</param>
        public static void ConvertPoundsToStones(double pounds, out int stones, out double remainingPounds, out bool negative)
        {
            negative = false;

            if (pounds < 0)
            {
                negative = true;
                pounds = -pounds;
            }

            stones = 0;
            remainingPounds = pounds;

            while (remainingPounds >= PoundsPerStone)
            {
                stones++;
                remainingPounds -= PoundsPerStone;
            }
        }

        /// <summary>
        /// Converts the specified pounds value to kilograms
        /// </summary>
        /// <param name="pounds">Pounds being converted</param>
        /// <returns>Kilograms equal in weight to the specified number of pounds</returns>
        public static float ConvertPoundsToKilograms(float pounds)
        {
            return pounds / PoundsPerKilogram;
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

        #region IComparable<WeightEntry> Members

        public int CompareTo(WeightEntry other)
        {
            return other.Date.CompareTo(Date);
        }

        #endregion
    }
}
