namespace Wolf.Clash.DataLayer
{
	internal class WarEntityTypeConfiguration : IEntityTypeConfiguration<War>
	{
		public void Configure(EntityTypeBuilder<War> builder)
		{
			builder.ToTable(nameof(War));
		}
	}
}
