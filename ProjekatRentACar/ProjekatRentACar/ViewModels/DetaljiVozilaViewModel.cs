using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Views;
using ProjekatRentACar.Models;
using ProjekatRentACar.ViewModels;
using System.Collections.ObjectModel;

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

        private string prijedlogVozila;
        public string PrijedlogVozila { get { return prijedlogVozila; } set { prijedlogVozila = value; } }

        private string kategorija;
        public string Kategorija { get { return kategorija; } set { kategorija = value; } }

        public Najam najam { get; set; }
        public Dictionary<Najam, ObservableCollection<Vozilo>> d { get; set; }

        public ObservableCollection<Vozilo> vozilaLista;

        public DetaljiVozilaViewModel(Dictionary<Najam, ObservableCollection<Vozilo>> d)
        {
            Dalje = new RelayCommand<object>(prikaziOVozacu);
            navigacija = new NavigationService();
            //this.najam = najam;

            this.d = d;
            najam = d.ElementAt(0).Key;
            vozilaLista = d.ElementAt(0).Value;
            this.najam.Cijena = (najam.KrajniDatum - najam.PocetniDatum).TotalDays * najam.Vozilo.CijenaPoDanu;      
                  
            //osoba = Convert.ToChar(najam.Vozilo.BrojSjedista);
            //vrata = Convert.ToChar(najam.Vozilo.BrojVrata);
            osoba = najam.Vozilo.BrojSjedista.ToString();
            vrata = najam.Vozilo.BrojVrata.ToString();
            kofer = (najam.Vozilo.ZapreminaPrtljaznika >= 5000) ? '3' : '2';
            mjenjac = (najam.Vozilo.VrstaMjenjaca == Mjenjac.Automatski) ? 'A' : 'M';
            PrijedlogVozila = dajPrijedlogVozila();
            Kategorija = dajKategoriju();
        }

        public string dajPrijedlogVozila()
        {
            IEnumerable<Vozilo> lista = vozilaLista.Where(x => x.Tip == najam.Vozilo.Tip);
            string vozilo = "";

            Random r = new Random();
            Vozilo v = lista.ElementAt(r.Next(0, lista.Count()));
            vozilo = v.Proizvodjac + " " + v.Model;

            return "ili " + vozilo + " ili slično vozilo";
        }

        public string dajKategoriju()
        {
            string kategorija = najam.Vozilo.Tip.ToString();
            return "iz kategorije " + kategorija;
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
