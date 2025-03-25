namespace Wolf.Clan.BusinessLayer.Models;

internal class ClanWarLogResponse
{
	[JsonPropertyName("items")]
	public IEnumerable<ClanWarLogEntryResponse>? Items { get; set; }
}
