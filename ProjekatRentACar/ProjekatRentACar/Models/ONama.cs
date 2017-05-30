using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    class ONama
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Adresa { get; set; }
        public string Sjediste { get; set; }
        public string Copyright { get; set; }
        public string VerzijaAplikacije { get; set; }
    }
}
