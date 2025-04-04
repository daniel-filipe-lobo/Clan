
namespace Wolf.Clash.BusinessLayer
{
	public interface IClashOfClansApi
	{
		Task<T?> GetAsync<T>(string requestUri);
		Task<ClanDetailResponse?> GetClanAsync();
		Task<LeagueGroupResponse?> GetLeagueGroupAsync();
	}
}
