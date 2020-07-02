using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms.PancakeView;
using UiChallengeWorkoutApp.Models;
using System.Windows.Input;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPage : ContentPage
    {

        WorkoutPageViewModel ViewModel;

        public WorkoutPage()
        {
            InitializeComponent();
        }


        public WorkoutPage(string category, string type)
        {
            BindingContext = ViewModel = new WorkoutPageViewModel(category, type, 7);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
                    
            ViewModel.GetExercisesCommand.Execute(ViewModel.Category);
            var args = new CompletedWorkoutArgs() { Id = 1, Days = 6};
            ViewModel.GetCompletedWorkoutsCommand.Execute(args);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}