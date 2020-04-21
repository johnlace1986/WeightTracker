using System;

namespace WeightTracker.Business
{
    public interface IDatedItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the date of the item
        /// </summary>
        DateTime Date { get; set; }

        #endregion
    }
}
