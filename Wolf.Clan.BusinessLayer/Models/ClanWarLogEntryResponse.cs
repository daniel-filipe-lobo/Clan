namespace Wolf.Clan.BusinessLayer.Models
{
	public class ClanWarLogEntryResponse
	{
		[JsonPropertyName("clan")]
		public WarClanResponse? Clan { get; set; }
		[JsonPropertyName("teamSize")]
		public int? TeamSize { get; set; }
		[JsonPropertyName("attacksPerMember")]
		public int? AttacksPerMember { get; set; }
		[JsonPropertyName("battleModifier")]
		public string? BattleModifier { get; set; }
		[JsonPropertyName("opponent")]
		public WarClanResponse? Opponent { get; set; }
		[JsonPropertyName("endTime")]
		public DateTimeOffset? EndTime { get; set; }
		[JsonPropertyName("result")]
		public string? Result { get; set; }
	}
}
