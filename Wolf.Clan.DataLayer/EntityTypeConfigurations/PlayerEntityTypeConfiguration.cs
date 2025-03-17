namespace Wolf.Clan.DataLayer
{
	internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
	{
		public void Configure(EntityTypeBuilder<Player> builder)
		{
			builder.ToTable(nameof(Player));
		}
	}
}
