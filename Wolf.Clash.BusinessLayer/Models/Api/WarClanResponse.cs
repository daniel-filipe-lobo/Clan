namespace Wolf.Clash.BusinessLayer.Models.Api;

public class WarClanResponse
{
	[JsonPropertyName("destructionPercentage")]
	public float DestructionPercentage { get; set; }
	[JsonPropertyName("tag")]
	public string? Tag { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("badgeUrls")]
	public BadgeUrlsResponse? BadgeUrls { get; set; }
	[JsonPropertyName("clanLevel")]
	public int? ClanLevel { get; set; }
	[JsonPropertyName("attacks")]
	public int? Attacks { get; set; }
	[JsonPropertyName("stars")]
	public int? Stars { get; set; }
	[JsonPropertyName("expEarned")]
	public int? ExpEarned { get; set; }
	[JsonPropertyName("members")]
	public IEnumerable<ClanWarMemberResponse>? Members { get; set; }
}
