namespace Wolf.Clash.BusinessLayer
{
	public class ExceptionRules : Exception
	{
		public ExceptionRules()
		{
		}

		public ExceptionRules(string? message) : base(message)
		{
		}

		public ExceptionRules(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
