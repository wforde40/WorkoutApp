using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace UiChallengeWorkoutApp.ViewModels
{
    public class WorkoutCategoryViewModel
    {
        public ImageSource ImgSource { get; set; }
        public string Text { get; set; }
        public ICommand GoToWorkoutPage { get; set; }
    }
}
