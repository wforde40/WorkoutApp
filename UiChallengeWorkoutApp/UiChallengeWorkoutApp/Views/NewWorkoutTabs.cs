using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;

namespace UiChallengeWorkoutApp.Views
{
    public class NewWorkoutTabs : ContentView
    {

        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<string>), typeof(NewWorkoutTabs), propertyChanged: OnItemsChanged);

        private static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {




        }

        public ObservableCollection<string> Items
        {
            get { return GetValue(ItemsProperty) as ObservableCollection<string>; }
            set { SetValue(ItemsProperty, value); }
        }


        public NewWorkoutTabs()
        {
            Content = new CollectionView()
            { 
                ItemsLayout = LinearItemsLayout.Horizontal,
                ItemTemplate = new DataTemplate(typeof(WorkoutChoiceTab)),
                Margin = new Thickness(5),
                HeightRequest = 35,
            };

        }
    }
}