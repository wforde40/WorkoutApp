namespace UiChallengeWorkoutApp.ViewModels
{
    public class WorkoutDate : BaseViewModel
    {

        private string _dayOfWeek;
        public string DayOfWeek
        {
            get => _dayOfWeek;
            set
            {
                _dayOfWeek = value;
                OnPropertyChanged();
            }
        }

        private bool _completed;
        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                OnPropertyChanged();
            }
        }

    }
}