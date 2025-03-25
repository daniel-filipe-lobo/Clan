namespace Wolf.Clan.Console.Models;

public record ChatLanguageResponse
{
	public int? id { get; set; }
	public string? name { get; set; }
	public string? languageCode { get; set; }
}
