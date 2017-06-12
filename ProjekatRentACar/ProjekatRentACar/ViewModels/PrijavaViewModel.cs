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
using Windows.UI.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using ProjekatRentACar.Azure;
using System.Diagnostics;

namespace ProjekatRentACar.ViewModels
{
    public class PrijavaViewModel : ValidatableBindableBase, INotifyPropertyChanged
    {
        private LoginDataSource loginDS;
        IMobileServiceTable<UserAnalytics> userTableObj = App.MobileService.GetTable<UserAnalytics>();



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
        public ICommand Registracija { get; set; }
        NavigationService navigacija;
        public ObservableCollection<string> erori { get; set; }

        public LoginDataSource LoginDS
        {
            get
            {
                return loginDS;
            }

            set
            {
                loginDS = value;
            }
        }

        public PrijavaViewModel()
        {
            Login = new RelayCommand<object>(prikaziFormuOsobe);
            Registracija = new RelayCommand<object>(prikaziFormuZaRegistraciju);
            navigacija = new NavigationService();
            loginDS = new LoginDataSource();
        }

        private  void loginLoaded()
        {
            if (loginDS.isError == false)
            {
                //Pošalji u azure
                App.daLiJeKorisnikPrijavljen = true;
                App.role = loginDS.role;
                if (loginDS.role == "1")
                {

                    Korisnik noviKorisnik = LoginDS.noviKorisnik;
                    try
                    {
                        UserAnalytics user = new UserAnalytics();
                        user.email = noviKorisnik.Email;
                        userTableObj.InsertAsync(user);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    navigacija.Navigate(typeof(FormaKorisnickiRacun), noviKorisnik);
                }else if(loginDS.role == "2")
                {
                    Uposlenik noviUposlenik = LoginDS.noviUposlenik;
                    navigacija.Navigate(typeof(FormaRacunUposlenika), noviUposlenik);
                }

            }
            else
            {
                showMessageBox();
            }
        }

        private async void showMessageBox()
        {
            MessageDialog ms = new MessageDialog(loginDS.ErrorText);
            await ms.ShowAsync();
        }

        public void prikaziFormuOsobe(object parametar)
        {
            this.ValidateProperties();
            erori = new ObservableCollection<string>(this.Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                loginDS.prijaviKorisnika(KorisnickoIme, Sifra, loginLoaded).GetAwaiter();

            }
        }

        public void prikaziFormuZaRegistraciju(object parametar)
        {
            navigacija.Navigate(typeof(FormaRegistracijaKorisnika));
        }


    }
}
