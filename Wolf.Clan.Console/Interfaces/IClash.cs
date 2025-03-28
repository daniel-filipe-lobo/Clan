namespace Wolf.Clan.Console;

public interface IClash
{
	Task<IEnumerable<PlayerScore>> GetScoresAsync(AuthenticationTokeReference authenticationToke);
	void ToExcel(string? fileName, IEnumerable<PlayerScore> playerScores);
}
