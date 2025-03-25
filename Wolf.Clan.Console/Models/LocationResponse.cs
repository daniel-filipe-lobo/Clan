namespace Wolf.Clan.Console.Models;

public record LocationResponse
{
	public int? id { get; set; }
	public string? name { get; set; }
	public bool? isCountry { get; set; }
	public string? countryCode { get; set; }
}
