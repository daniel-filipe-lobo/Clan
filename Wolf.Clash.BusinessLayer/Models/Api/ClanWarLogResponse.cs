namespace Wolf.Clash.BusinessLayer.Models.Api;

internal class ClanWarLogResponse
{
	[JsonPropertyName("items")]
	public IEnumerable<ClanWarLogEntryResponse>? Items { get; set; }
}
