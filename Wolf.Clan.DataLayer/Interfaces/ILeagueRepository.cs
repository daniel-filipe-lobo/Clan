namespace Wolf.Clan.DataLayer
{
	public interface ILeagueRepository
	{
		Task InsertAsync(League league);
		Task<League?> SelectAsync(string season);
	}
}
