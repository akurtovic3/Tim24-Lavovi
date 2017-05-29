using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    public class Informacije
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int informacijeID { get; set; }
        public string ONama { get; set; }
        public string Privatnost { get; set; }
        public string UsloviKoristenja { get; set; }
    }
}
