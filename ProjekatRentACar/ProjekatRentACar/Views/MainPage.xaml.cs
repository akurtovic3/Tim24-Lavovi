using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjekatRentACar.Views;
using ProjekatRentACar.ViewModels;
using ProjekatRentACar.Helper;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjekatRentACar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public INavigationService nav { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
             App.splitViewFrame = MainFrame;

 
            DataContext = new MainPageViewModel();

            //staviti da se vidi back
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

            nav = new NavigationService();

            DataContext = MainPageViewModel.Instance;

        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
            MainListView.Visibility = Visibility.Visible;         
        }


        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            nav.GoBack();  // treba dodati da se selektira ikona u meniju        
        }
    }
}
