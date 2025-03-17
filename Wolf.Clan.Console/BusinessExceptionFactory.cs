namespace Wolf.Clan.Console
{
	internal class BusinessExceptionFactory : ExceptionFactory
	{
		public override Exception Create(string? message, Exception innerException)
		{
			return new Exception(message, innerException);
		}
	}
}
