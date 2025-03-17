namespace Wolf.Clan.DataLayer
{
	internal class Context : DbContext
	{
		public virtual DbSet<Player> PlayerSet { get; set; } = null!;
		public virtual DbSet<League> LeagueSet { get; set; } = null!;
		public virtual DbSet<LeagueWar> LeagueWarSet { get; set; } = null!;
		public virtual DbSet<War> WarSet { get; set; } = null!;
		public virtual DbSet<Attack> AttackSet { get; set; } = null!;
		public virtual DbSet<WarPlayer> WarPlayerSet { get; set; } = null!;
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
