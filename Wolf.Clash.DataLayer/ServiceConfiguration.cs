namespace Wolf.Clash.DataLayer
{
	public static class ServiceConfiguration
	{
		public static void AddWolfClanDataLayer(this IServiceCollection services, int commandTimeoutSeconds, string connectionString)
		{
			services.AddDbContextFactory<Context>(options =>
				{
					options.UseSqlServer(
						connectionString,
						providerOptions => providerOptions.CommandTimeout(commandTimeoutSeconds));
					options.EnableSensitiveDataLogging();
				},
				ServiceLifetime.Transient);

			services.AddTransient<IPlayerRepository, PlayerRepository>();
			services.AddTransient<ILeagueRepository, LeagueRepository>();
			services.AddTransient<IWarRepository, WarRepository>();
			services.AddTransient<ILeagueWarRepository, LeagueWarRepository>();
			services.AddTransient<IAttackRepository, AttackRepository>();
			services.AddTransient<IPlayerRepository, PlayerRepository>();
			services.AddTransient<IWarPlayerRepository, WarPlayerRepository>();
		}
	}
}