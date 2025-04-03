namespace Wolf.Clan.BusinessLayer.Models.Api;

public record ChatLanguageResponse
{
	[JsonPropertyName("id")]
	public int? Id { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("languageCode")]
	public string? LanguageCode { get; set; }
}
