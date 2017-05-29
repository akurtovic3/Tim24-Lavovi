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
using ProjekatRentACar.Models;
using System.Collections.ObjectModel;
using ProjekatRentACar.ViewModels;
using Windows.UI.Popups;
using ProjekatRentACar.Helper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaListaVozila : Page
    {
        NavigationService navigacija;

        public FormaListaVozila()
        {
            this.InitializeComponent();
            navigacija = new NavigationService();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new VozilaViewModel(e.Parameter as Najam);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*int index = vozilaGrid.Items.IndexOf(e.ClickedItem);
            MessageDialog msd = new MessageDialog("Kliknuli ste na " + index.ToString() + ". item");
            msd.ShowAsync();
            navigacija.Navigate(typeof(FormaDetaljiVozila), index);*/
        }
    }
}
