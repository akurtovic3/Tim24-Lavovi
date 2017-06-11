using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.ViewModels
{
    public class KorisnickiRacunViewModel
    {
        public Korisnik TrenutniKorisnik { get; set; }
        public KorisnickiRacunViewModel(Korisnik korisnik)
        {
            TrenutniKorisnik = korisnik;

        }
    }
}
