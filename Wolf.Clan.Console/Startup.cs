namespace Wolf.Clan.Console;

public class Startup
{
	public IServiceProvider Provider { get; private set; }
	private readonly IHost application;
	private readonly IHostBuilder hostBuilder;

	public Startup()
	{
		var basePath = Directory.GetParent(AppContext.BaseDirectory)?.FullName;
		if (basePath == null)
		{
			throw new NullReferenceException("Null base path");
		}

		hostBuilder = Host.CreateDefaultBuilder()
			.ConfigureAppConfiguration(ConfigureApplication)
			.ConfigureServices(ConfigureServices);
		application = hostBuilder.Build();
		Provider = application.Services;
	}

	private void ConfigureApplication(IConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.AddJsonFile("appsettings.json");
	}

	private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
	{
		var configuration = context.Configuration;

		services.AddSingleton<ILoggerFactory, LoggerFactory>();
		services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

		services.AddLogging(builder =>
		{
			builder.AddConfiguration(configuration.GetSection("Logging"));
			builder.AddConsole();
			builder.AddDebug();
		});

		//Services
		services.AddSingleton(configuration);

		int commandTimeoutSeconds = configuration.GetValue<int>("DbCommandTimeoutSeconds");
		string connectionString = configuration.GetConnectionString("Connection").ThrowIfIsNull();

		services.AddWolfClanConsole(commandTimeoutSeconds, connectionString);
	}

	public void Run()
	{
		if (application == null)
		{
			throw new NullReferenceException($"{nameof(application)} is null");
		}
		application.Run();
	}
}
