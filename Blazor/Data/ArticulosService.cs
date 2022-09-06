using FacturadorApi.Model;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Data
{
    public class ArticulosService
    {
        string baseUrl = "https://localhost:7022/";

        public async Task<Articulo[]> GetAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Articulos");
            return JsonConvert.DeserializeObject<Articulo[]>(json);

        }
        public async Task<Articulo> GetByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Articulos/{id}");
            return JsonConvert.DeserializeObject<Articulo>(json);

        }

        public async Task<HttpResponseMessage> InsertAsync(Articulo articulo)
        {
            var http = new HttpClient();            
            return await http.PostAsync($"{baseUrl}api/Articulos", getStringContentFromObject(articulo)); 

        }
        public async Task<HttpResponseMessage> UpdateAsync(Articulo articulo)
        {
            var http = new HttpClient();
            return await http.PutAsync($"{baseUrl}api/Articulos", getStringContentFromObject(articulo));

        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var http = new HttpClient();
            return await http.DeleteAsync($"{baseUrl}api/Articulos/{id}");

        }


        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;   
        }

    }
}
