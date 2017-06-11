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

    public class LoginDataSource
    {
        
        public bool isError = false;
        public string ErrorText = "";

        public Korisnik noviKorisnik { get; set; }
        public Uposlenik noviUposlenik { get; set; }

        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string datum_rodjenja { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string drzava { get; set; }
        public string adresa { get; set; }
        public string datum_zaposlenja { get; set; }
        public string rating { get; set; }
        public string role { get; set; }

        public async Task prijaviKorisnika(string email, string sifra, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/login.php";
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("sifra", sifra)
            });
            var result = await httpClient.PostAsync(new Uri(urlString), content);
            string response = await result.Content.ReadAsStringAsync();
            Debug.WriteLine(response);
            JsonObject value = JsonObject.Parse(response).GetObject();
            
                IJsonValue jsonValue;
                if (value.TryGetValue("error", out jsonValue))
                {
                    isError = jsonValue.GetBoolean();
                }
                if(isError == true)
                {
                    if (value.TryGetValue("error_msg", out jsonValue))
                    {
                        ErrorText = jsonValue.GetString();
                    }
                    callback();
            }else
            {
                if (value.TryGetValue("id", out jsonValue))
                {
                    id = Convert.ToInt16(jsonValue.GetString());
                }
                if (value.TryGetValue("ime", out jsonValue))
                {
                    ime = jsonValue.GetString();
                }
                if (value.TryGetValue("prezime", out jsonValue))
                {
                    prezime = jsonValue.GetString();
                }
                if (value.TryGetValue("datum_rodjenja", out jsonValue))
                {
                    datum_rodjenja = jsonValue.GetString();
                }
                if (value.TryGetValue("telefon", out jsonValue))
                {
                    telefon = jsonValue.GetString();
                }
                if (value.TryGetValue("email", out jsonValue))
                {
                    email = jsonValue.GetString();
                }
                if (value.TryGetValue("drzava", out jsonValue))
                {
                    drzava = jsonValue.GetString();
                }
                if (value.TryGetValue("adresa", out jsonValue))
                {
                    adresa = jsonValue.GetString();
                }
                if (value.TryGetValue("datum_zaposlenja", out jsonValue))
                {
                    datum_zaposlenja = (jsonValue.ValueType == JsonValueType.Null
) ? null : jsonValue.GetString();//?? jsonValue.GetString();
                }
                if (value.TryGetValue("rating", out jsonValue))
                {
                    rating = jsonValue.GetString();
                }
                if (value.TryGetValue("role", out jsonValue))
                {
                    role = jsonValue.GetString();
                }
                if(role == "1")
                {
                    noviKorisnik = new Korisnik(ime,  prezime, DateTime.ParseExact(datum_rodjenja, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture),  telefon,  email,  adresa,
            (Medalje)(Convert.ToInt32(rating)), id);
                }else if(role == "2")
                {
                    noviUposlenik = new Uposlenik(id, ime,prezime, DateTime.ParseExact(datum_rodjenja, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture), telefon, email, adresa, DateTime.ParseExact(datum_zaposlenja, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture));
                }
              

                //---------------------
                callback();

            }
        }
    }
}
