using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ApiPyLibary.Servicios
{
	public class ServiciosAutor:IServiciosAutor
	{
		private readonly HttpClient _httpClient;

		public ServiciosAutor(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private JsonSerializerOptions jsonSerializerOptions => new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
		};

		//private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responseHttp)
		//{
		//	var response = await responseHttp.Content.ReadAsStringAsync();
		//	return JsonSerializer.Deserialize<T>(response, jsonSerializerOptions)!;
		//}
		public async Task<HttpResponseWrapper<object>> DeleteAutores(string url)
		{
			var responseHttp = await _httpClient.DeleteAsync(url);
			var contenido=await responseHttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(contenido,!responseHttp.IsSuccessStatusCode,responseHttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> DeleteAutores<TActionResponse>(string url)
		{
			var responseHttp=await _httpClient.DeleteAsync(url);
			var contenido=await responseHttp.Content.ReadAsStringAsync();
			if(responseHttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<TActionResponse>(contenido,jsonSerializerOptions);
				return new HttpResponseWrapper<TActionResponse>(response, false,responseHttp);

			}

			return new HttpResponseWrapper<TActionResponse>(default,true,responseHttp);
			
		}

		public async Task<HttpResponseWrapper<T>> GetAutores<T>(string url)
		{
			var responseHttp=await _httpClient.GetAsync(url);
			var contenido = await responseHttp.Content.ReadAsStringAsync();
			if(responseHttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<T>(contenido,jsonSerializerOptions);
				return new HttpResponseWrapper<T>(response, false,responseHttp);
			}
			return new HttpResponseWrapper<T>(default,true, responseHttp);
		}

		public async Task<HttpResponseWrapper<object>> PostAutores<T>(string url, T model)
		{
			var messageContent=JsonSerializer.Serialize(model);
			var content=new StringContent(messageContent,Encoding.UTF8,"application/json");
			var responsehttp=await _httpClient.PostAsync(url,content);
			var contenido=await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(contenido, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PostAutores<T, TActionResponse>(string url, T model)
		{
			var messageContent = JsonSerializer.Serialize(model);
			var content = new StringContent(messageContent, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PostAsync(url, content);
			var contenido = await responsehttp.Content.ReadAsStringAsync();

			if(responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<TActionResponse>(contenido, jsonSerializerOptions);
				return new HttpResponseWrapper<TActionResponse>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default, true, responsehttp);
		}

		public async Task<HttpResponseWrapper<object>> PutAutores<T>(string url, T model)
		{
			var body=JsonSerializer.Serialize(model);
			var MessageContent=new StringContent(body, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PutAsync(url, MessageContent);
			var Contenido = await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(Contenido,!responsehttp.IsSuccessStatusCode,responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PutAutores<T, TActionResponse>(string url, T model)
		{
			var body = JsonSerializer.Serialize(model);
			var MessageContent = new StringContent(body, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PutAsync(url, MessageContent);
			var Contenido = await responsehttp.Content.ReadAsStringAsync();
			if(responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<TActionResponse>(Contenido, jsonSerializerOptions);
				return new HttpResponseWrapper<TActionResponse>(response,false,responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default,true,responsehttp);
		}
	}
}
