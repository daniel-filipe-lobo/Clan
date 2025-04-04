namespace Wolf.Clash.BusinessLayer.Models.Api;

public class ClanWarAttackResponse
{
	[JsonPropertyName("order")]
	public int? Order { get; set; }
	[JsonPropertyName("attackerTag")]
	public string? AttackerTag { get; set; }
	[JsonPropertyName("defenderTag")]
	public string? DefenderTag { get; set; }
	[JsonPropertyName("stars")]
	public int? Stars { get; set; }
	[JsonPropertyName("destructionPercentage")]
	public int? DestructionPercentage { get; set; }
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }
}
