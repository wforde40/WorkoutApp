using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutChoicePage : ContentPage
    {
        private WorkoutChoiceViewModel ViewModel { get; set; }

        public WorkoutChoicePage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new WorkoutChoiceViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Categories.Count <= 0)
                ViewModel.GetCategoriesCommand.Execute(null);
            
            if (ViewModel.Tabs.Count <= 0)
                ViewModel.GetTypesCommand.Execute(null);
        }

    }
}