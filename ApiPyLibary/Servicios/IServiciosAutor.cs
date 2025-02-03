namespace ApiPyLibary.Servicios
{
	public interface IServiciosAutor
	{
		Task<HttpResponseWrapper<T>> GetAutores<T>(string url);
		Task<HttpResponseWrapper<object>> PostAutores<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PostAutores<T,TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> PutAutores<T>(string url, T model);
		Task<HttpResponseWrapper<TActionResponse>> PutAutores<T, TActionResponse>(string url, T model);
		Task<HttpResponseWrapper<object>> DeleteAutores(string url);
		Task<HttpResponseWrapper<TActionResponse>> DeleteAutores<TActionResponse>(string url);



	}
}
