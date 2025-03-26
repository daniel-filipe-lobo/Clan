namespace Wolf.Clan.Console;

public static class ServiceConfiguration
{
	public static void AddWolfClanConsole(this IServiceCollection services, int commandTimeoutSeconds, string xpandedRawConnectionString)
	{
		services.AddWolfClanDataLayer(commandTimeoutSeconds, xpandedRawConnectionString);

		services.AddTransient<IClash, Clash>();
	}
}
