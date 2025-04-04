namespace Wolf.Clash.BusinessLayer.Models.Api;

public class LeagueResponse
{
	[JsonPropertyName("id")]
	public int Id { get; set; }
	[JsonPropertyName("iconUrls")]
	public IconUrlsResponse? IconUrls { get; set; }
}
