using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatRentACar.Models
{
    public class UploadVozilaDataSource
    {


        public bool isError = false;
        public string ErrorText = "";


        

        public async Task unesiVozilo(Vozilo vozilo, byte[] slika, Action callback)
        {
            HttpClient httpClient = new HttpClient();
            string urlString = "http://www.lavovi.space/api/upload_vozila.php";
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new ByteArrayContent(slika, 0, slika.Count()), "fileToUpload", vozilo.Slika);
            form.Add(new StringContent(((int)vozilo.Tip).ToString()), "tip");
            form.Add(new StringContent(vozilo.Proizvodjac), "proizvodjac");
            form.Add(new StringContent(vozilo.Model), "model");
            form.Add(new StringContent(vozilo.Snaga.ToString()), "snaga");
            form.Add(new StringContent(((int)vozilo.VrstaGoriva).ToString()), "vrsta_goriva");
            form.Add(new StringContent(vozilo.Kilometraza.ToString()), "kilometraza");
            form.Add(new StringContent(vozilo.BrojSjedista.ToString()), "broj_sjedista");
            form.Add(new StringContent(vozilo.BrojVrata.ToString()), "broj_vrata");
            form.Add(new StringContent(((int)vozilo.VrstaMjenjaca).ToString()), "vrsta_mjenjaca");
            form.Add(new StringContent(vozilo.Kubikaza.ToString()), "kubikaza");
            form.Add(new StringContent(vozilo.Godiste.ToString()), "godiste");
            form.Add(new StringContent(vozilo.Klima.ToString()), "klima");
            form.Add(new StringContent(vozilo.ZapreminaPrtljaznika.ToString()), "zapremina_prtljaznika");
            form.Add(new StringContent(vozilo.Navigacija.ToString()), "navigacija");
            form.Add(new StringContent(vozilo.CijenaPoDanu.ToString()), "cijena_po_danu");
            form.Add(new StringContent(vozilo.Popust.ToString()), "popust");

            var result = await httpClient.PostAsync(new Uri(urlString), form);
            string response = await result.Content.ReadAsStringAsync();
            Debug.WriteLine(response);
            JsonObject value = JsonObject.Parse(response).GetObject();


            IJsonValue jsonValue;
            if (value.TryGetValue("error", out jsonValue))
            {
                isError = jsonValue.GetBoolean();
            }
            if (value.TryGetValue("error_msg", out jsonValue))
            {
                ErrorText = jsonValue.GetString();
            }
            callback();
        }
    }
}
