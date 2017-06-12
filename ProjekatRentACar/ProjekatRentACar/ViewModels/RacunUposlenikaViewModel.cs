using ProjekatRentACar.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Views;
using ProjekatRentACar.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

namespace ProjekatRentACar.ViewModels
{
    class RacunUposlenikaViewModel
    {
        public ICommand DodajVozilo { get; set; }
        public INavigationService navigacija { get; set; }
        public Uposlenik TrenutniUposlenik { get; set; }
        private SvaIznamjljenaVozilaDataSource NajmoviDB;
        public ObservableCollection<NajamWebModel> Najmovi { get; set; }

        public RacunUposlenikaViewModel()
        {
            DodajVozilo = new RelayCommand<object>(unosVozila);
            navigacija = new NavigationService();
            NajmoviDB = new SvaIznamjljenaVozilaDataSource();
            Najmovi = new ObservableCollection<NajamWebModel>();
            Debug.WriteLine(App.splitViewFrame.BackStack.Count);
            foreach(PageStackEntry s in App.splitViewFrame.BackStack)
            {
                Debug.WriteLine(s);
            }
               

        }

        public void preuzmiNajmove(Uposlenik uposlenik)
        {
            TrenutniUposlenik = uposlenik;
            NajmoviDB.preuzmiTrenutneNajmove(najmoviLoaded).GetAwaiter();

        }



        private void najmoviLoaded()
        {
            Najmovi.Clear();
            foreach (NajamWebModel n in NajmoviDB.Najmovi)
            {
                Najmovi.Add(n);
            }
        }

        public void unosVozila(object parameter)
        {
            navigacija.Navigate(typeof(FormaUnosNovogVozila));
        }
    }
}
