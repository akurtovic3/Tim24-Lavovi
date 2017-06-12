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
            //Najam.Korisnik.Id zašto nema???
            string urlString = "lavovi.space/api/dodaj_najam.php?pocetni_datum=" + najam.PocetniDatum + "&krajni_datum=" + najam.KrajniDatum + "&cijena=" + najam.Cijena + "&mjesto_preuzimanja=" + najam.MjestoPreuzimanja.Id + "&mjesto_vracanja=" + najam.MjestoVracanja.Id + "&vozilo=" + najam.Vozilo.Id + "&korisnik=";// +najam.Korisnik.Id;
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonArray value = JsonArray.Parse(response).GetArray();
            for (uint i = 0; i < value.Count; i++)
            {
                IJsonValue jsonValue;
                if (value.GetObjectAt(i).TryGetValue("error", out jsonValue))
                {
                    error = jsonValue.GetBoolean();
                }
            }
            callback();
        }


    }
}
