﻿namespace Wolf.Clan.Console;

public class PlayerAttack
{
	public DateTimeOffset StartTime { get; set; }
	public bool IsLeague { get; set; } = false;
	public List<Battle?> Battles { get; set; } = [];
}

