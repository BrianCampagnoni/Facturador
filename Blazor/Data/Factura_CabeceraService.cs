using FacturadorApi.Model;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Data
{
    public class Factura_CabeceraService
    {
        string baseUrl = "https://localhost:7022/";

        public async Task<Factura_Cabecera[]> GetAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Factura_Cabecera");
            return JsonConvert.DeserializeObject<Factura_Cabecera[]>(json);

        }
        public async Task<Factura_Cabecera> GetByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Factura_Cabecera/{id}");
            return JsonConvert.DeserializeObject<Factura_Cabecera>(json);

        }

        public async Task<HttpResponseMessage> InsertAsync(Factura_Cabecera articulo)
        {
            var http = new HttpClient();            
            return await http.PostAsync($"{baseUrl}api/Factura_Cabecera", getStringContentFromObject(articulo)); 

        }
        public async Task<HttpResponseMessage> UpdateAsync(Factura_Cabecera articulo)
        {
            var http = new HttpClient();
            return await http.PutAsync($"{baseUrl}api/Factura_Cabecera", getStringContentFromObject(articulo));

        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var http = new HttpClient();
            return await http.DeleteAsync($"{baseUrl}api/Factura_Cabecera/{id}");

        }


        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;   
        }

    }
}
