namespace Wolf.Clan.Console.Models;

public record MemberResponse
{
	public string tag { get; set; } = null!;
	public string? name { get; set; }
	public int? townhallLevel { get; set; }
	public int? mapPosition { get; set; }
	public IEnumerable<AttackResponse>? attacks { get; set; }
}
