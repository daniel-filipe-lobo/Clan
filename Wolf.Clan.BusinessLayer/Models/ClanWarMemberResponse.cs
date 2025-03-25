namespace Wolf.Clan.BusinessLayer.Models
{
	public class ClanWarMemberResponse
	{
		[JsonPropertyName("tag")]
		public string? Tag { get; set; }
		[JsonPropertyName("name")]
		public string? Name { get; set; }
		[JsonPropertyName("mapPosition")]
		public int? MapPosition { get; set; }
		[JsonPropertyName("townhallLevel")]
		public int? TownhallLevel { get; set; }
		[JsonPropertyName("opponentAttacks")]
		public int? OpponentAttacks { get; set; }
		[JsonPropertyName("bestOpponentAttack")]
		public ClanWarAttackResponse? BestOpponentAttack { get; set; }
		[JsonPropertyName("attacks")]
		public IEnumerable<ClanWarAttackResponse>? Attacks { get; set; }
	}
}
