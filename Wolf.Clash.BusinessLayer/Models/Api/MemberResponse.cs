namespace Wolf.Clash.BusinessLayer.Models.Api;

public record MemberResponse
{
	[JsonPropertyName("tag")]
	public string Tag { get; set; } = null!;
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("townhallLevel")]
	public int? TownhallLevel { get; set; }
	[JsonPropertyName("mapPosition")]
	public int? MapPosition { get; set; }
	[JsonPropertyName("attacks")]
	public IEnumerable<AttackResponse>? Attacks { get; set; }
}
