using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ProjekatRentACar.Models
{
    public class NajmoviKorisnikaDataSource
    {
        private List<NajamWebModel> najmovi
        {
            get; set;
        }

        public List<NajamWebModel> Najmovi
        {
            get
            {
                return najmovi;
            }
            set
            {
                najmovi = value;
            }
        }


        public async Task preuzmiNajmove(int korisnikID, Action callback)
        {
            Najmovi = new List<NajamWebModel>();
            HttpClient httpClient = new HttpClient();
            string urlString = "http://lavovi.space/api/lista_iznajmljenih_vozila.php?korisnik_id=" + korisnikID.ToString();
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonArray value = JsonArray.Parse(response).GetArray();
            for (uint i = 0; i < value.Count; i++)
            {
                NajamWebModel noviNajam = new NajamWebModel();
                IJsonValue jsonValue;
                if (value.GetObjectAt(i).TryGetValue("id", out jsonValue))
                {
                    noviNajam.Id = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("pocetni_datum", out jsonValue))
                {
                    noviNajam.PocetniDatum =  DateTime.ParseExact(jsonValue.GetString().Replace("\"",""), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                }
                if (value.GetObjectAt(i).TryGetValue("krajni_datum", out jsonValue))
                {
                    noviNajam.KrajnjiDatum = DateTime.ParseExact(jsonValue.ToString().Replace("\"", ""), "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                }
                if (value.GetObjectAt(i).TryGetValue("cijena", out jsonValue))
                {
                    noviNajam.Cijena = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("proizvodjac", out jsonValue))
                {
                    noviNajam.Proizvodjac = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("model", out jsonValue))
                {
                    noviNajam.Model = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("slika", out jsonValue))
                {
                    noviNajam.Slika = jsonValue.GetString();
                }

                Najmovi.Add(noviNajam);
            }
            callback();
        }
    }

   
}
