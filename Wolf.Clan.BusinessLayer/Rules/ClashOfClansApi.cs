namespace Wolf.Clan.BusinessLayer.Rules
{
	internal class ClashOfClansApi : IClashOfClansApi
	{
		private readonly JsonSerializerOptions jsonSerializerOptions;
		private readonly ILogger<IClashOfClansApi> logger;
		private readonly IOptions<ClashOfClansApiOptions> options;
		private readonly IHttpClientWrapperFactory httpClientWrapperFactory;

		public ClashOfClansApi(
			ILogger<IClashOfClansApi> logger,
			IOptions<ClashOfClansApiOptions> options,
			IHttpClientWrapperFactory httpClientWrapperFactory)
		{
			this.logger = logger;
			this.options = options;
			this.httpClientWrapperFactory = httpClientWrapperFactory;
			jsonSerializerOptions = new JsonSerializerOptions();
			jsonSerializerOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());
		}

		public async Task<T?> GetAsync<T>(string uriSegment)
		{
			try
			{
				using var httpClient = httpClientWrapperFactory.Create();
				var authenticationToke = options.Value.AuthenticationToken;
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToke);
				var requestUri = UriUtility.Combine(new(options.Value.BaseUrl), uriSegment);
				var response = await httpClient.GetAsync(requestUri);
				var content = response.Content;
				using var stream = await content.ReadAsStreamAsync();
				if (stream.ReadByte() == -1)
				{
					return default;
				}
				stream.Position = 0;
				return JsonSerializer.Deserialize<T>(stream, jsonSerializerOptions);
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(uriSegment), uriSegment));
			}
		}

		public async Task<ClanDetailResponse?> GetClanAsync(string clanTag)
		{
			try
			{
				return await GetAsync<ClanDetailResponse>(HttpUtility.UrlEncode(clanTag));
			}
			catch (Exception exception)
			{
				throw ExceptionHandler.Create(logger, exception,
					(nameof(clanTag), clanTag));
			}
		}
	}
}
