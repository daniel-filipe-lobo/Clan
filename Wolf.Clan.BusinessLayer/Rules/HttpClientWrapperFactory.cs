namespace Wolf.Clan.BusinessLayer.Rules
{
	internal class HttpClientWrapperFactory : IHttpClientWrapperFactory
	{
		public IHttpClientWrapper Create()
		{
			return new HttpClientWrapper();
		}
	}
}
