using Prism.Windows.Validation;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ProjekatRentACar.ViewModels
{
    class PlacanjeViewModel : ValidatableBindableBase
    {
        public ICommand Plati { get; set; }
        private UploadNajmaDataSource UploadDS;

        private string imeNaKartici;
        [Required]
        public string ImeNaKartici
        {
            get { return imeNaKartici; }
            set { SetProperty(ref imeNaKartici, value); }
        }

        private string brojKartice;
        [Required, CreditCard, BrojcanaValidacija]
        public string BrojKartice
        {
            get { return brojKartice; }
            set { SetProperty(ref brojKartice, value); }
        }

        private DateTime datum;
        [Required]
        public DateTime Datum
        {
            get { return datum; }
            set { SetProperty(ref datum, value); }
        }

        private string cvcBroj;
        [Required, MinLength(4), MaxLength(4), BrojcanaValidacija]
        public string CVCBroj
        {
            get { return cvcBroj; }
            set { SetProperty(ref cvcBroj, value); }
        }

        public ObservableCollection<string> erori { get; set; }

        Najam najam;

        public PlacanjeViewModel(Najam najam)
        {
            this.najam = najam;
            Plati = new RelayCommand<object>(obavijestiOPlacanju);
            UploadDS = new UploadNajmaDataSource();
        }

        public  void obavijestiOPlacanju(object parameter)
        {
            this.ValidateProperties();
            erori = new ObservableCollection<string>(Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                // treba uradit insert najma u bazu

                UploadDS.uploadNajam(najam, callback).GetAwaiter();

                //var msd = new MessageDialog("Uspješno ste iznajmili vozilo");
                //await msd.ShowAsync();
            }
        }
        private async void callback()
        {
            string poruka = "Uspješno ste unajmili vozilo!";
            if (UploadDS.error == true) 
            {
                poruka = "Došlo je do greške, pokušajte ponovo.";
            }
            MessageDialog ms = new MessageDialog(poruka);
            await ms.ShowAsync();
        }
    }
}
