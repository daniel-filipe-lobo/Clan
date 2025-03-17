namespace Wolf.Clan.DataLayer.Entities
{
	[EntityTypeConfiguration(typeof(LeagueEntityTypeConfiguration))]
	public record League
	{
		public int Id { get; set; }
		public string Season { get; set; } = null!;
	}
}
