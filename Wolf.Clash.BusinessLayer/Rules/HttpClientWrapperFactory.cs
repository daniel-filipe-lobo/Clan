namespace Wolf.Clash.BusinessLayer.Rules
{
	internal class HttpClientWrapperFactory : IHttpClientWrapperFactory
	{
		public IHttpClientWrapper Create()
		{
			return new HttpClientWrapper();
		}
	}
}
