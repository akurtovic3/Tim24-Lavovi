using Prism.Windows.Validation;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ProjekatRentACar.ViewModels
{
    class RegistracijaKorisnikaViewModel : ValidatableBindableBase, INotifyPropertyChanged
    {
        private string ime;
        [Required]
        public string Ime
        {
            get { return ime; }
            set { SetProperty(ref ime, value); }
        }

        private string prezime;
        [Required]
        public string Prezime
        {
            get { return prezime; }
            set { SetProperty(ref prezime, value); }
        }

        private DateTime datumRodjenja;
        [Required]
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { SetProperty(ref datumRodjenja, value); }
        }

        private string telefon;
        [Required]
        public string Telefon
        {
            get { return telefon; }
            set { SetProperty(ref telefon, value); }
        }

        private string email;
        [Required]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string drzava;
        [Required]
        public string Drzava
        {
            get { return drzava; }
            set { SetProperty(ref drzava, value); }
        }

        private string adresa;
        [Required]
        public string Adresa
        {
            get { return adresa; }
            set { SetProperty(ref adresa, value); }
        }

        private int postanskiBroj;
        [Required]
        public int PostanskiBroj
        {
            get { return postanskiBroj; }
            set { SetProperty(ref postanskiBroj, value); }
        }

        public ICommand Registriraj { get; set; }
        public object Errors { get; private set; }
        public ObservableCollection<string> erori { get; set; }
        NavigationService navigacija { get; set; }

        public RegistracijaKorisnikaViewModel()
        {
            Registriraj = new RelayCommand<object>(obavijestiORegistraciji);
            navigacija = new NavigationService();
        }

        public async void obavijestiORegistraciji(object parametar)
        {
            this.ValidateProperties();
            //erori = new ObservableCollection<string>(this.Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                MessageDialog msgDialog = new MessageDialog("Registracija uspješna!", "Obavijest");
                await msgDialog.ShowAsync();
                navigacija.Navigate(typeof(FormaKorisnickiRacun));
            }
        }
    }
}
