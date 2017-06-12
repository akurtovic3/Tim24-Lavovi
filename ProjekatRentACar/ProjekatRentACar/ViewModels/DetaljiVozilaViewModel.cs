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

        public string osoba { get; set; }
        public char kofer { get; set; }
        public char mjenjac { get; set; }
        public string vrata { get; set; }

        public Najam najam { get; set; }
        public DetaljiVozilaViewModel(Najam najam)
        {
            Dalje = new RelayCommand<object>(prikaziOVozacu);
            navigacija = new NavigationService();
            this.najam = najam;
            this.najam.Cijena = (najam.KrajniDatum - najam.PocetniDatum).TotalDays * najam.Vozilo.CijenaPoDanu;

            //osoba = Convert.ToChar(najam.Vozilo.BrojSjedista);
            //vrata = Convert.ToChar(najam.Vozilo.BrojVrata);
            osoba = najam.Vozilo.BrojSjedista.ToString();
            vrata = najam.Vozilo.BrojVrata.ToString();
            kofer = (najam.Vozilo.ZapreminaPrtljaznika >= 5000) ? '3' : '2';
            mjenjac = (najam.Vozilo.VrstaMjenjaca == Mjenjac.Automatski) ? 'A' : 'M'; 
        }

        void prikaziOVozacu(object parameter)
        {
            if (App.daLiJeKorisnikPrijavljen)
            {
                navigacija.Navigate(typeof(FormaDetaljiOVozacu), najam);
            }else
            {
                navigacija.Navigate(typeof(FormaPrijava));
            }
        }
    }
}
