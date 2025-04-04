namespace Wolf.Clash.BusinessLayer;

public class WarLogRules
{
	public async Task ReadAsync(string clanTagEncoded, string authenticationToke)
	{
		var apiRequests = new ApiRequests();
		var warLogs = await apiRequests.GetAndDeserializeAsync<ClanWarLogResponse>($"https://api.clashofclans.com/v1/clans/{clanTagEncoded}/warlog", authenticationToke);
	}
}
