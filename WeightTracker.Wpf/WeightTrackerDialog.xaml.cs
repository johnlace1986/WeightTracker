﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeightTracker.Wpf.Presentation.Windows;
using WeightTracker.Wpf.Properties;
using business = WeightTracker.Business;

namespace WeightTracker.Wpf
{
    /// <summary>
    /// Interaction logic for WeightTrackerDialog.xaml
    /// </summary>
    public partial class WeightTrackerDialog : Window
    {
        #region Dependency Properties

        public static readonly DependencyProperty ExercisesProperty = DependencyProperty.Register("Exercises", typeof(business.Exercise[]), typeof(WeightTrackerDialog));

        public static readonly DependencyProperty WeightEntriesProperty = DependencyProperty.Register("WeightEntries", typeof(business.WeightEntry[]), typeof(WeightTrackerDialog));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the exercises currently in the system
        /// </summary>
        public business.Exercise[] Exercises
        {
            get => GetValue(ExercisesProperty) as business.Exercise[];
            set => SetValue(ExercisesProperty, value);
        }

        /// <summary>
        /// Gets or sets the weight entries currently in the system
        /// </summary>
        public business.WeightEntry[] WeightEntries
        {
            get => GetValue(WeightEntriesProperty) as business.WeightEntry[];
            set => SetValue(WeightEntriesProperty, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the WeightTrackerDialog class
        /// </summary>
        public WeightTrackerDialog()
        {
            InitializeComponent();

            Exercises = new business.Exercise[0];
            WeightEntries = new business.WeightEntry[0];
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Loads the data from an XML file
        /// </summary>
        private async Task LoadData()
        {
            using var reader = new StreamReader(Settings.Default.DataFile);
            var data = JsonConvert.DeserializeObject<Business.Data>(await reader.ReadToEndAsync());

            Exercises = data.Exercises
                .OrderBy(exercise => exercise.Date)
                .ToArray();

            WeightEntries = data.WeightEntries
                .OrderBy(weightEntry => weightEntry.Date)
                .Union(new []
                {
                    new business.WeightEntry
                    {
                        CanExpand = false,
                        Date = Settings.Default.StartDate,
                        ShouldSave = false,
                        Value = Settings.Default.StartWeight
                    }
                })
                .ToArray();
        }

        /// <summary>
        /// Saves the data to an XML file
        /// </summary>
        private void SaveData()
        {
            using var writer = new StreamWriter(Settings.Default.DataFile);
            var serialiser = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            serialiser.Serialize(writer, new Business.Data
            {
                Exercises = Exercises.OrderBy(exercise => exercise.Date),
                WeightEntries = WeightEntries.Where(weightEntry => weightEntry.ShouldSave).OrderBy(weightEntry => weightEntry.Date)
            });
        }

        /// <summary>
        /// Deletes the specified weight entry
        /// </summary>
        /// <param name="weightEntry">Weight entry being deleted</param>
        private void DeleteWeightEntry(business.WeightEntry weightEntry)
        {
            if (MessageBox.Show("Are you sure you want to delete this weight entry?", Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            WeightEntries = WeightEntries.Where(p => p != weightEntry).ToArray();
            SaveData();
        }

        /// <summary>
        /// Deletes the specified exercise
        /// </summary>
        /// <param name="exercise">Exercise being deleted</param>
        private void DeleteExercise(business.Exercise exercise)
        {
            if (MessageBox.Show("Are you sure you want to delete this exercise?", Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            Exercises = Exercises.Where(p => p != exercise).ToArray();
            SaveData();
        }

        #endregion

        #region Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void WeightEntryView_DeletedWeightEntry(object sender, EventArgs.WeightEntryEventArgs e)
        {
            DeleteWeightEntry(e.WeightEntry);
        }

        private void WeightEntryView_DeletedExercise(object sender, EventArgs.ExerciseEventArgs e)
        {
            DeleteExercise(e.Exercise);
        }

        private void ExerciseView_DeletedExercise(object sender, EventArgs.ExerciseEventArgs e)
        {
            DeleteExercise(e.Exercise);
        }

        private void btnAddWeightEntry_Click(object sender, RoutedEventArgs e)
        {
            var currentWeight = WeightEntries.Length == 0 ? Settings.Default.StartWeight : WeightEntries.OrderBy(p => p.Date).Last().Value;

            var wed = new WeightEntryDialog(currentWeight)
            {
                Owner = this
            };

            if (wed.ShowDialog() != true) 
                return;

            var weightEntry = new business.WeightEntry
            {
                Date = wed.Date, 
                Value = wed.GetWeight()
            };

            var weightEntries = new List<business.WeightEntry>(WeightEntries)
            {
                weightEntry
            };

            weightEntries.Sort();
            WeightEntries = weightEntries.ToArray();

            SaveData();
        }

        private void btnAddExercise_Click(object sender, RoutedEventArgs e)
        {
            var ed = new ExerciseDialog(Exercises)
            {
                Owner = this
            };

            if (ed.ShowDialog() != true) 
                return;

            var exercises = new List<business.Exercise>(Exercises)
            {
                ed.Exercise
            };

            exercises.Sort();

            Exercises = exercises.ToArray();
            SaveData();
        }

        #endregion
    }
}
