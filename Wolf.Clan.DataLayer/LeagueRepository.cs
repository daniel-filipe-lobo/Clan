namespace Wolf.Clan.DataLayer
{
	internal class LeagueRepository : ILeagueRepository
	{
		private readonly IDbContextFactory<Context> contextFactory;
		private readonly ILogger<ILeagueRepository> logger;

		public LeagueRepository(IDbContextFactory<Context> contextFactory, ILogger<ILeagueRepository> logger)
		{
			this.contextFactory = contextFactory;
			this.logger = logger;
		}

		public async Task InsertAsync(League league)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					context.LeagueSet.Add(league);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler<DataExceptionFactory>.Create(logger, exception,
					(nameof(league), league));
			}
		}

		public async Task<League?> SelectAsync(string season)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queriable = (
						from league in context.LeagueSet
						where league.Season == season
						select league);
					return await queriable.SingleOrDefaultAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler<DataExceptionFactory>.Create(logger, exception,
					(nameof(season), season));
			}
		}
	}
}
