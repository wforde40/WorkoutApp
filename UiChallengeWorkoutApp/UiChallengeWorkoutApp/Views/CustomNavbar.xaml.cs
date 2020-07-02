using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavbar : ContentView
    {

        public static readonly BindableProperty LeftImageProperty =
            BindableProperty.Create("LeftImage", typeof(ImageSource), typeof(ImageSource), null);

        public static readonly BindableProperty RightImageProperty =
            BindableProperty.Create("RightImage", typeof(ImageSource), typeof(ImageSource), null);

        public ImageSource LeftImage
        {
            get { return (ImageSource)GetValue(LeftImageProperty); }
            set { SetValue(LeftImageProperty, value); }
        }

        public ImageSource RightImage
        {
            get { return (ImageSource)GetValue(RightImageProperty); }
            set { SetValue(RightImageProperty, value); }
        }

        public CustomNavbar()
        {
            InitializeComponent();

            LeftImageButton.SetBinding(ImageButton.SourceProperty, new Binding("LeftImage", source: this));
            RightImageButton.SetBinding(ImageButton.SourceProperty, new Binding("RightImage", source: this));
        }
    }
}