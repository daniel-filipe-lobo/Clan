namespace Wolf.Clash.BusinessLayer.Tests
{
	internal class Startup
	{
		public GeneralStartup GeneralStartup { get; private set; }

		public Startup(Action<IServiceCollection, IConfiguration>? configureServices)
		{
			var hostBuilder = Host.CreateDefaultBuilder();
			GeneralStartup = new GeneralStartup(hostBuilder, () => hostBuilder.Build().Services, configureServices, isAddJsonFileOptional: true);
		}
	}
}
