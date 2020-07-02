using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutChoiceTab : ContentView
    {
        public static BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(WorkoutChoiceTab));

        public static BindableProperty SelectedProperty =
            BindableProperty.Create("Selected", typeof(bool), typeof(WorkoutChoiceTab), 
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: OnSelectedChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public bool Selected
        {
            get { return (bool)GetValue( SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }


        public static void OnSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var newSelected = (bool)newValue;
            var choiceTab = bindable as WorkoutChoiceTab;

            if (newSelected)
            {
                choiceTab.Pancake.BackgroundColor = Color.FromHex("#DBCFF9");
                choiceTab.TitleLabel.FontAttributes = FontAttributes.Bold;
                choiceTab.TitleLabel.TextColor = Color.FromHex("#641FFE");
            }
            else
            {
                choiceTab.Pancake.BackgroundColor = Color.Transparent;
                choiceTab.TitleLabel.FontAttributes = FontAttributes.None;
                choiceTab.TitleLabel.TextColor = Color.FromHex("#A2A7B3");
            }
        }

        public WorkoutChoiceTab()
         {
            InitializeComponent();

            WidthRequest = (DeviceDisplay.MainDisplayInfo.Width - Margin.HorizontalThickness) / 11;

            TitleLabel.SetBinding(Label.TextProperty, new Binding("Text", source: this));

            Pancake.BackgroundColor = Color.Transparent;
            TitleLabel.FontAttributes = FontAttributes.None;
            TitleLabel.TextColor = Color.FromHex("#A2A7B3");



        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tabsControl = this.Parent as CollectionView;
            var parent = tabsControl.Parent as WorkoutTabs;

            tabsControl
                .ItemsSource
                .OfType<WorkoutTab>()
                .Where(tab => tab.Selected)
                .ToList()
                .ForEach(p => p.Selected = false);

            Selected = true;

            parent.Selected = tabsControl
                .ItemsSource
                .OfType<WorkoutTab>()
                .Select((p, i) => new { p, i })
                .Where(p => p.p.Selected)
                .Select(p => p.i)
                .FirstOrDefault();

        }
    }


}