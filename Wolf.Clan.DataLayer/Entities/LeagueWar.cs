namespace Wolf.Clan.DataLayer.Entities
{
	[EntityTypeConfiguration(typeof(LeagueWarEntityTypeConfiguration))]
	public record LeagueWar
	{
		public int LeagueId { get; set; }
		public int WarId { get; set; }
	}
}
