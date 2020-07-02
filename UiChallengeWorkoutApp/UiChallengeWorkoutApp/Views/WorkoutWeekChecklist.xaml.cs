using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.Models;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutWeekChecklist : ContentView
    {

        public static BindableProperty CompletedProperty =
            BindableProperty.Create(nameof(Completed), typeof(IEnumerable<WorkoutDayData>), typeof(WorkoutWeekChecklist));

        public IEnumerable<WorkoutDayData> Completed
        {
            get => GetValue(CompletedProperty) as IEnumerable<WorkoutDayData>;
            set => SetValue(CompletedProperty, value);
        }

        public WorkoutWeekChecklist()
        {
            InitializeComponent();
        }
    }
}