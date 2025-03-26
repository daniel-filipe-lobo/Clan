namespace Wolf.Clan.Console.Models;

public record IconUrlsResponse
{
	[JsonPropertyName("small")]
	public string? Small { get; set; }
	[JsonPropertyName("tiny")]
	public string? Tiny { get; set; }
	[JsonPropertyName("medium")]
	public string? Medium { get; set; }
}
