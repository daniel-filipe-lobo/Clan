﻿namespace Wolf.Clan.DataLayer
{
	internal class LeagueWarRepository : ILeagueWarRepository
	{
		private readonly IDbContextFactory<Context> contextFactory;
		private readonly ILogger<ILeagueWarRepository> logger;

		public LeagueWarRepository(IDbContextFactory<Context> contextFactory, ILogger<ILeagueWarRepository> logger)
		{
			this.contextFactory = contextFactory;
			this.logger = logger;
		}

		public async Task InsertAsync(LeagueWar leagueWar)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					context.LeagueWarSet.Add(leagueWar);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(leagueWar), leagueWar));
			}
		}

		public async Task<LeagueWar?> SelectAsync(int leagueId, int warId)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queryable = (
					from leagueWar in context.LeagueWarSet
					where leagueWar.LeagueId == leagueId &&
						leagueWar.WarId == warId
					select leagueWar);
					return await queryable.SingleOrDefaultAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(leagueId), leagueId),
					(nameof(warId), warId));
			}
		}

		public async Task<IEnumerable<LeagueWar>> SelectAsync(IEnumerable<int> warIds)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queryable =
					from leagueWar in context.LeagueWarSet
					where warIds.Contains(leagueWar.WarId)
					select leagueWar;
					return await queryable.ToListAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(warIds), warIds));
			}
		}
	}
}
