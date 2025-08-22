namespace Wolf.Clash.Console
{
	internal class ClashInjection
	{
		private readonly ILogger<IClash> logger;
		private readonly IPlayerRepository playerRepository;
		private readonly ILeagueRepository leagueRepository;
		private readonly IWarRepository warRepository;
		private readonly ILeagueWarRepository leagueWarRepository;
		private readonly IAttackRepository attackRepository;
		private readonly IWarPlayerRepository warPlayerRepository;
		private readonly IClashOfClansApi clashOfClansApi;
	}
}


