namespace Wolf.Clan.Console.Models;

public record RoundResponse
{
	[JsonPropertyName("warTags")]
	public IEnumerable<string>? WarTags { get; set; }
}
