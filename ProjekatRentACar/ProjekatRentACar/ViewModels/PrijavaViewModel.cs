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
using Windows.UI.Xaml;

namespace ProjekatRentACar.ViewModels
{
    public class PrijavaViewModel : ValidatableBindableBase, INotifyPropertyChanged
    {
        private string korisnickoIme;
        [Required]
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { SetProperty(ref korisnickoIme, value); }
        }
        
        private string sifra;

        [Required]
        public string Sifra
        {
            get { return sifra; }
            set { SetProperty(ref sifra, value); }
        }

        public ICommand Login { get; set; }
        NavigationService navigacija;
        public ObservableCollection<string> erori { get; set; }

        public PrijavaViewModel()
        {
            Login = new RelayCommand<object>(prikaziFormuOsobe);
            navigacija = new NavigationService();
        }

        public void prikaziFormuOsobe(object parametar)
        {
            this.ValidateProperties();
            erori = new ObservableCollection<string>(this.Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0) )
            {
                navigacija.Navigate(typeof(FormaKorisnickiRacun));
            }
        }

        
    }
}
