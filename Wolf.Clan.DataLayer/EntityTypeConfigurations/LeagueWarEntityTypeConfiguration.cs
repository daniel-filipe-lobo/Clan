namespace Wolf.Clan.DataLayer
{
	internal class LeagueWarEntityTypeConfiguration : IEntityTypeConfiguration<LeagueWar>
	{
		public void Configure(EntityTypeBuilder<LeagueWar> builder)
		{
			builder.ToTable(nameof(LeagueWar));
			builder.HasKey(entity => new { entity.LeagueId, entity.WarId });
		}
	}
}
