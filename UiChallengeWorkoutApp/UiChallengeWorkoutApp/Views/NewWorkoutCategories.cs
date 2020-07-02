using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace UiChallengeWorkoutApp.Views
{
    public class NewWorkoutCategories : ContentView
    {
        public static BindableProperty CategoriesProperty =
            BindableProperty.Create("Categories", typeof(IEnumerable), typeof(NewWorkoutCategories), propertyChanged:OnCategoryChanged);

        private static void OnCategoryChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as NewWorkoutCategories;
            var grid = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition()
                    {
                        Width = GridLength.Star
                    },
                    new ColumnDefinition()
                    {
                        Width = GridLength.Star
                    },
                },
                ColumnSpacing = 20,
                RowSpacing = 20,
            };

            for (var i = 0; i < control.Categories.OfType<WorkoutCategoryViewModel>().Count(); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var rowDef = new RowDefinition() { Height = GridLength.Star };
                    var category = new WorkoutItem()
                    {
                        ImgSource = control.Categories.OfType<WorkoutCategoryViewModel>().ElementAt(i).ImgSource,
                        Text = control.Categories.OfType<WorkoutCategoryViewModel>().ElementAt(i).Text,

                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };
                    var pancake = new PancakeView()
                    {
                        CornerRadius = 5,
                        HasShadow = true,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Content = category,
                    };

                    grid.RowDefinitions.Add(rowDef);
                    grid.Children.Add(pancake);
                    i++;
                }
            }

            control.Content = grid;
        }

        public IEnumerable Categories
        {
            get { return GetValue(CategoriesProperty) as IEnumerable; }
            set { SetValue(CategoriesProperty, value); }
        }


        public NewWorkoutCategories()
        {

            BindingContext = Categories;

        }
    }
}