namespace Wolf.Clan.WebApi;

public class Startup
{
	public GeneralStartup GeneralStartup { get; private set; }

	public Startup(IHostBuilder hostBuilder, Func<IServiceProvider> getServiceProvider)
	{
		GeneralStartup = new GeneralStartup(hostBuilder, getServiceProvider, ConfigureServices);
	}

	private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		// Add services to the container.
		int commandTimeoutSeconds = configuration.GetValue<int>("DbCommandTimeoutSeconds");
		string connectionString = configuration.GetConnectionString("Connection").ThrowIfIsNull();

		services.Configure<ClashOfClansApiOptions>(configuration.GetSection(nameof(ClashOfClansApiOptions)));
		services.AddWolfClanBusinessLayer(configuration, commandTimeoutSeconds, connectionString);
		services.AddControllers();
		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		services.AddOpenApi();
	}
}
