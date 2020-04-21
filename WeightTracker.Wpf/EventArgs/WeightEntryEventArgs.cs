using WeightTracker.Business;

namespace WeightTracker.Wpf.EventArgs
{
    public delegate void WeightEntryEventHandler(object sender, WeightEntryEventArgs e);

    public class WeightEntryEventArgs : System.EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets or sets the weight entry being raised by the event
        /// </summary>
        public WeightEntry WeightEntry { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WeightEntryEventArgs class
        /// </summary>
        /// <param name="weightEntry">Weight entry being raised by the event</param>
        public WeightEntryEventArgs(WeightEntry weightEntry)
        {
            WeightEntry = weightEntry;
        }

        #endregion
    }
}
