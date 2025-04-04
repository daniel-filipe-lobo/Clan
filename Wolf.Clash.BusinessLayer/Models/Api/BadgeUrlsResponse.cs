namespace Wolf.Clash.BusinessLayer.Models.Api;

public record BadgeUrlsResponse
{
	[JsonPropertyName("small")]
	public string? Small { get; set; }
	[JsonPropertyName("large")]
	public string? Large { get; set; }
	[JsonPropertyName("medium")]
	public string? Medium { get; set; }
}
