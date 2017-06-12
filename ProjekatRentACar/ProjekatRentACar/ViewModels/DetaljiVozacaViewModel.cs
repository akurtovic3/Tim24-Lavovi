using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatRentACar.ViewModels
{
    public class DetaljiVozacaViewModel : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }

        private bool prihvaceno;
        public bool Prihvaceno { get { return prihvaceno; } set { prihvaceno = value; OnNotifyPropertyChanged("Slika"); } }

        NavigationService navigacija;

        private void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public ICommand Dalje { get; set; }


        public Najam najam { get; set; }
        public DetaljiVozacaViewModel(Najam najam)
        {
            this.najam = najam;
            id = App._id;
            ime = App._ime;
            prezime = App._prezime;
            telefon = App._telefon;
            email = App._email;
            Dalje = new RelayCommand<object>(idiNaPlacanje);
            navigacija = new NavigationService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void idiNaPlacanje(object parameter)
        {
            if (prihvaceno) navigacija.Navigate(typeof(FormaPlacanje), najam);
        }
    }
}
