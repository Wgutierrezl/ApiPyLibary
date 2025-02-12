using System.Reflection.Metadata.Ecma335;
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

        public Task<HttpResponseWrapper<object>> PostPrestamos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PostPrestamos<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> PutPrestamos<T>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> PutPrestamos<T, TActionResponse>(string url, T model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<object>> DeletePrestamos(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseWrapper<TActionResponse>> DeletePrestamos<TActionResponse>(string url)
        {
            throw new NotImplementedException();
        }

    }
}
