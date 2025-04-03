namespace Wolf.Startup.Utilities;

public class GeneralStartup
{
	public IServiceProvider Provider { get; private set; }
	private readonly Action<IServiceCollection, IConfiguration>? configureServices;
	private readonly bool isAddJsonFileOptional;

	public IConfiguration? Configuration { get; private set; }

	public GeneralStartup(IHostBuilder hostBuilder, Func<IServiceProvider> getServiceProvider, Action<IServiceCollection, IConfiguration>? configureServices = null, bool isAddJsonFileOptional = false)
	{
		this.configureServices = configureServices;
		this.isAddJsonFileOptional = isAddJsonFileOptional;
		hostBuilder
			.ConfigureAppConfiguration(ConfigureApplication)
			.ConfigureServices(ConfigureServices);
		Provider = getServiceProvider();
	}

	private void ConfigureApplication(IConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.AddJsonFile("appsettings.json", isAddJsonFileOptional);
	}

	private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
	{
		var configuration = context.Configuration;

		services.AddLogging(builder =>
		{
			builder.AddConfiguration(configuration.GetSection("Logging"));
			builder.AddConsole();
			builder.AddDebug();
		});

		//Services
		services.AddSingleton<ILoggerFactory, LoggerFactory>();
		services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
		services.AddTransient(typeof(Lazy<>), typeof(LazyInstance<>));
		services.AddSingleton(configuration);

		if (configureServices != null)
		{
			configureServices(services, configuration);
		}
	}
}
