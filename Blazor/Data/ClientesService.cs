using FacturadorApi.Model;
using Newtonsoft.Json;
using System.Text;

namespace Blazor.Data
{
    public class ClientesService
    {
        string baseUrl = "https://localhost:7022/";

        public async Task<Cliente[]> GetClienteAsync()
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/cliente");
            return JsonConvert.DeserializeObject<Cliente[]>(json);

        }
        public async Task<Cliente> GetClienteByIdAsync(string id)
        {
            HttpClient http = new HttpClient();
            var json = await http.GetStringAsync($"{baseUrl}api/cliente/{id}");
            return JsonConvert.DeserializeObject<Cliente>(json);

        }

        public async Task<HttpResponseMessage> InsertClienteAsync(Cliente cliente)
        {
            var http = new HttpClient();            
            return await http.PostAsync($"{baseUrl}api/cliente", getStringContentFromObject(cliente)); 

        }
        public async Task<HttpResponseMessage> UpdateClienteAsync(Cliente cliente)
        {
            var http = new HttpClient();
            return await http.PutAsync($"{baseUrl}api/cliente", getStringContentFromObject(cliente));

        }

        public async Task<HttpResponseMessage> DeleteClienteAsync(int id)
        {
            var http = new HttpClient();
            return await http.DeleteAsync($"{baseUrl}api/cliente/{id}");

        }


        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;   
        }

    }
}
