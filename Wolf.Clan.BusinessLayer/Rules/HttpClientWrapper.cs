namespace Wolf.Clan.BusinessLayer.Rules
{
	internal class HttpClientWrapper : IHttpClientWrapper
	{
		private readonly HttpClient httpClient;
		private bool isDisposed;

		public IHttpRequestHeadersWraper DefaultRequestHeaders => new HttpRequestHeadersWraper(httpClient.DefaultRequestHeaders);

		public HttpClientWrapper()
		{
			httpClient = new HttpClient();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				isDisposed = true;
				if (disposing)
				{
					httpClient.Dispose();
				}
			}
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return httpClient.GetAsync(requestUri);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri)
		{
			return httpClient.GetAsync(requestUri);
		}
	}
}
