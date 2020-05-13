using System.Collections.Generic;
using WeightTracker.Business;

namespace WeightTracker.Wpf.Business
{
    public class Data
    {
        public IEnumerable<Exercise> Exercises { get; set; }

        public IEnumerable<WeightEntry> WeightEntries { get; set; }
    }
}
