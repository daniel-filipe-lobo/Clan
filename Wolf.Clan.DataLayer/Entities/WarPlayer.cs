﻿namespace Wolf.Clan.DataLayer.Entities
{
	[EntityTypeConfiguration(typeof(WarPlayerEntityTypeConfiguration))]
	public record WarPlayer
	{
		public int WarId { get; set; }
		public int PlayerId { get; set; }
	}
}
