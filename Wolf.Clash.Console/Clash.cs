namespace Wolf.Clash.Console;

internal class Clash : IClash
{
	private readonly JsonSerializerOptions options;
	private readonly string clanTag = "#PPY0VPRG";
	private readonly string clanTagEncoded;
	private readonly ILogger<IClash> logger;
	private readonly IPlayerRepository playerRepository;
	private readonly ILeagueRepository leagueRepository;
	private readonly IWarRepository warRepository;
	private readonly ILeagueWarRepository leagueWarRepository;
	private readonly IAttackRepository attackRepository;
	private readonly IWarPlayerRepository warPlayerRepository;
	private readonly IClashOfClansApi clashOfClansApi;

	public Clash(
		ILogger<IClash> logger,
		IPlayerRepository memberRepository,
		ILeagueRepository leagueRepository,
		IWarRepository warRepository,
		ILeagueWarRepository leagueWarRepository,
		IAttackRepository attackRepository,
		IWarPlayerRepository warPlayerRepository,
		IClashOfClansApi clashOfClansApi)
	{
		options = new JsonSerializerOptions();
		options.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());
		clanTagEncoded = WebUtility.UrlEncode(clanTag);
		this.playerRepository = memberRepository;
		this.leagueRepository = leagueRepository;
		this.warRepository = warRepository;
		this.leagueWarRepository = leagueWarRepository;
		this.attackRepository = attackRepository;
		this.warPlayerRepository = warPlayerRepository;
		this.logger = logger;
		this.clashOfClansApi = clashOfClansApi;
	}

	public async Task<IEnumerable<PlayerScore>> GetScoresAsync(AuthenticationTokeReference authenticationTokeReference)
	{
		try
		{
			string? authenticationToke = null;
			authenticationToke = authenticationTokeReference switch
			{
				AuthenticationTokeReference.Home => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImRmNmU3ZmYxLWYxZGUtNDVjMy05NjZiLTQ2YTUyZTg1NDBiMyIsImlhdCI6MTY5NDI5NzUxMywic3ViIjoiZGV2ZWxvcGVyLzRjZmEzY2FhLTQyY2EtNDg3YS00YzUxLTgzZGZkZWJiNWIzNyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE0OC42My42Mi44NyJdLCJ0eXBlIjoiY2xpZW50In1dfQ.uwFm1hAhzuHotf7SN0HO-92BNRym3qaNZYIcaeO2jolbNj0sgI4cSi4IgAN7vd-hXGmJhbe3GBNTrmXDthCgaQ",
				AuthenticationTokeReference.Office => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImY4YzJjOTg0LTA1NjItNDA5Mi1iMTIyLTBjZTBhNjIzNGIzMyIsImlhdCI6MTY3MDk1MzU0Mywic3ViIjoiZGV2ZWxvcGVyLzRjZmEzY2FhLTQyY2EtNDg3YS00YzUxLTgzZGZkZWJiNWIzNyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE5NS4yMy4xOTguMjM5Il0sInR5cGUiOiJjbGllbnQifV19.jd1Yv3NerkMRXF6IuhRJY5RRFarlYXSdv3h31WQ6zHQSxgFUtXq5vRRAElgBzyHW9B76mRFX9OYZhe1by7TAeA",
				AuthenticationTokeReference.Armacao => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjgyY2JiNDdjLWY2YmYtNDE3YS1iNzVjLWNjN2VkOTEyZWQ4ZCIsImlhdCI6MTY5MjcwNDQwMSwic3ViIjoiZGV2ZWxvcGVyLzRjZmEzY2FhLTQyY2EtNDg3YS00YzUxLTgzZGZkZWJiNWIzNyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjg1LjI0My4xNDUuMTI0Il0sInR5cGUiOiJjbGllbnQifV19.7sCrE3JdGZgRKwUzQEMJduo774VeyDjiEgZkn94k-vis-nCpT8rUVLKEba8rOpNa3sTi6PM2lJATMycIbgwGRQ",
				AuthenticationTokeReference.Vodafone => "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjZiYjBmMWFjLThmNjQtNGM3NC05MzM2LTFkYTk1ZjlmMDE5MSIsImlhdCI6MTcxNzk3MTY2Nywic3ViIjoiZGV2ZWxvcGVyLzRjZmEzY2FhLTQyY2EtNDg3YS00YzUxLTgzZGZkZWJiNWIzNyIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjg1LjI0MS41MC4yMTMiXSwidHlwZSI6ImNsaWVudCJ9XX0.sb78bo9W7Uw0ojLWNw8jG6LM8PCPb1szJbtxSNels-uZP34MUmhKEFasHLSYm3jnX41Q5HyNRAQBMlseCWUxLQ",
				_ => throw new Exception($"Unknown token reference: {authenticationTokeReference}"),
			};

			var clanDetail = await clashOfClansApi.GetClanAsync();

			if (clanDetail == null)
			{
				return [];
			}
			var memberScores = new Dictionary<string, MemberScore>();
			var memberDetails = clanDetail.MemberList.EmptyIfNull();
			await UpsertPlayerAsync(memberDetails);
			foreach (var memberDetail in memberDetails)
			{
				var memberScore = new MemberScore(memberDetail);
				memberScores.Add(memberDetail.Tag, memberScore);
			}

			var leagueGroup = await clashOfClansApi.GetLeagueGroupAsync();
			if (leagueGroup == null)
			{
				return [];
			}
			if (leagueGroup.Clans == null)
			{
				var modelWar = await GetAndDeserializeAsync<WarResponse>($"https://api.clashofclans.com/v1/clans/{clanTagEncoded}/currentwar", authenticationToke);
				await TryReadWarAsync(null, modelWar, memberScores, leagueGroup);
			}
			else
			{
				foreach (var round in leagueGroup.Rounds.EmptyIfNull())
				{
					foreach (var warTag in round.WarTags.EmptyIfNull())
					{
						var warTagEncoded = WebUtility.UrlEncode(warTag);
						var modelWar = await GetAndDeserializeAsync<WarResponse>($"https://api.clashofclans.com/v1/clanwarleagues/wars/{warTagEncoded}", authenticationToke);
						if (modelWar == null)
						{
							continue;
						}
						await TryReadWarAsync(warTag, modelWar, memberScores, leagueGroup);
					}
				}
			}

			var utcNow = DateTimeOffset.UtcNow;
			var beginDate = new DateTimeOffset(utcNow.Year, utcNow.Month, 1, 0, 0, 0, TimeSpan.Zero);
			var endDate = beginDate.AddMonths(1);
			var players = await playerRepository.SelectForActivityAsync(false);
			var wars = await warRepository.SelectAsync(beginDate, endDate);
			var warIds = wars.Select(war => war.Id).ToList();
			var leagueWars = await leagueWarRepository.SelectAsync(warIds);
			List<PlayerScore> playerScores = [];
			List<string> headers = [];

			foreach (var player in players)
			{
				var playerScore = new PlayerScore { Name = player.Name };
				playerScores.Add(playerScore);
				playerScore.Donations = player.Donations;
				playerScore.DonationsReceived = player.DonationsReceived;

				var playerId = player.Id;
				var attacks = await attackRepository.SelectAsync(playerId, warIds);
				var playerWars = await warPlayerRepository.SelectAsync(playerId, warIds);
				var warAttacks = (
					from war in wars
					join playerWar in playerWars
					on war.Id equals playerWar.WarId
					join attack in attacks
					on new { WarId = war.Id, PlayerId = playerWar.PlayerId } equals new { WarId = attack.WarId, PlayerId = attack.PlayerId } into leftAttacks
					from leftAttack in leftAttacks.DefaultIfEmpty()
					select new { Attack = leftAttack, War = war })
					.OrderBy(warAttack => warAttack.War.StartTime)
					.ToList();

				foreach (var warAttack in warAttacks)
				{
					var war = warAttack.War;
					var startTime = war.StartTime;
					var isLeague = leagueWars.Any(leagueWar => leagueWar.WarId == war.Id);
					var playerAttack = playerScore.PlayerAttacks.FirstOrDefault(playerAttack => playerAttack.StartTime == startTime);
					if (playerAttack == null)
					{
						playerAttack = new PlayerAttack { StartTime = startTime, IsLeague = isLeague };
						playerScore.PlayerAttacks.Add(playerAttack);
					}
					var attack = warAttack.Attack;
					if (attack != null)
					{
						playerAttack.Battles.Add(new Battle(attack.Order, war.StartTime, attack.Stars, attack.MapPosition, attack.EnemyMapPosition, isLeague ? BattleTypeReference.League : BattleTypeReference.War));
					}
					else
					{
						playerAttack.Battles.Add(null);
					}
				}
			}
			return playerScores;
		}
		catch (Exception exception)
		{
			throw ExceptionHandler<BusinessExceptionFactory>.Create(logger, exception,
				(nameof(authenticationTokeReference), authenticationTokeReference));
		}
	}

	public void ToExcel(string? fileName, IEnumerable<PlayerScore> playerScores)
	{
		if (fileName == null)
		{
			fileName = "clashResults";
		}
		fileName = Path.ChangeExtension(fileName, "xlsx");
		int rowCellIndex = 1;
		int columnCellIndex = 1;
		ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
		using (var excelPackage = new ExcelPackage())
		{
			var worksheet = excelPackage.Workbook.Worksheets.Add("Clan");
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Nome";
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Pontos";
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Doações";
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Doações Recebidas";
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Total Estrelas";
			worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "Total Penalização";

			var playerAttacks = playerScores
				.SelectMany(playerScore => playerScore.PlayerAttacks)
				.ToList();
			var startTimes = playerAttacks
				.Select(playerAttack => playerAttack.StartTime)
				.Distinct()
				.OrderBy(startTime => startTime)
				.ToList();

			Dictionary<DateTimeOffset, int> attackCount = [];
			int countField = 0;
			foreach (var startTime in startTimes)
			{
				var isLeague = playerAttacks.Any(playerAttack => playerAttack.StartTime == startTime && playerAttack.IsLeague);
				int numberOfAttacks = 1;
				var date = startTime.ToString("dd-MM-yyyy");
				var endColumnName = isLeague ? " Liga" : " 1º";
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Estrelas {date}{endColumnName}";
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Posição {++countField}";
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Inimigo {countField}";
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Penalização {countField}";
				if (!isLeague)
				{
					endColumnName = " 2º";
					worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Estrelas {date}{endColumnName}";
					worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Posição {++countField}";
					worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Inimigo {countField}";
					worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"Penalização {countField}";
					numberOfAttacks = 2;
				}
				attackCount.Add(startTime, numberOfAttacks);
			}
			foreach (var playerScore in playerScores.OrderByDescending(playerScore => playerScore.TotalScore))
			{
				++rowCellIndex;
				columnCellIndex = 1;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.Name;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.TotalScore;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.Donations;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.DonationsReceived;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.TotalStars;
				worksheet.Cells[rowCellIndex, columnCellIndex++].Value = playerScore.TotalPenalty;
				foreach (var startTime in startTimes)
				{
					var playerAttack = playerScore.PlayerAttacks.Where(playerAttack => playerAttack.StartTime == startTime).FirstOrDefault();
					var battles = playerAttack?.Battles;
					var count = attackCount[startTime];
					for (int index = 0; index < count; ++index)
					{
						var star = "";
						if (playerAttack != null)
						{
							var battle = battles?.ElementAtOrDefault(index);
							if (battle == null)
							{
								star = "Não atacou";
							}
							else
							{
								star = battle.Stars.ToString();
							}
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = star;
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"{battle?.MapPosition}";
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"{battle?.EnemyMapPosition}";
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = $"{playerScore.BattlePenalty(battle)}";
						}
						else
						{
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "";
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "";
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "";
							worksheet.Cells[rowCellIndex, columnCellIndex++].Value = "";
						}
					}
				}
			}
			excelPackage.SaveAs(fileName);
		}
	}

	private async Task UpsertPlayerAsync(IEnumerable<MemberDetailResponse> memberDetails)
	{
		var tags = memberDetails.Select(memberDetail => memberDetail.Tag).ToList();
		var players = await playerRepository.SelectAsync(tags);
		foreach (var memberDetail in memberDetails)
		{
			var player = players.FirstOrDefault(player => player.Tag == memberDetail.Tag);
			if (player == null)
			{
				player = new Player
				{
					Name = memberDetail.Name,
					Tag = memberDetail.Tag,
					Donations = memberDetail.Donations,
					DonationsReceived = memberDetail.DonationsReceived,
					HasLeft = false
				};
				await playerRepository.InsertAsync(player);
			}
			else if (
				player.Name != memberDetail.Name ||
				player.Donations != memberDetail.Donations ||
				player.DonationsReceived != memberDetail.DonationsReceived ||
				player.HasLeft != false)
			{
				player.Name = memberDetail.Name;
				player.Donations = memberDetail.Donations;
				player.DonationsReceived = memberDetail.DonationsReceived;
				player.HasLeft = false;
			}
		}
		await playerRepository.UpdateAsync(players);
		var playersThatHaveLeft = await playerRepository.SelectNotInAsync(tags, false);
		playersThatHaveLeft = playersThatHaveLeft.Select(player => { player.HasLeft = true; return player; }).ToList();
		await playerRepository.UpdateAsync(playersThatHaveLeft);
	}

	private async Task UpsertWarLeagueAsync(DataWar war, LeagueGroupResponse leagueGroup)
	{
		if (leagueGroup.Season == null)
		{
			return;
		}
		var league = await leagueRepository.SelectAsync(leagueGroup.Season);
		if (league == null)
		{
			league = new League { Season = leagueGroup.Season };
			await leagueRepository.InsertAsync(league);
		}
		var warLeague = await leagueWarRepository.SelectAsync(league.Id, war.Id);
		if (warLeague == null)
		{
			await leagueWarRepository.InsertAsync(new LeagueWar { LeagueId = league.Id, WarId = war.Id });
		}
	}

	private async Task<DataWar> WarUpsertAsync(string? warTag, WarResponse modelWar)
	{
		DataWar? war;
		if (!string.IsNullOrWhiteSpace(warTag))
		{
			war = await warRepository.SelectAsync(warTag);
		}
		else
		{
			if (modelWar.PreparationStartTime == null)
			{
				throw new Exception($"{nameof(modelWar.PreparationStartTime)} can't be null");
			}
			war = await warRepository.SelectAsync(warTag, modelWar.PreparationStartTime.Value);
		}
		if (war == null)
		{
			war = new DataWar
			{
				Tag = warTag,
				EndTime = modelWar.EndTime,
				PreparationStartTime = modelWar.PreparationStartTime,
				StartTime = modelWar.StartTime,
				State = modelWar.State,
				TeamSize = modelWar.TeamSize
			};
			await warRepository.InsertAsync(war);
		}
		else
		{
			if (
				war.EndTime != modelWar.EndTime ||
				war.PreparationStartTime != modelWar.PreparationStartTime ||
				war.StartTime != modelWar.StartTime ||
				war.State != modelWar.State ||
				war.TeamSize != modelWar.TeamSize)
			{
				war.EndTime = modelWar.EndTime;
				war.PreparationStartTime = modelWar.PreparationStartTime;
				war.StartTime = modelWar.StartTime;
				war.State = modelWar.State;
				war.TeamSize = modelWar.TeamSize;

				await warRepository.UpdateAsync(war);
			}
		}
		return war;
	}

	private async Task<T?> GetAndDeserializeAsync<T>(string requestUri, string authenticationToke)
	{
		using var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToke);
		var response = await httpClient.GetAsync(requestUri);
		var content = response.Content;
		return JsonSerializer.Deserialize<T>(await content.ReadAsStreamAsync(), options);
	}

	private async Task<bool> TryReadWarAsync(string? warTag, WarResponse? modelWar, Dictionary<string, MemberScore> memberScores, LeagueGroupResponse? leagueGroup)
	{
		if (modelWar == null || leagueGroup == null || modelWar.State == "notInWar" || modelWar.State == null)
		{
			return false;
		}
		var war = await WarUpsertAsync(warTag, modelWar);
		await UpsertWarLeagueAsync(war, leagueGroup);
		var contender = modelWar.Clan;
		var opponent = modelWar.Opponent;
		if (contender == null || opponent == null)
		{
			return false;
		}
		ClanResponse? clan;
		ClanResponse? enemyClan;
		if (contender.Tag == clanTag)
		{
			clan = contender;
			enemyClan = opponent;
		}
		else if (opponent.Tag == clanTag)
		{
			clan = opponent;
			enemyClan = contender;
		}
		else
		{
			return false;
		}
		if (enemyClan.Members == null)
		{
			return false;
		}
		foreach (var member in clan.Members.EmptyIfNull())
		{
			if (member.Tag == null || !memberScores.TryGetValue(member.Tag, out MemberScore? memberScore))
			{
				continue;
			}
			await UpsertWarPlayerAsync(war, member);
			var atacks = member.Attacks;
			if (atacks == null)
			{
				continue;
			}
			int index = 0;
			foreach (var atack in atacks)
			{
				if (atack == null)
				{
					continue;
				}
				var enemyMember = enemyClan.Members.First(member => member.Tag == atack.DefenderTag);
				await UpsertAttackAsync(atack, war, member, enemyMember);
				if (enemyMember.MapPosition != null && member.MapPosition != null && modelWar.PreparationStartTime != null)
				{
					memberScore.Battles.Add(new Battle(++index, modelWar.StartTime, atack.Stars, member.MapPosition.Value, enemyMember.MapPosition.Value, BattleTypeReference.League));
				}
			}
		}
		return true;
	}

	private async Task UpsertWarPlayerAsync(DataWar war, MemberResponse member)
	{
		var player = (await playerRepository.SelectAsync([member.Tag])).FirstOrDefault();
		if (player == null)
		{
			throw new Exception($"Player not found {nameof(member.Tag)} = {member.Tag}");
		}
		var warPlayer = (await warPlayerRepository.SelectAsync(player.Id, [war.Id])).SingleOrDefault();
		if (warPlayer == null)
		{
			await warPlayerRepository.InsertAsync(new WarPlayer { PlayerId = player.Id, WarId = war.Id });
		}
	}

	private async Task UpsertAttackAsync(AttackResponse modelAtack, DataWar war, MemberResponse member, MemberResponse enemyMember)
	{
		var player = (await playerRepository.SelectAsync([modelAtack.AttackerTag])).FirstOrDefault();
		if (player == null)
		{
			return;
		}
		var attack = await attackRepository.SelectAsync(player.Id, war.Id, modelAtack.Order);
		if (attack == null)
		{
			attack = new DataAttack
			{
				DefenderTag = modelAtack.DefenderTag,
				DestructionPercentage = modelAtack.DestructionPercentage,
				Duration = modelAtack.Duration,
				Order = modelAtack.Order,
				PlayerId = player.Id,
				Stars = modelAtack.Stars,
				WarId = war.Id,
				MapPosition = member.MapPosition ?? -1,
				EnemyMapPosition = enemyMember.MapPosition ?? -1
			};
			await attackRepository.InsertAsync(attack);
		}
		else
		{
			if (
				attack.DefenderTag != modelAtack.DefenderTag ||
				attack.DestructionPercentage != modelAtack.DestructionPercentage ||
				attack.Duration != modelAtack.Duration ||
				attack.Order != modelAtack.Order ||
				attack.Stars != modelAtack.Stars ||
				attack.MapPosition != member.MapPosition ||
				attack.EnemyMapPosition != enemyMember.MapPosition ||
				attack.WarId != war.Id)
			{
				attack.DefenderTag = modelAtack.DefenderTag;
				attack.DestructionPercentage = modelAtack.DestructionPercentage;
				attack.Duration = modelAtack.Duration;
				attack.Order = modelAtack.Order;
				attack.Stars = modelAtack.Stars;
				attack.MapPosition = member.MapPosition ?? -1;
				attack.EnemyMapPosition = enemyMember.MapPosition ?? -1;
				attack.WarId = war.Id;
				await attackRepository.UpdateAsync(attack);
			}
		}
	}
}

