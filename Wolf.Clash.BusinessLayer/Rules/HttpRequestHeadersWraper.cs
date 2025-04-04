namespace Wolf.Clash.BusinessLayer.Rules
{
	internal class HttpRequestHeadersWraper : IHttpRequestHeadersWraper
	{
		private HttpRequestHeaders defaultRequestHeaders;

		public AuthenticationHeaderValue? Authorization { get { return defaultRequestHeaders.Authorization; } set { defaultRequestHeaders.Authorization = value; } }
		
		public HttpRequestHeadersWraper(HttpRequestHeaders defaultRequestHeaders)
		{
			this.defaultRequestHeaders = defaultRequestHeaders;
		}
	}
}
