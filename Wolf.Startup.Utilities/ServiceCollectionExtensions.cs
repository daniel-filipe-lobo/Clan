namespace Wolf.Startup.Utilities
{
	public static class ServiceCollectionExtensions
	{
		public static void AddLoggingAndConfiguration(this IServiceCollection services, HostBuilderContext context)
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
		}

		public static void AddLogger(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.TryAddSingleton<ILoggerFactory, LoggerFactory>();
			serviceDescriptors.TryAddSingleton(typeof(ILogger<>), typeof(Logger<>));
		}
	}
}
