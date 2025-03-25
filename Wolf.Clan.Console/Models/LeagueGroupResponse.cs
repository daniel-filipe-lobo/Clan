namespace Wolf.Clan.Console.Models;

public record LeagueGroupResponse
{
	public string? state { get; set; }
	public string season { get; set; } = null!;
	public IEnumerable<ClanResponse>? clans { get; set; }
	public IEnumerable<RoundResponse>? rounds { get; set; }
}
