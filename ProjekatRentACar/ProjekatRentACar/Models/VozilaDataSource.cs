using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ProjekatRentACar.Models
{
    public class VozilaDataSource {

        private List<Vozilo> vozila
        {
            get; set;
        }

        public List<Vozilo> Vozila
        {
            get
            {
                return vozila;
            }
            set
            {
                vozila = value;
            }
        }

        
        public async Task preuzmiVozila(DateTime from, DateTime to, Action callback)
        {
            vozila = new List<Vozilo>();
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/vozila.php?from_date=%22" + from.ToString("yyyy-MM-dd") + "%22&to_date=%22" + to.ToString("yyyy-MM-dd") + "%22";
            string response = await httpClient.GetStringAsync(new Uri(urlString));
            JsonArray value = JsonArray.Parse(response).GetArray();
            for (uint i = 0; i < value.Count; i++)
            {
                Vozilo novoVozilo = new Vozilo();
                IJsonValue jsonValue;
                if (value.GetObjectAt(i).TryGetValue("id", out jsonValue))
                {
                    novoVozilo.Id = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("tip", out jsonValue))
                {
                    novoVozilo.Tip = (TipVozila)(Convert.ToInt32(jsonValue.GetString()));
                }
                if (value.GetObjectAt(i).TryGetValue("proizvodjac", out jsonValue))
                {
                    novoVozilo.Proizvodjac = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("model", out jsonValue))
                {
                    novoVozilo.Model = jsonValue.GetString();
                }
                if (value.GetObjectAt(i).TryGetValue("snaga", out jsonValue))
                {
                    novoVozilo.Snaga = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("vrsta_goriva", out jsonValue))
                {
                    novoVozilo.VrstaGoriva = (VrstaGoriva)(Convert.ToInt32(jsonValue.GetString()));
                }
                if (value.GetObjectAt(i).TryGetValue("kilometraza", out jsonValue))
                {
                    novoVozilo.Snaga = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("broj_sjedista", out jsonValue))
                {
                    novoVozilo.BrojSjedista = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("broj_vrata", out jsonValue))
                {
                    novoVozilo.BrojVrata = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("vrsta_mjenjaca", out jsonValue))
                {
                    novoVozilo.VrstaMjenjaca = (Mjenjac)(Convert.ToInt32(jsonValue.GetString()));
                }
                if (value.GetObjectAt(i).TryGetValue("kubikaza", out jsonValue))
                {
                    novoVozilo.Kubikaza = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("godiste", out jsonValue))
                {
                    novoVozilo.Godiste = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("klima", out jsonValue))
                {
                    novoVozilo.Klima = (jsonValue.GetString() == "0") ? false : true;
                }
                if (value.GetObjectAt(i).TryGetValue("zapremina_prtljaznika", out jsonValue))
                {
                    novoVozilo.ZapreminaPrtljaznika = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("navigacija", out jsonValue))
                {
                    novoVozilo.Navigacija = (jsonValue.GetString() == "0") ? false : true;
                }
                if (value.GetObjectAt(i).TryGetValue("cijena_po_danu", out jsonValue))
                {
                    novoVozilo.CijenaPoDanu = Convert.ToDouble(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("popust", out jsonValue))
                {
                    novoVozilo.Popust = Convert.ToInt32(jsonValue.GetString());
                }
                if (value.GetObjectAt(i).TryGetValue("slika", out jsonValue))
                {
                    novoVozilo.Slika = jsonValue.GetString();
                }
                vozila.Add(novoVozilo);
            }
            callback();
        }


    }



}
