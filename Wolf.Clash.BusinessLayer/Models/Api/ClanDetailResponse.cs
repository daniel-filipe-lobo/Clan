namespace Wolf.Clash.BusinessLayer.Models.Api;

public record ClanDetailResponse
{
	[JsonPropertyName("tag")]
	public string? Tag { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("type")]
	public string? Type { get; set; }
	[JsonPropertyName("description")]
	public string? Description { get; set; }
	[JsonPropertyName("location")]
	public LocationResponse? Location { get; set; }
	[JsonPropertyName("badgeUrls")]
	public BadgeUrlsResponse? BadgeUrls { get; set; }
	[JsonPropertyName("clanLevel")]
	public int? ClanLevel { get; set; }
	[JsonPropertyName("clanPoints")]
	public int? ClanPoints { get; set; }
	[JsonPropertyName("clanVersusPoints")]
	public int? ClanVersusPoints { get; set; }
	[JsonPropertyName("requiredTrophies")]
	public int? RequiredTrophies { get; set; }
	[JsonPropertyName("warFrequency")]
	public string? WarFrequency { get; set; }
	[JsonPropertyName("warWinStreak")]
	public int? WarWinStreak { get; set; }
	[JsonPropertyName("warWins")]
	public int? WarWins { get; set; }
	[JsonPropertyName("warTies")]
	public int? WarTies { get; set; }
	[JsonPropertyName("warLosses")]
	public int? WarLosses { get; set; }
	[JsonPropertyName("isWarLogPublic")]
	public bool? IsWarLogPublic { get; set; }
	[JsonPropertyName("warLeague")]
	public WarLeagueResponse? WarLeague { get; set; }
	[JsonPropertyName("members")]
	public int? Members { get; set; }
	[JsonPropertyName("memberList")]
	public IEnumerable<MemberDetailResponse>? MemberList { get; set; }
	[JsonPropertyName("labels")]
	public IEnumerable<LabelResponse>? Labels { get; set; }
	[JsonPropertyName("requiredVersusTrophies")]
	public int? RequiredVersusTrophies { get; set; }
	[JsonPropertyName("requiredTownhallLevel")]
	public int? RequiredTownhallLevel { get; set; }
	[JsonPropertyName("chatLanguage")]
	public ChatLanguageResponse? ChatLanguage { get; set; }
}
