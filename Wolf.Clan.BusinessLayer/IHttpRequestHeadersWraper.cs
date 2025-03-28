namespace Wolf.Clan.BusinessLayer
{
	public interface IHttpRequestHeadersWraper
	{
		AuthenticationHeaderValue? Authorization { get; set; }
	}
}