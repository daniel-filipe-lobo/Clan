namespace Wolf.Clan.webApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClanController : ControllerBase
	{
		private readonly ILogger<ClanController> _logger;
		private readonly Lazy<IClashOfClansApi> clashOfClansApi;
		private static readonly string[] Summaries =
		[
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorch   ing"
		];

		public ClanController(
			ILogger<ClanController> logger,
			Lazy<IClashOfClansApi> clashOfClansApi)
		{
			_logger = logger;
			this.clashOfClansApi = clashOfClansApi;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> GetAsync()
		{
			var clanDetail = await clashOfClansApi.Value.GetClanAsync();

			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
