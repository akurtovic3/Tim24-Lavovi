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
using System.Runtime.CompilerServices;
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
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { SetProperty(ref datumRodjenja, value); }
        }

        private string telefon;
        [Required, Phone]
        public string Telefon
        {
            get { return telefon; }
            set { SetProperty(ref telefon, value); }
        }

        private string email;
        [Required, EmailAddress]
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string drzava;
        public string Drzava
        {
            get { return drzava; }
            set {
                drzava = value;
            }
        }

        private string adresa;
        [Required]
        public string Adresa
        {
            get { return adresa; }
            set { SetProperty(ref adresa, value); }
        }

        private string sifra;
        [Required]
        public string Sifra
        {
            get { return sifra; }
            set { SetProperty(ref sifra, value); }
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
            Drzava = "Bosna i Hercegovina";
            
        }

        private void registracijaLoaded()
        {
            showMessageBox();   
        }


        
        private async void showMessageBox()
        {
            MessageDialog ms = new MessageDialog(registracijaDS.ErrorText);
            if(RegistracijaDS.isError == false)
            {
                ms.Commands.Add(new UICommand(
        "Prijavi se", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                ms.Commands.Add(new UICommand("Cancel"));
                ms.DefaultCommandIndex = 0;
                ms.CancelCommandIndex = 1;
            }  
            await ms.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            navigacija.GoBack();
        }

        public  void obavijestiORegistraciji(object parametar)
        {
            this.ValidateProperties();
            erori = new ObservableCollection<string>(Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                RegistracijaDS.registrujKorisnika(Ime, Prezime,
            DatumRodjenja, Telefon.ToString(), Email, Drzava,
            Adresa, Sifra, registracijaLoaded).GetAwaiter();
                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
