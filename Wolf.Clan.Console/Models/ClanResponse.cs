namespace Wolf.Clan.Console.Models;

public record ClanResponse
{
	public string? tag { get; set; }
	public string? name { get; set; }
	public BadgeUrlsResponse? badgeUrls { get; set; }
	public int? clanLevel { get; set; }
	public int? attacks { get; set; }
	public int? stars { get; set; }
	public float? destructionPercentage { get; set; }
	public IEnumerable<MemberResponse>? members { get; set; }
}