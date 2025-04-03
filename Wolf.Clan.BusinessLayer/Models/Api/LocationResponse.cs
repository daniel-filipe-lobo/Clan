namespace Wolf.Clan.BusinessLayer.Models.Api;

public record LocationResponse
{
	[JsonPropertyName("id")]
	public int? Id { get; set; }
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	[JsonPropertyName("isCountry")]
	public bool? IsCountry { get; set; }
	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }
}
