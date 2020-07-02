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
    public partial class WorkoutItem : ContentView
    {

        public static BindableProperty ImgSourceProperty =
            BindableProperty.Create(nameof(ImgSource), typeof(ImageSource), typeof(WorkoutItem), null);

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(WorkoutItem), string.Empty);


        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public WorkoutItem()
        {
            InitializeComponent();

            icon.SetBinding(Image.SourceProperty, new Binding("ImgSource", source: this));
            label.SetBinding(Label.TextProperty, new Binding("Text", source: this));

        }
    }
}