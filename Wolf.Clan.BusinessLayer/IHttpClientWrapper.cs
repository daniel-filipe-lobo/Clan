namespace Wolf.Clan.BusinessLayer;

public interface IHttpClientWrapper : IDisposable
{
	IHttpRequestHeadersWraper DefaultRequestHeaders { get; }

	Task<HttpResponseMessage> GetAsync(string requestUri);
}
