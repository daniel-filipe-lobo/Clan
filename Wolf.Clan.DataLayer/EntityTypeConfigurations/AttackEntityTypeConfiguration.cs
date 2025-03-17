namespace Wolf.Clan.DataLayer
{
	internal class AttackEntityTypeConfiguration : IEntityTypeConfiguration<Attack>
	{
		public void Configure(EntityTypeBuilder<Attack> builder)
		{
			builder.ToTable(nameof(Attack));
		}
	}
}
