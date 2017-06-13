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

using Windows.UI.Popups;


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
        public bool Prihvaceno { get { return prihvaceno; } set { prihvaceno = value; OnNotifyPropertyChanged("Prihvaceno"); } }


        private void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public ICommand Dalje { get; set; }


        public Najam najam { get; set; }
        NavigationService navigacija;

        public DetaljiVozacaViewModel(Najam najam)
        {
            this.najam = najam;
            id = App._id;
            ime = App._ime;
            prezime = App._prezime;
            telefon = App._telefon;
            email = App._email;

            Dalje = new RelayCommand<object>(idiDalje);
            navigacija = new NavigationService();
            Prihvaceno = false;
        }

        private void idiDalje(object parameter)
        {
            if (Prihvaceno)
            {
                navigacija.Navigate(typeof(FormaPlacanje), najam);
            }else
            {
                showMessageDialog();
            }

        }
        private async void showMessageDialog()
        {
            MessageDialog ms = new MessageDialog("Morate pristati na uslove navedene u ugovoru!");
            await ms.ShowAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;



        
    }
}
