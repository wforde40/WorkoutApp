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
    public partial class CheckCircle : ContentView
    {
        public static readonly BindableProperty CompletedProperty =
            BindableProperty.Create(nameof(Completed), typeof(bool), typeof(bool), false);

        public static readonly BindableProperty CompletedCommandProperty =
            BindableProperty.Create(nameof(CompletedCommand), typeof(ICommand), typeof(CheckCircle));

        public bool Completed
        {
            get { return (bool)GetValue(CompletedProperty); }
            set { SetValue(CompletedProperty, value); }
        }

        public ICommand CompletedCommand
        {
            get => GetValue(CompletedCommandProperty) as ICommand;
            set => SetValue(CompletedCommandProperty, value);

        }

        private SKPath CheckPath = new SKPath();
        private SKPaint CheckFill = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 10,
            Color = SKColor.Parse("#596EFF")
        };

        private SKPaint CircleFill = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 8,
            Color = SKColor.Parse("#C7C7CC")
        };

        public CheckCircle()
        {
            InitializeComponent();

            CheckPath.MoveTo(0, 30);
            CheckPath.LineTo(30, 60);
            CheckPath.LineTo(75, 15);
        }

        private void Circle_Tapped(object sender, EventArgs args)
        {
            Completed = !Completed;
            CanvasView.InvalidateSurface();

            CompletedCommand.Execute(null);
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var canvas = args.Surface.Canvas;

            canvas.Clear();

            canvas.Save();

            if (Completed)
                canvas.DrawPath(CheckPath, CheckFill);
            else
                canvas.DrawCircle(new SKPoint(45, 45), 40f, CircleFill);

            canvas.Restore();
        }
    }
}