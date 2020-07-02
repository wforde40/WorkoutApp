using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UiChallengeWorkoutApp.Services;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.Views;

namespace UiChallengeWorkoutApp.ViewModels
{
    public class WorkoutChoiceViewModel : BaseViewModel
    {
        public IExerciseDataStore DataStore => DependencyService.Get<ExerciseDatastore>();

        ObservableCollection<WorkoutTab> _tabs;
        public ObservableCollection<WorkoutTab> Tabs 
        {
            get => _tabs;
            set
            {
                _tabs = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<WorkoutCategoryViewModel> _categories { get; set; }
        public ObservableCollection<WorkoutCategoryViewModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetCategoriesCommand;
        public ICommand GetTypesCommand;

        private ICommand _gotoWoroutPageCommand;
        public ICommand GotoWorkoutPageCommand
        {
            get => _gotoWoroutPageCommand;
            set
            {
                _gotoWoroutPageCommand = value;
                OnPropertyChanged();
            }
        }

        private int _tabSelected = 2;

        public int TabSelected
        {
            get => _tabSelected;
            set
            {
                _tabSelected = value;
                OnPropertyChanged();
            }
        }

        public WorkoutChoiceViewModel()
        {
            GetCategoriesCommand = new Command(async () => await GetCategories());
            GetTypesCommand =  new Command(async () => await GetTypes(TabSelected));
            GotoWorkoutPageCommand = new Command<string>(async (string category) => await GoToWorkoutPage(category));

            Categories = new ObservableCollection<WorkoutCategoryViewModel>();
            Tabs = new ObservableCollection<WorkoutTab>();
        }

        private async Task GetCategories()
        {
            var test = await DataStore.GetCategories();
            var models = test.Select(p => new WorkoutCategoryViewModel()
            {
                ImgSource = p.ImageLocation,
                Text = p.Name
            });

            foreach (var model in models)
            {
                Categories.Add(model);
            }
        }

        private async Task GetTypes(int selected)
        {
            var types = await DataStore.GetTypes();
            var tabs = types.Select(p => new WorkoutTab()
            {
                Text = p.Name
            });

            foreach(var tab in tabs)
            {
                Tabs.Add(tab);
            }
            
            Tabs[selected].Selected = true;
        }

        private async Task GoToWorkoutPage(string category)
        {
            var type = Tabs[TabSelected].Text;
            await App.Current.MainPage.Navigation.PushAsync(new WorkoutPage(category, type));
        }
        


    }
}
