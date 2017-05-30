using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    class Postavke
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostavkeId { get; set; }
        public string Valuta { get; set; }
        public bool Lokacija { get; set; }
        public bool Notifikacije { get; set; }
    }
}
