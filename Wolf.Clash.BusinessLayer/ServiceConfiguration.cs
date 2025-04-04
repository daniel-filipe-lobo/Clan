namespace Wolf.Clash.BusinessLayer;

public static class ServiceConfiguration
{
	public static void AddWolfClanBusinessLayer(this IServiceCollection services, IConfiguration configuration, int commandTimeoutSeconds, string connectionString)
	{
		services.AddLogger();
		services.AddWolfClanDataLayer(commandTimeoutSeconds, connectionString);

		services.Configure<ClashOfClansApiOptions>(configuration.GetSection(nameof(ClashOfClansApiOptions)));
		services.AddTransient<IClashOfClansApi, ClashOfClansApi>();
		services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
		services.AddTransient<IHttpClientWrapperFactory, HttpClientWrapperFactory>();
	}
}
