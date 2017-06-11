using ProjekatRentACar.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Views;

namespace ProjekatRentACar.ViewModels
{
    class RacunUposlenikaViewModel
    {
        public ICommand DodajVozilo { get; set; }
        public INavigationService navigacija { get; set; }

        public RacunUposlenikaViewModel()
        {
            DodajVozilo = new RelayCommand<object>(unosVozila);
            navigacija = new NavigationService();
        }

        public void unosVozila(object parameter)
        {
            navigacija.Navigate(typeof(FormaUnosNovogVozila));
        }
    }
}
