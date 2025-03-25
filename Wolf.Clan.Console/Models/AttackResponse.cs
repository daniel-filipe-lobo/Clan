namespace Wolf.Clan.Console.Models;

public record AttackResponse
{
	[JsonPropertyName("attackerTag")]
	public string AttackerTag { get; set; } = null!;
	[JsonPropertyName("defenderTag")]
	public string DefenderTag { get; set; } = null!;
	[JsonPropertyName("stars")]
	public int Stars { get; set; }
	[JsonPropertyName("destructionPercentage")]
	public int DestructionPercentage { get; set; }
	[JsonPropertyName("order")]
	public int Order { get; set; }
	[JsonPropertyName("duration")]
	public int Duration { get; set; }
}