namespace Wolf.Clan.DataLayer
{
	internal class WarPlayerEntityTypeConfiguration : IEntityTypeConfiguration<WarPlayer>
	{
		public void Configure(EntityTypeBuilder<WarPlayer> builder)
		{
			builder.ToTable(nameof(WarPlayer));
			builder.HasKey(entity => new { entity.WarId, entity.PlayerId });
		}
	}
}
