using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UiChallengeWorkoutApp.Models;
using UiChallengeWorkoutApp.Views;
using UiChallengeWorkoutApp.Services;
using UiChallengeWorkoutApp.MobileAppService.Models;

namespace UiChallengeWorkoutApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        IDataStore<Item> DataStore = DependencyService.Get<ItemStore<Item>>();

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetAsync(true);
                foreach (var item in items)
                {
                    //Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}