namespace Wolf.Clash.DataLayer
{
	internal class LeagueEntityTypeConfiguration : IEntityTypeConfiguration<League>
	{
		public void Configure(EntityTypeBuilder<League> builder)
		{
			builder.ToTable(nameof(League));
		}
	}
}
