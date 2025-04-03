namespace Wolf.Startup.Utilities;

public class GeneralStartup
{
	public IServiceProvider Provider { get; private set; }
	private readonly IHost application;
	private readonly IHostBuilder hostBuilder;
	private readonly Action<IServiceCollection, IConfiguration>? configureServices;
	private readonly bool isAddJsonFileOptional;

	public IConfiguration? Configuration { get; private set; }

	public GeneralStartup(Action<IServiceCollection, IConfiguration>? configureServices = null, bool isAddJsonFileOptional = false)
	{
		this.configureServices = configureServices;
		this.isAddJsonFileOptional = isAddJsonFileOptional;
		var basePath = (Directory.GetParent(AppContext.BaseDirectory)?.FullName) ?? throw new NullReferenceException("Null base path");
		hostBuilder = Host.CreateDefaultBuilder()
			.ConfigureAppConfiguration(ConfigureApplication)
			.ConfigureServices(ConfigureServices);
		application = hostBuilder.Build();
		Provider = application.Services;
	}

	private void ConfigureApplication(IConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.AddJsonFile("appsettings.json", isAddJsonFileOptional);
	}

	private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
	{
		var configuration = context.Configuration;

		services.AddLogger();

		services.AddLogging(builder =>
		{
			builder.AddConfiguration(configuration.GetSection("Logging"));
			builder.AddConsole();
			builder.AddDebug();
		});

		//Services
		services.AddSingleton(configuration);

		if (configureServices != null)
		{
			configureServices(services, configuration);
		}
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
