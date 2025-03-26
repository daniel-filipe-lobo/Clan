namespace Wolf.Clan.Console.Models;

public record LeagueGroupResponse
{
	[JsonPropertyName("state")]
	public string? State { get; set; }
	[JsonPropertyName("season")]
	public string Season { get; set; } = null!;
	[JsonPropertyName("clans")]
	public IEnumerable<ClanResponse>? Clans { get; set; }
	[JsonPropertyName("rounds")]
	public IEnumerable<RoundResponse>? Rounds { get; set; }
}
