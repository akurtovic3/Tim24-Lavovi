using ProjekatRentACar.Models;
using ProjekatRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class FormaPostavke : Page
    {
        public FormaPostavke()
        {
            this.InitializeComponent();
            DataContext = new PostavkeViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(5);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*using (var db = new PostavkeDbContext())
            {
                ValuteCombo.SelectedItem = db.postavke.Select(x => x.Valuta).ToList<string>().ElementAt(3);
                LokacijaToggle.IsOn = db.postavke.Select(x => x.Lokacija).ToList<bool>().ElementAt(0);
                NotifikacijeToggle.IsOn = db.postavke.Select(x => x.Notifikacije).ToList<bool>().ElementAt(0);
            }*/
        }
    }
}
