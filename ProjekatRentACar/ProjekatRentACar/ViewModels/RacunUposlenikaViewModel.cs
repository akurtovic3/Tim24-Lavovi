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

namespace ProjekatRentACar.ViewModels
{
    class RacunUposlenikaViewModel
    {
        public ICommand DodajVozilo { get; set; }
        public INavigationService navigacija { get; set; }
        public Uposlenik TrenutniUposlenik { get; set; }
        private SvaIznamjljenaVozilaDataSource NajmoviDB;
        public ObservableCollection<NajamWebModel> Najmovi { get; set; }

        public RacunUposlenikaViewModel(Uposlenik uposlenik)
        {
            DodajVozilo = new RelayCommand<object>(unosVozila);
            navigacija = new NavigationService();
            TrenutniUposlenik = uposlenik;
            NajmoviDB = new SvaIznamjljenaVozilaDataSource();
            NajmoviDB.preuzmiTrenutneNajmove(najmoviLoaded).GetAwaiter();
            Najmovi = new ObservableCollection<NajamWebModel>();
        }
        private void najmoviLoaded()
        {
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
