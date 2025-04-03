namespace Wolf.Clan.BusinessLayer.Models.Api;

public record LabelResponse
{
	[JsonPropertyName("id")]
	public int? Id { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("iconUrls")]
	public IconUrlsResponse? IconUrls { get; set; }
}
