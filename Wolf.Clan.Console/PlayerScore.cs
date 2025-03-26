namespace Wolf.Clan.Console;

internal class PlayerScore
{
	private int totalScore = 0;
	private int totalStars = 0;
	private int totalPenalty = 0;
	public string Name { get; set; } = null!;
	public List<PlayerAttack> PlayerAttacks { get; set; } = [];
	public int TotalScore { get { GetTotalScore(); return totalScore; } }
	public int Donations { get; set; } = 0;
	public int DonationsReceived { get; set; } = 0;
	public int TotalStars { get { GetTotalScore(); return totalStars; } }
	public int TotalPenalty { get { GetTotalScore(); return totalPenalty; } }

	public void GetTotalScore()
	{
		totalScore = 0;
		totalStars = 0;
		totalPenalty = 0;
		foreach (var playerAttack in PlayerAttacks)
		{
			foreach (var battle in playerAttack.Battles)
			{
				totalPenalty += BattlePenalty(battle);
				totalStars += BattleStars(battle);
			}
		}
		if (Donations - DonationsReceived < 0)
		{
			totalPenalty += (DonationsReceived - Donations) / 250;
		}
		totalScore = totalStars - totalPenalty;
	}

	public int BattlePenalty(Battle? battle)
	{
		return battle == null ? 1 : battle.Penalty;
	}

	public int BattleStars(Battle? battle)
	{
		return battle == null ? 0 : battle.Stars;
	}
}

