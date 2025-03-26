namespace Wolf.Clan.Console.Models;

public record WarResponse
{
	[JsonPropertyName("state")]
	public string? State { get; set; }
	[JsonPropertyName("teamSize")]
	public int TeamSize { get; set; }
	[JsonPropertyName("preparationStartTime")]
	public DateTimeOffset? PreparationStartTime { get; set; }
	[JsonPropertyName("startTime")]
	public DateTimeOffset StartTime { get; set; }
	[JsonPropertyName("endTime")]
	public DateTimeOffset? EndTime { get; set; }
	[JsonPropertyName("clan")]
	public ClanResponse? Clan { get; set; }
	[JsonPropertyName("opponent")]
	public ClanResponse? Opponent { get; set; }
}
