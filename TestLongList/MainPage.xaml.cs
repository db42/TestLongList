using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestLongList.Resources;
using TestLongList.ViewModels;

namespace TestLongList
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool _firstRealized;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void AddTop(object sender, EventArgs e)
        {
            App.ViewModel.LoadTopElements(10);
        }

        private void AddBottom(object sender, EventArgs e)
        {
            App.ViewModel.LoadBottomElements(10);
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            //App.ViewModel.SetPullDetector(ItemsList);
            App.ViewModel.LoadTopElements(26);
        }

        private void LongListSelector_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            if (e.ItemKind != LongListSelectorItemKind.Item)
                return;
            var item = e.Container.Content as ItemViewModel;
            if (!App.ViewModel.IsDataLoading && ItemsList.ItemsSource[0] == item)
            {
                App.ViewModel.LoadTopElements(10);
            }
        }

        private void ItemsList_OnManipulationStateChanged(object sender, EventArgs e)
        {
        }

        private void ItemsList_OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            if (e.ItemKind != LongListSelectorItemKind.Item)
                return;
            var item = e.Container.Content as ItemViewModel;
            if (!App.ViewModel.IsDataLoading && ItemsList.ItemsSource[0] == item)
            {
                //if (!_firstRealized)
                //{
                //    _firstRealized = true;
                //}
                //else
                //{
                App.ViewModel.LoadTopElements(10);
                //Debug.WriteLine("");
                //}
            }
        }

        private void ItemsList_OnItemUnrealized(object sender, ItemRealizationEventArgs e)
        {
            //if (e.ItemKind != LongListSelectorItemKind.Item)
            //    return;
            //var item = e.Container.Content as ItemViewModel;
            //if (!App.ViewModel.IsDataLoading && ItemsList.ItemsSource[0] == item)
            //{
            //        Debug.WriteLine("");
            //}
        }

        private void FrameworkElement_OnLoaded1(object sender, RoutedEventArgs e)
        {
            App.ViewModel.LoadTopElements(10);
        }
    }
}