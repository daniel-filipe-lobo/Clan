namespace Wolf.Clan.BusinessLayer.Tests
{
	public class ClashOfClansApiTests
	{
		class Test
		{
			public int Id { get; set; }
			public required string Name { get; set; }
		}

		public HttpResponseMessage DefaultResponse<T>(T response)
		{
			return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = response != null ? new StringContent(JsonSerializer.Serialize(response)) : null };
		}


		private void ConfigureServices(IServiceCollection services, IConfiguration configuration, Func<HttpResponseMessage> response)
		{
			services.AddWolfClanBusinessLayer(configuration, 0, "");
			services.ReplaceWithMockHttpClient(response);
			services.Configure<ClashOfClansApiOptions>((options) => { options.BaseUrl = ""; options.AuthenticationToken = ""; });
		}

		[Fact]
		public async Task GetAsync_ReturnsCorrectObject()
		{
			//arrange
			var expected = new Test { Id = 1, Name = "{D69585D3-107A-4FA0-A711-F34309C978EB}" };
			Startup startup = new((services, configuration) => ConfigureServices(services, configuration, () => DefaultResponse(expected)));

			var clashOfClansApi = startup.GeneralStartup.Provider.GetRequiredService<IClashOfClansApi>();

			//act
			var result = await clashOfClansApi.GetAsync<Test>("");

			//assert
			expected.Should().BeEquivalentTo(result);
		}

		[Fact]
		public async Task GetAsync_ReturnsNull()
		{
			//arrange
			Startup startup = new((services, configuration) => ConfigureServices(services, configuration, () => DefaultResponse<object?>(null)));
			var clashOfClansApi = startup.GeneralStartup.Provider.GetRequiredService<IClashOfClansApi>();

			//act
			var result = await clashOfClansApi.GetAsync<Test>("");

			//assert
			result.Should().BeNull();
		}

		[Fact]
		public async Task GetAsync_ThrowsException()
		{
			//arrange
			Startup startup = new((services, configuration) => ConfigureServices(services, configuration, () => throw new Exception()));
			var clashOfClansApi = startup.GeneralStartup.Provider.GetRequiredService<IClashOfClansApi>();

			//act
			var result = async () => await clashOfClansApi.GetAsync<Test>("");

			//assert
			await result.Should().ThrowAsync<Exception>();
		}
	}
}
