namespace Wolf.Clash.BusinessLayer;

public interface IHttpClientWrapper : IDisposable
{
	IHttpRequestHeadersWraper DefaultRequestHeaders { get; }

	Task<HttpResponseMessage> GetAsync(string requestUri);
	Task<HttpResponseMessage> GetAsync(Uri requestUri);
}
