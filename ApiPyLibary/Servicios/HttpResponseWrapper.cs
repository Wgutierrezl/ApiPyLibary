
using System.Net;
using System.Net.Http;

namespace ApiPyLibary.Servicios
{
	public class HttpResponseWrapper<T>
	{
		public bool Error { get; set; }
		public T? Response { get; set; }
		public HttpResponseMessage? Message { get; set; }

		public HttpResponseWrapper(T? response, bool error ,HttpResponseMessage? message)
		{
			Error = error;
			Response = response;
			Message = message;
		}

		public async Task<string> GetErrorMessage()
		{

			return await Message!.Content.ReadAsStringAsync();
		}
	}
}
