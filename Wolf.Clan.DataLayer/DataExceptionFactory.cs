namespace Wolf.Clan.DataLayer
{
	internal class DataExceptionFactory : ExceptionFactory
	{
		public override Exception Create(string? message, Exception innerException)
		{
			return new Exception(message, innerException);
		}
	}
}
