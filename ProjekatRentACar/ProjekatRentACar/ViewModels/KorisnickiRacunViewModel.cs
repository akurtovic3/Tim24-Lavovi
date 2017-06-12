using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.ViewModels
{
    public class KorisnickiRacunViewModel
    {
        private NajmoviKorisnikaDataSource NajmoviDS;
        public ObservableCollection<NajamWebModel> Najmovi { get; set; }
        public Korisnik TrenutniKorisnik { get; set; }
        public KorisnickiRacunViewModel()
        {
            Najmovi = new ObservableCollection<NajamWebModel>();
            NajmoviDS = new NajmoviKorisnikaDataSource();
        }

        public void preuzmiNajmove(Korisnik korisnik)
        {
            TrenutniKorisnik = korisnik;
            NajmoviDS.preuzmiNajmove(TrenutniKorisnik.Id, NajmoviLoaded).GetAwaiter();

        }

        private void NajmoviLoaded()
        {
            Najmovi.Clear();
            foreach (NajamWebModel n in NajmoviDS.Najmovi)
            {
                Najmovi.Add(n);
            }
        }
    }
}
