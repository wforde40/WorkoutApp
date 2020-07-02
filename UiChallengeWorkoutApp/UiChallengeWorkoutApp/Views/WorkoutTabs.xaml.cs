using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutTabs : ContentView
    {
        public static BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(IEnumerable), typeof(WorkoutTabs));

        public static BindableProperty SelectedProperty = 
            BindableProperty.Create(nameof(Selected), typeof(int), typeof(WorkoutTabs), defaultBindingMode:BindingMode.TwoWay);

        public IEnumerable Items
        {
            get => GetValue(ItemsProperty) as IEnumerable;
            set => SetValue(ItemsProperty, value); 
        }

        public int Selected
        {
            get => (int)GetValue(SelectedProperty);
            set => SetValue(SelectedProperty, value);
        }

        public WorkoutTabs()
        {
            InitializeComponent();
        }
    }
}