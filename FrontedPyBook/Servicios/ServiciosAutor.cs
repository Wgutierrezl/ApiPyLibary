using System.Net;
using System.Text;
using System.Text.Json;
namespace FrontedPyBook.Servicios
{
	public class ServiciosAutor : IServiciosAutor
	{
		private readonly HttpClient _httpClient;

		private JsonSerializerOptions _serialice = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};

		public ServiciosAutor(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}



		public async Task<HttpResponseWrapper<object>> DeleteAutores(string url)
		{
			var responsehttp=await _httpClient.DeleteAsync(url);
			var content=await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> DeleteAutores<TActionResponse>(string url)
		{
			var responsehttp = await _httpClient.DeleteAsync(url);
			var content=await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<TActionResponse>(content,_serialice);
				return new HttpResponseWrapper<TActionResponse>(response,!responsehttp.IsSuccessStatusCode, responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<T>> GetAutores<T>(string url)
		{
			var responsehttp=await _httpClient.GetAsync(url);
			var contenido=await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<T>(contenido,_serialice);
				return new HttpResponseWrapper<T>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
			}
			return new HttpResponseWrapper<T>(default,!responsehttp.IsSuccessStatusCode,responsehttp);
		}

		public async Task<HttpResponseWrapper<object>> PostAutores<T>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var MessageContent=new StringContent(MessageJson,Encoding.UTF8,"application/json");
			var responsehttp=await _httpClient.PostAsync(url,MessageContent);
			var contenido = await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(contenido, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PostAutores<T, TActionResponse>(string url, T model)
		{
			var MessageJson=JsonSerializer.Serialize(model);
			var MessageContent=new StringContent(MessageJson, Encoding.UTF8,"application/json");
			var responsehttp = await _httpClient.PostAsync(url, MessageContent);
			var content=await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<TActionResponse>(content,_serialice);
				return new HttpResponseWrapper<TActionResponse>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode,responsehttp);
		}

		public async Task<HttpResponseWrapper<object>> PutAutores<T>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var MessageContent=new StringContent(MessageJson, Encoding.UTF8,"application/json");
			var responsehttp=await _httpClient.PutAsync(url,MessageContent);
			var content= await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PutAutores<T, TActionResponse>(string url, T model)
		{
			var MessageJson=JsonSerializer.Serialize(model);
			var MessageContent=new StringContent(MessageJson,Encoding.UTF8,"application/json");
			var responsehttp=await _httpClient.PutAsync(url, MessageContent);
			var content=await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response=JsonSerializer.Deserialize<TActionResponse>(content,_serialice);
				return new HttpResponseWrapper<TActionResponse>(response, !responsehttp.IsSuccessStatusCode, responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default,!responsehttp.IsSuccessStatusCode,responsehttp);
		}
	}
}
