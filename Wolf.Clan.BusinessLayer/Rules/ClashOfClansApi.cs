namespace Wolf.Clan.BusinessLayer.Rules
{
	internal class ClashOfClansApi : IClashOfClansApi
	{
		private readonly JsonSerializerOptions jsonSerializerOptions;
		private readonly string url = $"https://api.clashofclans.com/v1/clans/";
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

		public async Task<T?> GetAndDeserializeAsync<T>(string uriSegment)
		{
			using var httpClient = httpClientWrapperFactory.Create();
			var authenticationToke = options.Value.AuthenticationToken;
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToke);
			string requestUri = UriUtility.Combine(options.Value.BaseUrl, uriSegment);
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
	}
}
