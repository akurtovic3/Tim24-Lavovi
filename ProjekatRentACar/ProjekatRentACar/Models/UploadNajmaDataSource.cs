using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ProjekatRentACar.Models
{
    public class UploadNajmaDataSource
    {

        public bool error;

        public async Task uploadNajam(Najam najam, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/dodaj_najam.php?pocetni_datum='"  + najam.PocetniDatum.ToString("yyyy-MM-dd") + "'&krajni_datum='" + najam.KrajniDatum.ToString("yyyy-MM-dd") + "'&cijena=" + najam.Cijena + "&mjesto_preuzimanja=" + najam.MjestoPreuzimanja.Id + "&mjesto_vracanja=" + najam.MjestoVracanja.Id + "&vozilo=" + najam.Vozilo.Id + "&korisnik=" + App._id;
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonObject value = JsonObject.Parse(response).GetObject();
           
                IJsonValue jsonValue;
                if (value.TryGetValue("error", out jsonValue))
                {
                    error = jsonValue.GetBoolean();
                }
            
            callback();
        }


    }
}
