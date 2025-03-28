namespace Wolf.Clan.BusinessLayer;

public static class ServiceConfiguration
{
	public static void AddWolfClanBusinessLayer(this IServiceCollection services, int commandTimeoutSeconds, string xpandedRawConnectionString)
	{
		services.AddWolfClanDataLayer(commandTimeoutSeconds, xpandedRawConnectionString);

		services.AddTransient<IClashOfClansApi, ClashOfClansApi>();
		services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
		services.AddTransient<IHttpClientWrapperFactory, HttpClientWrapperFactory>();
	}
}
