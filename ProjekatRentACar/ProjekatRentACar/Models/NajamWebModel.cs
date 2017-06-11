using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class NajamWebModel
    {
        public int Id { get; set; }
        public DateTime PocetniDatum { get; set; }
        public DateTime KrajnjiDatum { get; set; }
        public double Cijena { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public string Slika { get; set; }
    }
}
