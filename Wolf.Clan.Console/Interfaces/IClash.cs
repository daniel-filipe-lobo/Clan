namespace ConsoleClan
{
	public interface IClash
	{
		Task ProcessAsync(AuthenticationTokeReference authenticationToke, string? fileName);
	}
}
