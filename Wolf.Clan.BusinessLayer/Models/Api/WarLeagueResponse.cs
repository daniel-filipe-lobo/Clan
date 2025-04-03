namespace Wolf.Clan.BusinessLayer.Models.Api;

public record WarLeagueResponse
{
	[JsonPropertyName("id")]
	public int? Id { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
