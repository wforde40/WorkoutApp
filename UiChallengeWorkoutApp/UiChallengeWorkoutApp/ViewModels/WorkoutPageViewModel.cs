using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;
using UiChallengeWorkoutApp.Services;
using UiChallengeWorkoutApp.MobileAppService.Models;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace UiChallengeWorkoutApp.ViewModels
{
    public class WorkoutPageViewModel : BaseViewModel
    {
        public IExerciseDataStore DataStore => DependencyService.Get<ExerciseDatastore>();

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get => _icon;
            set 
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<ExerciseViewModel> _exercises;
        public IEnumerable<ExerciseViewModel> Exercises
        {
            get => _exercises;
            set
            {
                _exercises = value;
                OnPropertyChanged();
            }
        }

        private Workout _currentWorkout;
        public Workout CurrentWorkout
        {
            get => _currentWorkout;
            set
            {
                _currentWorkout = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<WorkoutDayData> _completedWorkouts;
        public ObservableCollection<WorkoutDayData> CompletedWorkouts
        {
            get => _completedWorkouts;
            set
            {
                _completedWorkouts = value;
                OnPropertyChanged();
            }
        }

        private ICommand _getExerciseCommand;
        public ICommand GetExercisesCommand
        {
            get => _getExerciseCommand;
            set
            {
                _getExerciseCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _getCompletedWorkoutsCommand;
        public ICommand GetCompletedWorkoutsCommand
        {
            get => _getCompletedWorkoutsCommand;
            set
            {
                _getCompletedWorkoutsCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _completeWorkorkoutCommand;
        public ICommand CompleteWorkoutCommand
        {
            get => _completeWorkorkoutCommand;
            set
            {
                _completeWorkorkoutCommand = value;
                OnPropertyChanged();
            }
        }

        private async Task CompleteWorkout()
        {

            try
            {
                var data = new WorkoutDayData()
                {
                    WorkoutDate = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    WorkoutID = CurrentWorkout.Id,
                    UserID = 1,
                    Done = true
                };

                var results = await DataStore.AddCompletedWorkout(data);

                var oldDay = CompletedWorkouts
                    .Single<WorkoutDayData>(p => DateTime.Compare(p.DateCompleted.Date, data.WorkoutDate.Date) == 0);

                CompletedWorkouts.Remove(oldDay);
                CompletedWorkouts.Add(data);
                var ordered = CompletedWorkouts.OrderBy(p => p.WorkoutDate).ToList();
                CompletedWorkouts.Clear();

                foreach(var workout in ordered)
                {
                    CompletedWorkouts.Add(workout);
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }


        }

        private async Task GetExercises(string category, string type)
        {
            try
            {
                var results = await DataStore.GetRandomAsync(category, type);

                CurrentWorkout = results;
                Exercises = results?.Exercises?.Select(
                    (p, i) =>
                    new ExerciseViewModel(index: (i + 1).ToString() + ".", name: p?.Name)) ?? new List<ExerciseViewModel>();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private async Task GetCompletedWorkouts(CompletedWorkoutArgs args)
        {
            try
            {
                CompletedWorkouts.Clear();
                var list = new List<WorkoutDayData>();
                var results = await DataStore.GetCompletedWorkouts(args);

                if (results is null) { return; }

                list.AddRange(results);

                var startDate = DateTime.Now.DayOfWeek switch
                {
                    DayOfWeek.Friday => DateTime.Now.Date.AddDays(-5),
                    DayOfWeek.Monday => DateTime.Now.Date.AddDays(-1),
                    DayOfWeek.Saturday => DateTime.Now.Date.AddDays(-6),
                    DayOfWeek.Sunday => DateTime.Now.Date,
                    DayOfWeek.Thursday => DateTime.Now.Date.AddDays(-4),
                    DayOfWeek.Tuesday => DateTime.Now.Date.AddDays(-2),
                    DayOfWeek.Wednesday => DateTime.Now.Date.AddDays(-3),
                    _ => DateTime.Now.Date,
                };

                for (var i = 0; i < 7; i++)
                {
                    var date = startDate.AddDays(i);
                    var contains = results.Any(p => DateTime.Compare(p.WorkoutDate.Date, date.Date) == 0);

                    if (!contains)
                    {
                        list.Add(new WorkoutDayData
                        {
                            WorkoutDate = date,
                        });
                    }

                }

                list = list.OrderBy(p => p.WorkoutDate).ToList();


                foreach (var element in list)
                {
                    CompletedWorkouts.Add(element);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public WorkoutPageViewModel(string category, string type, int workoutDays)
        {
            Category = category;
            Exercises = new List<ExerciseViewModel>();
            CompletedWorkouts = new ObservableCollection<WorkoutDayData>();

            Icon = category switch
            {
                "Arms" => "ArmSelected.png",
                "Abs" => "AbsSelected.png",
                "Butt" => "RearSelected.png",
                "Legs" => "LegSelected.png",
                "Back" => "BackSelected.png",
                "Chest" => "ChestSelected.png",
                _ => "ArmSelected.png"
            };

            GetExercisesCommand = new Command(async () => await GetExercises(category, type));
            GetCompletedWorkoutsCommand = new Command<CompletedWorkoutArgs>(async (CompletedWorkoutArgs args) => await GetCompletedWorkouts(args));
            CompleteWorkoutCommand = new Command(async () => await CompleteWorkout());
        }
    }
}
