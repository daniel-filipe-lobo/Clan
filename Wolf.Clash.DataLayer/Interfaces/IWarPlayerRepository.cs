namespace Wolf.Clash.DataLayer
{
	public interface IWarPlayerRepository
	{
		Task InsertAsync(WarPlayer warPlayer);
		Task<IEnumerable<WarPlayer>> SelectAsync(int playerId, IEnumerable<int> warIds);
	}
}