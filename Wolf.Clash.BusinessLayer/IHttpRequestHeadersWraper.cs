namespace Wolf.Clash.BusinessLayer
{
	public interface IHttpRequestHeadersWraper
	{
		AuthenticationHeaderValue? Authorization { get; set; }
	}
}