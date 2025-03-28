namespace Wolf.Clan.BusinessLayer
{
	public interface IClashOfClansApi
	{
		Task<T?> GetAndDeserializeAsync<T>(string requestUri);
	}
}
