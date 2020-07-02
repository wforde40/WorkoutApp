using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseListItem : ContentView
    {

        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create(nameof(Checked), typeof(ICommand), typeof(ExerciseListItem));

        public ICommand Checked
        {
            get => GetValue(CheckedProperty) as ICommand;
            set => SetValue(CheckedProperty, value);
        }

        public ExerciseListItem()
        {
            InitializeComponent();
        }
    }
}