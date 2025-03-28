﻿namespace Wolf.Clan.DataLayer
{
	internal class AttackRepository : IAttackRepository
	{
		private readonly IDbContextFactory<Context> contextFactory;
		private readonly ILogger<IAttackRepository> logger;

		public AttackRepository(IDbContextFactory<Context> contextFactory, ILogger<IAttackRepository> logger)
		{
			this.contextFactory = contextFactory;
			this.logger = logger;
		}

		public async Task<Attack?> SelectAsync(int playerId, int warId, int order)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queryable = 
						from attack in context.AttackSet
						where
							attack.PlayerId == playerId &&
							attack.WarId == warId &&
							attack.Order == order
						select attack;
					return await queryable.SingleOrDefaultAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(playerId), playerId),
					(nameof(warId), warId),
					(nameof(order), order));
			}
		}

		public async Task InsertAsync(Attack attack)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					context.AttackSet.Add(attack);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(attack), attack));
			}
		}

		public async Task UpdateAsync(Attack attack)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					context.AttackSet.Update(attack);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(attack), attack));
			}
		}

		public async Task<IEnumerable<Attack>> SelectAsync(int playerId, IEnumerable<int> warIds)
		{
			try
			{
				using (var context = contextFactory.CreateDbContext())
				{
					var queryable = 
						from attack in context.AttackSet
						where
							warIds.Contains(attack.WarId) &&
							attack.PlayerId == playerId
						select attack;
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
