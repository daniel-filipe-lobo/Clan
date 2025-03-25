namespace Wolf.Clan.Console;

public static class ServiceConfiguration
{
	public static void AddWolfClanConsole(this IServiceCollection services, IConfiguration configuration, int commandTimeoutSeconds, string xpandedRawConnectionString)
	{
		services.AddWolfClanDataLayer(configuration, commandTimeoutSeconds, xpandedRawConnectionString);

		services.AddTransient<IClash, Clash>();
	}
}
