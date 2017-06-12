using ProjekatRentACar.Models;
using ProjekatRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class FormaKorisnickiRacun : Page
    {

        public FormaKorisnickiRacun()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            DataContext = new KorisnickiRacunViewModel();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(1);

            if (!(e.Parameter == null || string.IsNullOrWhiteSpace(e.Parameter.ToString())) && e.NavigationMode != NavigationMode.Back)
            {
                (DataContext as KorisnickiRacunViewModel).preuzmiNajmove(e.Parameter as Korisnik);
                App.splitViewFrame.BackStack.RemoveAt(App.splitViewFrame.BackStack.Count - 1);

            }
        }
    }
}
