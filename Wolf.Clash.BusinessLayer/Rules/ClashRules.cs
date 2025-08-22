namespace Wolf.Clash.BusinessLayer.Rules;

internal class ClashRules : IClashRules
{
	private readonly ILogger<IClashRules> logger;

	public ClashRules(
		ILogger<IClashRules> logger)
	{
		this.logger = logger;
	}

	public async Task<Clan> GetAsync()
	{
		try
		{
			throw new NotImplementedException("GetAsync method is not implemented yet.");
		}
		catch (Exception exception)
		{
			throw ExceptionHandler.Create(logger, exception);
		}
	}
}