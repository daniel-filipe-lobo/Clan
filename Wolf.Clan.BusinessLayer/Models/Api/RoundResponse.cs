namespace Wolf.Clan.BusinessLayer.Models.Api;

public record RoundResponse
{
	[JsonPropertyName("warTags")]
	public IEnumerable<string>? WarTags { get; set; }
}
