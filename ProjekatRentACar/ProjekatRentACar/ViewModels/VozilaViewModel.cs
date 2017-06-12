using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ProjekatRentACar.ViewModels
{
    public class VozilaViewModel
    {
        private Najam najam;
        public ObservableCollection<Vozilo> vozila { get; set; }
        private VozilaDataSource vozilaDS;
        NavigationService navigacija;

        private static VozilaViewModel instance;
        public static VozilaViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VozilaViewModel();
                }
                return instance;
            }
        }

        private Vozilo odabranoVozilo { get; set; }
        public Vozilo OdabranoVozilo
        {
            get
            {
                return odabranoVozilo;
            }
            set
            {
                odabranoVozilo = value;
                najam.Vozilo = odabranoVozilo;
                Dictionary<Najam, ObservableCollection<Vozilo>> d = new Dictionary<Najam, ObservableCollection<Vozilo>>();
                d.Add(najam, vozila);
                navigacija.Navigate(typeof(FormaDetaljiVozila), d);
            }
        }

        public VozilaDataSource VozilaDS
        {
            get
            {
                return vozilaDS;
            }

            set
            {
                vozilaDS = value;
            }
        }

        public VozilaViewModel(Najam najam)
        {
            this.najam = najam;
            vozila = new ObservableCollection<Vozilo>();
            VozilaDS = new VozilaDataSource();
            navigacija = new NavigationService();
            vozilaDS.preuzmiVozila(najam.PocetniDatum, najam.KrajniDatum, vozilaLoaded).GetAwaiter();
        }

        public VozilaViewModel()
        {
        }

        private void vozilaLoaded()
        {
            vozila.Clear();
            foreach (Vozilo v in VozilaDS.Vozila)
            {
                vozila.Add(v);
            }
        }

    }
}

