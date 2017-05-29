using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Views;
using ProjekatRentACar.Models;

namespace ProjekatRentACar.ViewModels
{
    class DetaljiVozilaViewModel
    {
        public ICommand Dalje { get; set; }
        NavigationService navigacija;
        public Vozilo odabranoVozilo { get; set; }

        public DetaljiVozilaViewModel(Vozilo vozilo)
        {
            Dalje = new RelayCommand<object>(prikaziOpremu);
            navigacija = new NavigationService();
            odabranoVozilo = vozilo;
        }

        void prikaziOpremu(object parameter)
        {
            navigacija.Navigate(typeof(FormaOdabirOpreme));
        }
    }
}
