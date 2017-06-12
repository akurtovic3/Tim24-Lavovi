using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.ViewModels
{
    public class DetaljiVozacaViewModel
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }

        


        public Najam najam { get; set; }
        public DetaljiVozacaViewModel(Najam najam)
        {
            this.najam = najam;
            id = App._id;
            ime = App._ime;
            prezime = App._prezime;
            telefon = App._telefon;
            email = App._email;
        }
    }
}
