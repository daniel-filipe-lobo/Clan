namespace Wolf.Clash.webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClanController : ControllerBase
{
	private readonly ILogger<ClanController> logger;
	private readonly Lazy<IClashOfClansApi> clashOfClansApi;

	public ClanController(
		ILogger<ClanController> logger,
		Lazy<IClashOfClansApi> clashOfClansApi)
	{
		this.logger = logger;
		this.clashOfClansApi = clashOfClansApi;
	}

	[HttpGet]
	public async Task<IActionResult> GetAsync()
	{
		try
		{
			var clanDetail = await clashOfClansApi.Value.GetClanAsync();
			return Ok(new ClanResponse { Name = clanDetail?.Name ?? "N/A" });
		}
		catch (Exception exception)
		{
			logger.LogError(exception, null);
			return NotFound();
		}
	}
}
