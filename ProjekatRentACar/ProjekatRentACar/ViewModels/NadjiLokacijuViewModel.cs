using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Core;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjekatRentACar.ViewModels
{
    public class NadjiLokacijuViewModel: INotifyPropertyChanged
    {
        Geolocator geolocator;
        public ObservableCollection<Lokacija> FiltiraneLokacije { get; set; }
        public ObservableCollection<Lokacija> LokacijeUBlizini { get; set; }
        private LokacijaDataSource lokacijaDS;
        public Boolean isUp;

        private Lokacija selectedItem { get; set; }
        public Lokacija SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                performSelectedLocation(selectedItem);
            }
        }


        public LokacijaDataSource LokacijaDS
        {
            get
            {
                return lokacijaDS;
            }

            set
            {
                lokacijaDS = value;
            }
        }

        /*   private ObservableCollection<Lokacija> selectionItems = new ObservableCollection<Lokacija> {
             new Lokacija("Sarajevo International Airport",new Geopoint(new BasicGeoposition() { Latitude = 43.8247348, Longitude = 18.3291708}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto"),
             new Lokacija("Tuzla International Airport",new Geopoint(new BasicGeoposition() { Latitude = 44.4586506, Longitude = 18.7226377}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto")
        };*/
        private ObservableCollection<Lokacija> sveLokacije { get; set; }

        public Helper.INavigationService navigacija { get; set; }

        private void lokacijeLoaded()
        {
            sveLokacije.Clear();
            foreach(Lokacija l in LokacijaDS.Lokacije)
            {
                sveLokacije.Add(l);
            }
        }

        
        private void lokacijeUBliziniLoaded()
        {
            LokacijeUBlizini.Clear();
            Debug.WriteLine(lokacijaDS.LokacijeUBlizini.Count);
            foreach (Lokacija l in LokacijaDS.LokacijeUBlizini)
            {
                LokacijeUBlizini.Add(l);
            }
        }
        private Geopoint trenutnaLokacija;

        public event PropertyChangedEventHandler PropertyChanged;

        public Geopoint TrenutnaLokacija
        {
            get { return trenutnaLokacija; }
            set
            {
                trenutnaLokacija = value;
                OnNotifyPropertyChanged("TrenutnaLokacija");
            }
        }

       
        private void CommandInvokedHandler(IUICommand command)
        {
            // Display message showing the label of the command that was invoked
            Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
        }

        private async void ucitajLokacije()
        {
            geolocator = new Geolocator { DesiredAccuracyInMeters = 10 };
            var accessStatus = await Geolocator.RequestAccessAsync();
            Geoposition pos = null;
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                //uzimanje pozicije ako smije

                pos = await geolocator.GetGeopositionAsync();
                TrenutnaLokacija = pos.Coordinate.Point;
                LokacijaDS.preuzmiLokacijeUBlizini(TrenutnaLokacija.Position.Latitude, TrenutnaLokacija.Position.Longitude, lokacijeUBliziniLoaded).GetAwaiter();
            }
            else { 

                MessageDialog ms = new MessageDialog("Lokacija nije ukljucena");
                await ms.ShowAsync();
            }   
        }

       


        public NadjiLokacijuViewModel(bool returnLocation = false) 
        {
            FiltiraneLokacije = new ObservableCollection<Lokacija>();
            sveLokacije = new ObservableCollection<Lokacija>();
            LokacijeUBlizini = new ObservableCollection<Models.Lokacija>();
            navigacija = new NavigationService();
            LokacijaDS = new LokacijaDataSource();
            LokacijaDS.preuzmiLokacije(lokacijeLoaded).GetAwaiter();
            ucitajLokacije();




            /* try
             {
                 uradiTask().GetAwaiter();
             }
             catch(Exception ex)
             {
                 MessageDialog msgDialogEror = new MessageDialog("Error: " + ex.ToString());
                 msgDialogEror.ShowAsync();
             }*/
        }


        /*
        private async Task  uradiTask()
        {
            IEnumerable<Lokacija> x =   await lokacijaTabela.ReadAsync(); 
            selectionItems.Clear();
            foreach (Lokacija lc in x)
            {
                selectionItems.Add(lc);
            }
            Debug.WriteLine((x.ElementAt(0) as Lokacija).Naziv);
        }
        */
        public void filterSuggestedItems(string autoSuggestBoxText)
        {
            FiltiraneLokacije.Clear();
            var filtered = sveLokacije.Where(l => (l.Naziv.Contains(autoSuggestBoxText) || l.Naziv.ToLower().Contains(autoSuggestBoxText)));
            foreach (Lokacija s in filtered)
            {
                s.LokacijaMjesta = new Geopoint(new BasicGeoposition() { Longitude = s.Duzina, Latitude = s.Sirina });
                FiltiraneLokacije.Add(s);
            }

        }
        

        public void performSelectedLocation(Lokacija selectedItem)
        {
             
            navigacija.Navigate(typeof(FormaDetaljiLokacije), new List<object>() { selectedItem, isUp});
        }


        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

    }
}
