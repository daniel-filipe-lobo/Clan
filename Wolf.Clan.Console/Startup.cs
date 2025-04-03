namespace Wolf.Clan.Console;

public class Startup
{
	public GeneralStartup GeneralStartup { get; private set; }

	public Startup()
	{
		GeneralStartup = new GeneralStartup(ConfigureServices);
	}

	private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		int commandTimeoutSeconds = configuration.GetValue<int>("DbCommandTimeoutSeconds");
		string connectionString = configuration.GetConnectionString("Connection").ThrowIfIsNull();

		services.Configure<ClashOfClansApiOptions>(configuration.GetSection(nameof(ClashOfClansApiOptions)));
		services.AddWolfClanBusinessLayer(configuration, commandTimeoutSeconds, connectionString);
		services.AddWolfClanConsole(commandTimeoutSeconds, connectionString);
	}
}
