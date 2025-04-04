namespace Wolf.Clash.BusinessLayer;

internal class ApiRequests
{
	private readonly JsonSerializerOptions options;

	public ApiRequests()
	{
		options = new JsonSerializerOptions();
		options.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());
	}

	public async Task<T?> GetAndDeserializeAsync<T>(string requestUri, string authenticationToke)
	{
		using var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToke);
		var response = await httpClient.GetAsync(requestUri);
		var content = response.Content;
		return JsonSerializer.Deserialize<T>(await content.ReadAsStreamAsync(), options);
	}
}
