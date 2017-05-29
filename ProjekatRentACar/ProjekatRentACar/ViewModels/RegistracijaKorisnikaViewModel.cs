using Prism.Windows.Validation;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
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
        RegistracijaDataSource registracijaDS;

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

       

        public ICommand Registriraj { get; set; }
        public ObservableCollection<string> erori { get; set; }
        NavigationService navigacija { get; set; }

        public RegistracijaDataSource RegistracijaDS
        {
            get
            {
                return registracijaDS;
            }

            set
            {
                registracijaDS = value;
            }
        }

        public RegistracijaKorisnikaViewModel()
        {
            Registriraj = new RelayCommand<object>(obavijestiORegistraciji);
            navigacija = new NavigationService();
            registracijaDS = new RegistracijaDataSource();
        }

        private void registracijaLoaded()
        {
            showMessageBox();

            if (registracijaDS.isError == false)
            {
               // navigacija.Navigate(typeof(FormaPrijava));
            }
           
        }

        private async void showMessageBox()
        {
            MessageDialog ms = new MessageDialog(registracijaDS.ErrorText);
            await ms.ShowAsync();
        }


        public async void obavijestiORegistraciji(object parametar)
        {
            this.ValidateProperties();
            erori = new ObservableCollection<string>(Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                MessageDialog msgDialog = new MessageDialog("Registracija uspješna!", "Obavijest");
                await msgDialog.ShowAsync();
                navigacija.Navigate(typeof(FormaKorisnickiRacun));
            }
        }
    }
}
