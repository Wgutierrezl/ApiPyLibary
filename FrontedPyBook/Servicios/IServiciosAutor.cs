namespace FrontedPyBook.Servicios
{
	public interface IServiciosAutor
	{
		Task<HttpResponseWrapper<T>> GetAutores<T>(string url);
		Task<HttpResponseWrapper<object>> PostAutores<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PostAutores<T,TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> PutAutores<T>(string url, T model);	
		Task<HttpResponseWrapper<TActionResponse>> PutAutores<T,TActionResponse>(string url,T model);	
		Task<HttpResponseWrapper<object>> DeleteAutores(string url);
		Task<HttpResponseWrapper<TActionResponse>> DeleteAutores<TActionResponse>(string url);	
	}

	public interface IServiciosLibros
	{
		Task<HttpResponseWrapper<T>> GetLibros<T>(string url);
		Task<HttpResponseWrapper<object>> PostLibros<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PostLibros<T, TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> PutLibros<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PutLibros<T, TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> DeleteLibros(string url);
		Task<HttpResponseWrapper<TActionResponse>> DeleteLibros<TActionResponse>(string url);
	}

	public interface IServiciosPrestamos
	{
		Task<HttpResponseWrapper<T>> GetPrestamos<T>(string url);
		Task<HttpResponseWrapper<object>> PostPrestamos<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PostPrestamos<T, TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> PutPrestamos<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PutPrestamos<T, TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> DeletePrestamos(string url);
		Task<HttpResponseWrapper<TActionResponse>> DeletePrestamos<TActionResponse>(string url);
	}
}
