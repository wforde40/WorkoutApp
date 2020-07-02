using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UiChallengeWorkoutApp
{
    class CustomCollectionView : ContentView
    {

        public IEnumerable ItemSource
        {
            get => Collection.ItemsSource;
            set => Collection.ItemsSource = value;
        }

        private CollectionView Collection;

        public CustomCollectionView()
        {

            //Collection.SelectionChanged

            Content = Collection;

        }
       

    }
}
