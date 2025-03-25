namespace Wolf.Clan.Console.Models;

public record WarResponse
{
	public string? state { get; set; }
	public int teamSize { get; set; }
	public DateTimeOffset? preparationStartTime { get; set; }
	public DateTimeOffset startTime { get; set; }
	public DateTimeOffset? endTime { get; set; }
	public ClanResponse? clan { get; set; }
	public ClanResponse? opponent { get; set; }
}
