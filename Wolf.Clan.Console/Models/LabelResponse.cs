namespace Wolf.Clan.Console.Models;

public record LabelResponse
{
	public int? id { get; set; }
	public string? name { get; set; }
	public IconUrlsResponse? iconUrls { get; set; }
}
