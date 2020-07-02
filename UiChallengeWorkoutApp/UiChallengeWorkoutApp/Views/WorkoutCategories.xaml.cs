using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutCategories : ContentView
    {
        public static BindableProperty CategoriesProperty =
            BindableProperty.Create("Categories", typeof(IEnumerable), typeof(WorkoutCategories));

        public static BindableProperty GoToWorkoutPageCommandProperty =
            BindableProperty.Create(nameof(GoToWorkoutPageCommand), typeof(ICommand), typeof(WorkoutItem));


        public IEnumerable Categories
        {
            get { return GetValue(CategoriesProperty) as IEnumerable; }
            set { SetValue(CategoriesProperty, value); }
        }

        public ICommand GoToWorkoutPageCommand
        {
            get => (ICommand)GetValue(GoToWorkoutPageCommandProperty);
            set => SetValue(GoToWorkoutPageCommandProperty, value);
        }

        public WorkoutCategories()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var pancake = sender as PancakeView;
            var category = pancake.Content as WorkoutItem;

            //await Navigation.PushAsync(new WorkoutPage(category));
            GoToWorkoutPageCommand.Execute(category.Text);


        }
    }
}