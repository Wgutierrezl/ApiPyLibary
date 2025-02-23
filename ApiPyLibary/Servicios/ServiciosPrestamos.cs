using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace ApiPyLibary.Servicios
{
    public class ServiciosPrestamos:IServiciosPrestamos
    {
        private readonly HttpClient _httpClient;

        public ServiciosPrestamos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private JsonSerializerOptions _serializerOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responseHttp)
        {
            var response = await responseHttp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, _serializerOptions)!;
        }

        public async Task<HttpResponseWrapper<T>> GetPrestamos<T>(string url)
        {
            var responsehttp=await _httpClient.GetAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            if(responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<T>(content, _serializerOptions);
                return new HttpResponseWrapper<T>(response, false, responsehttp);
            }
            return new HttpResponseWrapper<T>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PostPrestamos<T>(string url, T model)
        {
            var MessageBody = JsonSerializer.Serialize(model);
            var MessageContent = new StringContent(MessageBody, Encoding.UTF8, "application/json");
            var responsehttp=await _httpClient.PostAsync(url, MessageContent);
            return new HttpResponseWrapper<object>(null,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostPrestamos<T, TActionResponse>(string url, T model)
        {
            var messageBody=JsonSerializer.Serialize(model);
            var MessageContente=new StringContent(messageBody, Encoding.UTF8, "application/json");
            var responsehttp=await _httpClient.PostAsync(url,MessageContente);
            var content=await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<TActionResponse>(content,_serializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response,false, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> PutPrestamos<T>(string url, T model)
        {
            var messageBody = JsonSerializer.Serialize(model);
            var MessageContent=new StringContent(messageBody,Encoding.UTF8, "application/json");
            var responsehttp = await _httpClient.PutAsync(url, MessageContent);
            return new HttpResponseWrapper<object>(default,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PutPrestamos<T, TActionResponse>(string url, T model)
        {
            var messageBody=JsonSerializer.Serialize(model);
            var MessageContent=new StringContent(messageBody, Encoding.UTF8, "application/json");
            var responsehttp=await _httpClient.PutAsync(url,MessageContent);
            var Content=await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode) 
            {
                var response = JsonSerializer.Deserialize<TActionResponse>(Content, _serializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode,responsehttp);
        }

        public async Task<HttpResponseWrapper<object>> DeletePrestamos(string url)
        {
            var responsehttp=await _httpClient.DeleteAsync(url);
            var content = await responsehttp.Content.ReadAsStringAsync();
            return new HttpResponseWrapper<object>(content,!responsehttp.IsSuccessStatusCode, responsehttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> DeletePrestamos<TActionResponse>(string url)
        {
            var responsehttp = await _httpClient.DeleteAsync(url);
            var content=await responsehttp.Content.ReadAsStringAsync();
            if (responsehttp.IsSuccessStatusCode)
            {
                var response=JsonSerializer.Deserialize<TActionResponse>(content, _serializerOptions);
                return new HttpResponseWrapper<TActionResponse>(response,false,responsehttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
        }

    }
}
