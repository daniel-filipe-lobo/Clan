namespace Wolf.Clash.BusinessLayer
{
	internal class ExceptionRulesFactory : ExceptionFactory
	{
		public override Exception Create(string? message, Exception innerException)
		{
			return new ExceptionRules(message, innerException);
		}
	}
}
