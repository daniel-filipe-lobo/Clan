namespace Wolf.Clash.DataLayer
{
	public interface ILeagueWarRepository
	{
		Task InsertAsync(LeagueWar leagueWar);
		Task<LeagueWar?> SelectAsync(int leagueId, int warId);
		Task<IEnumerable<LeagueWar>> SelectAsync(IEnumerable<int> warIds);
	}
}
