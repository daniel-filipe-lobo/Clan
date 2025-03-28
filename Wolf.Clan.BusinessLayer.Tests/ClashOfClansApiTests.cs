using System.Net.Http.Headers;

namespace Wolf.Clan.BusinessLayer.Tests
{
	public class ClashOfClansApiTests
	{
		[Fact]
		public void Test1()
		{
			//arrange
			var services = new ServiceCollection();
			services.TryAddSingleton<ILoggerFactory, LoggerFactory>();
			services.TryAddSingleton(typeof(ILogger<>), typeof(Logger<>));
			services.Configure<ClashOfClansApiOptions>((options) => new ClashOfClansApiOptions { AuthenticationToken = "", BaseUrl = "" } );
			services.AddWolfClanBusinessLayer(0, "");
			services.Replace(ServiceDescriptor.Transient((serviceProvider) =>
			{
				var httpClientWrapperFactoryMock = new Mock<IHttpClientWrapperFactory>();
				var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
				httpClientWrapperMock.SetupGet(httpClientWrapper => httpClientWrapper.DefaultRequestHeaders).Returns(Mock.Of<IHttpRequestHeadersWraper>());
				httpClientWrapperFactoryMock.Setup(httpClientWrapperFactory => httpClientWrapperFactory.Create()).Returns(httpClientWrapperMock.Object);
				httpClientWrapperMock.Setup(httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage());
				return httpClientWrapperFactoryMock.Object;
			}));
			var provider = services.BuildServiceProvider();
			var clashOfClansApi = provider.GetRequiredService<IClashOfClansApi>();

			clashOfClansApi.GetAndDeserializeAsync<int>("");
		}
	}
}
