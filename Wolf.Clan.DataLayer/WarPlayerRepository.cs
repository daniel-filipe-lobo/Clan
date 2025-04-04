﻿namespace Wolf.Clan.DataLayer
{
	internal class WarPlayerRepository : IWarPlayerRepository
	{
		private readonly IDbContextFactory<Context> contextFactory;
		private readonly ILogger<IWarPlayerRepository> logger;

		public WarPlayerRepository(IDbContextFactory<Context> contextFactory, ILogger<IWarPlayerRepository> logger)
		{
			this.contextFactory = contextFactory;
			this.logger = logger;
		}

		public async Task InsertAsync(WarPlayer warPlayer)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					context.WarPlayerSet.Add(warPlayer);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(warPlayer), warPlayer));
			}
		}

		public async Task<IEnumerable<WarPlayer>> SelectAsync(int playerId, IEnumerable<int> warIds)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queryable = (
						from warPlayer in context.WarPlayerSet
						where
							warIds.Contains(warPlayer.WarId) &&
							warPlayer.PlayerId == playerId
						select warPlayer);
					return await queryable.ToListAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(playerId), playerId),
					(nameof(warIds), warIds));
			}
		}
	}
}
