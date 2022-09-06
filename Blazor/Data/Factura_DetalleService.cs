using FacturadorApi.Model;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Data
{
    public class Factura_DetalleService
    {
        string baseUrl = "https://localhost:7022/";

        public async Task<Factura_Detalle[]> GetAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Factura_Detalle");
            return JsonConvert.DeserializeObject<Factura_Detalle[]>(json);

        }
        public async Task<Factura_Detalle> GetByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/Factura_Detalle/{id}");
            return JsonConvert.DeserializeObject<Factura_Detalle>(json);

        }

        public async Task<HttpResponseMessage> InsertAsync(Factura_Detalle factura)
        {
            var http = new HttpClient();            
            return await http.PostAsync($"{baseUrl}api/Factura_Detalle", getStringContentFromObject(factura)); 

        }
        public async Task<HttpResponseMessage> UpdateAsync(Factura_Detalle factura)
        {
            var http = new HttpClient();
            return await http.PutAsync($"{baseUrl}api/Factura_Detalle", getStringContentFromObject(factura));

        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var http = new HttpClient();
            return await http.DeleteAsync($"{baseUrl}api/Factura_Detalle/{id}");

        }


        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;   
        }

    }
}
