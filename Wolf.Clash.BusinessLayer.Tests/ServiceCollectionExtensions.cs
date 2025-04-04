namespace Wolf.Clash.BusinessLayer.Tests
{
	public static class ServiceCollectionExtensions
	{
		public static HttpResponseMessage DefaultResponse<T>(T response)
		{
			return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = response != null ? new StringContent(JsonSerializer.Serialize(response)) : null };
		}

		public static void ReplaceWithMockHttpClient(this IServiceCollection serviceDescriptors, Func<HttpResponseMessage> response)
		{
			serviceDescriptors.Replace(ServiceDescriptor.Transient((serviceProvider) =>
			{
				var httpClientWrapperFactoryMock = new Mock<IHttpClientWrapperFactory>();
				var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
				httpClientWrapperMock.SetupGet(httpClientWrapper => httpClientWrapper.DefaultRequestHeaders).Returns(Mock.Of<IHttpRequestHeadersWraper>());
				httpClientWrapperFactoryMock.Setup(httpClientWrapperFactory => httpClientWrapperFactory.Create()).Returns(httpClientWrapperMock.Object);
				httpClientWrapperMock.Setup(httpClientWrapper => httpClientWrapper.GetAsync(It.IsAny<string>())).ReturnsAsync(response);
				return httpClientWrapperFactoryMock.Object;
			}));
		}
	}
}
