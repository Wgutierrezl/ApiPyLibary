using System.Net;

namespace FrontedPyBook.Servicios
{
	public class HttpResponseWrapper<T>
	{
		public T? Response { get; set; }
		public bool Error { get; set; }
		public HttpResponseMessage? HttpResponseMessage { get; set; }

		public HttpResponseWrapper(T? response, bool error, HttpResponseMessage? httpResponseMessage)
		{
			Response = response;
			Error = error;
			HttpResponseMessage = httpResponseMessage;
		}

		public async Task<string> GetErrorMessage()
		{
			if(!Error)
			{
				return null;

			}

			var codigoestatus = HttpResponseMessage!.StatusCode;
			if(codigoestatus==HttpStatusCode.NotFound )
			{
				return "Elemento no encontrado";
			}
			else if (codigoestatus==HttpStatusCode.BadRequest)
			{
				return await HttpResponseMessage.Content.ReadAsStringAsync();
			}
			else if(codigoestatus==HttpStatusCode.Unauthorized )
			{
				return "Tienes qie logearte para hacer la accion";
			}
			else if(codigoestatus==HttpStatusCode.Forbidden )
			{
				return "No tienes permiso para hacer la accion";
			}
			return "Ha ocurrido un error inesperado";
		}
	}
}
