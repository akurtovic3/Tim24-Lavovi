using Prism.Windows.Validation;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace ProjekatRentACar.ViewModels
{
    public class OdabirLokacijeIDatumaViewModel : ValidatableBindableBase, INotifyPropertyChanged
    {
        public ICommand Ponude { get; set; }
        public ICommand LokacijaPreuzimanja { get; set; }
        public ICommand LokacijaVracanja { get; set; }
        public Helper.INavigationService NavigationService { get; set; }

        private Lokacija pocetnaLokacija;
        [IsNullValidation]
        public Lokacija PocetnaLokacija
        {
            get { return pocetnaLokacija; }
            set { SetProperty(ref pocetnaLokacija, value);
                OnNotifyPropertyChanged("PocetnaLokacija");
            }
        }


        private Lokacija krajnjaLokacija;
        [IsNullValidation]
        public Lokacija KrajnjaLokacija
        {
            get { return krajnjaLokacija; }
            set { SetProperty(ref krajnjaLokacija, value);
                OnNotifyPropertyChanged("KrajnjaLokacija");
            }
        }

        private DateTime datumRezervacije { get; set; }
        public DateTime DatumRezervacije
        {
            get
            {
                return datumRezervacije;
            }
            set
            {
                datumRezervacije = value;
                DatumVracanja = datumRezervacije.AddDays(1);
            }
        }

        private DateTime datumVracanja;
        public DateTime DatumVracanja
        {
            get
            {
                return datumVracanja;
            }
            set
            {
                datumVracanja = value;
                OnNotifyPropertyChanged("DatumVracanja");
            }
        }



        public OdabirLokacijeIDatumaViewModel()
        {
            Ponude = new RelayCommand<object>(prikaziPonude, moguLiSePrikazatiPonude);
            LokacijaPreuzimanja = new RelayCommand<object>(otvoriLokaciju1, moguLiSePrikazatiPonude);
            LokacijaVracanja = new RelayCommand<object>(otvoriLokaciju2, moguLiSePrikazatiPonude);
            NavigationService = new NavigationService();
            this.IsValidationEnabled = false;
            PocetnaLokacija = new Lokacija();
            KrajnjaLokacija = new Lokacija();
            datumRezervacije = DateTime.Today;
            DatumVracanja = datumRezervacije.AddDays(1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> erori;
        public ObservableCollection<string> Erori
        {
            get
            {
                return erori;
            }
            set
            {
                erori = value;
            }
        }

        public bool moguLiSePrikazatiPonude(object parametar)
        {
            return true;
        }

        public async void prikaziPonude(object parametar)
        {
            this.IsValidationEnabled = true;
            this.ValidateProperties();
            Erori = new ObservableCollection<string>(this.Errors.Errors.Values.SelectMany(x => x).ToList());

            if (DatumRezervacije.AddDays(1) > DatumVracanja)
            {
                var dialog = new MessageDialog("Datum vraćanja mora biti iza datuma rezervacije!");
                await dialog.ShowAsync();
            }

            if ((erori == null || erori.Count == 0) && DatumRezervacije.AddDays(1) <= datumVracanja)
            {
                Najam noviNajam = new Najam();
                noviNajam.MjestoPreuzimanja = PocetnaLokacija;
                noviNajam.MjestoVracanja = KrajnjaLokacija;
                noviNajam.PocetniDatum = DatumRezervacije;
                noviNajam.KrajniDatum = DatumVracanja;

                NavigationService.Navigate(typeof(FormaListaVozila), noviNajam);
            }


        }

        public void otvoriLokaciju1(object parametar)
        {

            NavigationService.Navigate(typeof(FormaNadjiLokaciju), true);
        }

        public void otvoriLokaciju2(object parametar)
        {

            NavigationService.Navigate(typeof(FormaNadjiLokaciju), false);
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

    }
}
