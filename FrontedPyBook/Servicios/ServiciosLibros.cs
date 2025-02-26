using System.Text.Json;
using System.Text;

namespace FrontedPyBook.Servicios
{
	public class ServiciosLibros : IServiciosLibros
	{
		private readonly HttpClient _httpClient;

		private JsonSerializerOptions jsonSerializer => new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
		};

		public ServiciosLibros(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responseHttp)
		{
			var response = await responseHttp.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(response, jsonSerializer)!;
		}


		public async Task<HttpResponseWrapper<object>> DeleteLibros(string url)
		{
			var responseHttp = await _httpClient.DeleteAsync(url);
			var Contenido = await responseHttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(Contenido, !responseHttp.IsSuccessStatusCode, responseHttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> DeleteLibros<TActionResponse>(string url)
		{
			var responsehttp = await _httpClient.DeleteAsync(url);
			var contenido = await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<TActionResponse>(contenido, jsonSerializer);
				return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
			}

			return new HttpResponseWrapper<TActionResponse>(default, true, responsehttp);
		}

		public async Task<HttpResponseWrapper<T>> GetLibros<T>(string url)
		{
			var responsehttp = await _httpClient.GetAsync(url);
			var contenido = await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<T>(contenido, jsonSerializer);
				return new HttpResponseWrapper<T>(response, false, responsehttp);
			}
			return new HttpResponseWrapper<T>(default, true, responsehttp);
		}

		public async Task<HttpResponseWrapper<object>> PostLibros<T>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var messajeContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PostAsync(url, messajeContent);
			var content = await responsehttp.Content.ReadAsStringAsync();
			return new HttpResponseWrapper<object>(content, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PostLibros<T, TActionResponse>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var MessageContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PostAsync(url, MessageContent);
			var content = await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<TActionResponse>(content, jsonSerializer);
				return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
			}
			return new HttpResponseWrapper<TActionResponse>(default, true, responsehttp);
		}

		public async Task<HttpResponseWrapper<object>> PutLibros<T>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var messajeContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PutAsync(url, messajeContent);
			return new HttpResponseWrapper<object>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
		}

		public async Task<HttpResponseWrapper<TActionResponse>> PutLibros<T, TActionResponse>(string url, T model)
		{
			var MessageJson = JsonSerializer.Serialize(model);
			var MessageContent = new StringContent(MessageJson, Encoding.UTF8, "application/json");
			var responsehttp = await _httpClient.PutAsync(url, MessageContent);
			var content = await responsehttp.Content.ReadAsStringAsync();
			if (responsehttp.IsSuccessStatusCode)
			{
				var response = JsonSerializer.Deserialize<TActionResponse>(content, jsonSerializer);
				return new HttpResponseWrapper<TActionResponse>(response, false, responsehttp);
			}

			return new HttpResponseWrapper<TActionResponse>(default, !responsehttp.IsSuccessStatusCode, responsehttp);
		}
	}
}
