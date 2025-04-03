using Wolf.Clan.BusinessLayer.Models.Api;

namespace Wolf.Clan.Console;

internal class MemberScore
{
	public MemberDetailResponse MemberDetail { get; set; }
	public List<Battle> Battles { get; private set; } = [];
	public int DonationPenalty { get; private set; }

	public MemberScore(MemberDetailResponse memberDetail)
	{
		MemberDetail = memberDetail;
		CalculateDonationPenalty();
	}

	private void CalculateDonationPenalty()
	{
		var donations = MemberDetail.Donations;
		var donationsReceived = MemberDetail.DonationsReceived;
		var difference = donations - donationsReceived;
		if (difference < 0)
		{
			DonationPenalty = Math.Abs(difference / 250);
		}
		else
		{
			DonationPenalty = 0;
		}
	}

	public int CalculateTotalScore()
	{
		var penalties = DonationPenalty + Battles.Sum(battle => battle.Penalty);
		var points = Battles.Sum(battle => battle.Stars);
		return points - penalties;
	}

	public int CalculateTotalScoreForMigration()
	{
		var points = Battles.Sum(battle => battle.Stars);
		return points - DonationPenalty;
	}
}

