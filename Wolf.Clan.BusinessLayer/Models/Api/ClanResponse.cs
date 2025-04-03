namespace Wolf.Clan.BusinessLayer.Models.Api;

public record ClanResponse
{
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
	[JsonPropertyName("destructionPercentage")]
	public float? DestructionPercentage { get; set; }
	[JsonPropertyName("members")]
	public IEnumerable<MemberResponse>? Members { get; set; }
}