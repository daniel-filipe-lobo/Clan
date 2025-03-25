namespace Wolf.Clan.Console.Models;

public record ClanDetailResponse
{
	public string? tag { get; set; }
	public string? name { get; set; }
	public string? type { get; set; }
	public string? description { get; set; }
	public LocationResponse? location { get; set; }
	public BadgeUrlsResponse? badgeUrls { get; set; }
	public int? clanLevel { get; set; }
	public int? clanPoints { get; set; }
	public int? clanVersusPoints { get; set; }
	public int? requiredTrophies { get; set; }
	public string? warFrequency { get; set; }
	public int? warWinStreak { get; set; }
	public int? warWins { get; set; }
	public int? warTies { get; set; }
	public int? warLosses { get; set; }
	public bool? isWarLogPublic { get; set; }
	public WarLeagueResponse? warLeague { get; set; }
	public int? members { get; set; }
	public IEnumerable<MemberDetailResponse>? memberList { get; set; }
	public IEnumerable<LabelResponse>? labels { get; set; }
	public int? requiredVersusTrophies { get; set; }
	public int? requiredTownhallLevel { get; set; }
	public ChatLanguageResponse? chatLanguage { get; set; }
}
