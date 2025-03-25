namespace Wolf.Clan.Console;

public interface IClash
{
	Task ProcessAsync(AuthenticationTokeReference authenticationToke, string? fileName);
}
