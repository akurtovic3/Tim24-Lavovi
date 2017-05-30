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

        public Najam najam { get; set; }
        public DetaljiVozilaViewModel(Najam najam)
        {
            Dalje = new RelayCommand<object>(prikaziOpremu);
            navigacija = new NavigationService();
            this.najam = najam;
            this.najam.Cijena = (najam.KrajniDatum - najam.PocetniDatum).TotalDays * najam.Vozilo.CijenaPoDanu;
        }

        void prikaziOpremu(object parameter)
        {
            navigacija.Navigate(typeof(FormaDetaljiOVozacu));
        }
    }
}
