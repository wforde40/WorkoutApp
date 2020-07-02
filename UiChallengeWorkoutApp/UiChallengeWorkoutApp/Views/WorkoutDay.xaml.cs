using SkiaSharp;
using SkiaSharp.Views.Forms;
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
    public partial class WorkoutDay : ContentView
    {

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(WorkoutDay));

        public static readonly BindableProperty UserIdProperty =
           BindableProperty.Create(nameof(UserID), typeof(int), typeof(WorkoutDay));
   
        public static readonly BindableProperty WorkoutIdProperty =
            BindableProperty.Create(nameof(WorkoutID), typeof(int), typeof(WorkoutDay));

        public static readonly BindableProperty DoneProperty =
            BindableProperty.Create(nameof(Done), typeof(bool), typeof(WorkoutDay));

        public static readonly BindableProperty DayProperty =
            BindableProperty.Create(nameof(Day), typeof(string), typeof(WorkoutDay));

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        public int WorkoutID
        {
            get => (int)GetValue(WorkoutIdProperty);
            set => SetValue(WorkoutIdProperty, value);
        }
        public int UserID
        {
            get => (int)GetValue(WorkoutIdProperty);
            set => SetValue(WorkoutIdProperty, value);
        }
        public string Day 
        {
            get => (string)GetValue(DayProperty);
            set => SetValue(DayProperty, value);
        }
        public bool Done 
        { 
            get => (bool)GetValue(DoneProperty); 
            set => SetValue(DoneProperty, value); 
        }
        public bool IsDayOfTheWeek 
        { 
            get => DateTime.Now.DayOfWeek == Date.DayOfWeek; 
        }

        private SKPath CheckPath = new SKPath();
        private SKPath IsTodayTriangle = new SKPath();

        private SKPaint CircleFill = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#8672EB")
        };

        private SKPaint DoneFill = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColor.Parse("#72DDFF")
        };

        private SKPaint CheckFill = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black /*#6F58DC*/
        };

        private SKPaint TriangleFill = new SKPaint()
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        public WorkoutDay()
        {
            InitializeComponent();

            IsTodayTriangle.MoveTo(45, 110);
            IsTodayTriangle.LineTo(85, 110);
            IsTodayTriangle.LineTo(65, 80);
            IsTodayTriangle.LineTo(45, 110);

            //CheckPath.MoveTo(55, 25);
            //CheckPath.LineTo(70, 45);
            //CheckPath.LineTo(85, 15);


            //DayLabel.SetBinding(Label.TextProperty, new Binding(nameof(Day), BindingMode.TwoWay, source: this));
           
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var canvas = args.Surface.Canvas;

            canvas.Clear();

            canvas.Save();

            if (Done)
            {
                canvas.DrawCircle(new SKPoint(65, 30), 30f, DoneFill);
                //canvas.DrawPath(CheckPath, CheckFill);
                //canvas.DrawCircle(new SKPoint(65, 30), 15f, CheckFill);

            }
            else
                canvas.DrawCircle(new SKPoint(65, 30), 30f, CircleFill);
               
            if (IsDayOfTheWeek)
                canvas.DrawPath(IsTodayTriangle, TriangleFill);
            
            canvas.Restore();
        }

        private void DayClicked()
        {
            throw new NotImplementedException();
        }

        private static string DateToDayMap(DayOfWeek day) => day switch
        {
            DayOfWeek.Monday => "M",
            DayOfWeek.Tuesday => "T",
            DayOfWeek.Wednesday => "W",
            DayOfWeek.Thursday => "R",
            DayOfWeek.Friday => "F",
            DayOfWeek.Saturday => "S",
            DayOfWeek.Sunday => "S",
            _ => ""
        };

    }
}