using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Devices.Geolocation;

namespace ProjekatRentACar.Models
{
    public class LokacijaDataSource
    {
        private List<Lokacija> lokacije
        {
            get; set;
        }

        public List<Lokacija> Lokacije
        {
            get
            {
                return lokacije;
            }
            set
            {
                lokacije = value;
            }
        }




        private List<Lokacija> lokacijeUBlizini
        {
            get; set;
        }

        public List<Lokacija> LokacijeUBlizini
        {
            get
            {
                return lokacijeUBlizini;
            }
            set
            {
                lokacijeUBlizini = value;
            }
        }


        public async Task preuzmiLokacije(Action callback)
        {
            lokacije = new List<Lokacija>();
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/lokacije.php";
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonArray value = JsonArray.Parse(response).GetArray();
            for (uint i = 0; i < value.Count; i++)
            {
                Lokacija novaLokacija = new Lokacija();
                IJsonValue jsonValue;
                if (value.GetObjectAt(i).TryGetValue("id", out jsonValue))
                {
                    novaLokacija.Id = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("naziv", out jsonValue))
                {
                    novaLokacija.Naziv = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("sirina", out jsonValue))
                {
                    novaLokacija.Sirina = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("duzina", out jsonValue))
                {
                    novaLokacija.Duzina = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("adresa", out jsonValue))
                {
                    novaLokacija.Adresa =jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("opis", out jsonValue))
                {
                    novaLokacija.Opis = jsonValue.GetString();
                }
                lokacije.Add(novaLokacija);
            }
            callback();
        }



        public async Task preuzmiLokacijeUBlizini(Double sirina, Double duzina, Action callback)
        {
            LokacijeUBlizini = new List<Lokacija>();
            HttpClient httpClient = new HttpClient();
            string urlString = "http://lavovi.space/api/nearby_lokacije.php?sirina="+sirina.ToString()+"&duzina="+duzina.ToString()+"&range=30";
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonArray value = JsonArray.Parse(response).GetArray();
            for (uint i = 0; i < value.Count; i++)
            {
                Lokacija novaLokacija = new Lokacija();
                IJsonValue jsonValue;
                if (value.GetObjectAt(i).TryGetValue("id", out jsonValue))
                {
                    novaLokacija.Id = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("naziv", out jsonValue))
                {
                    novaLokacija.Naziv = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("sirina", out jsonValue))
                {
                    novaLokacija.Sirina = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("duzina", out jsonValue))
                {
                    novaLokacija.Duzina = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("adresa", out jsonValue))
                {
                    novaLokacija.Adresa = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("opis", out jsonValue))
                {
                    novaLokacija.Opis = jsonValue.GetString();
                }
                novaLokacija.LokacijaMjesta = new Geopoint(new BasicGeoposition() { Longitude = novaLokacija.Duzina, Latitude = novaLokacija.Sirina });

                LokacijeUBlizini.Add(novaLokacija);
            }
            callback();
        }
    }
}
