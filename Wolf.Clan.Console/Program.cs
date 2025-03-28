using Wolf.Clan.Console;

var startup = new Startup();
var clash = startup.Provider.GetService<IClash>();
if (clash == null)
{
	Console.WriteLine("Null parser");
	return;
}
if (args.Length < 2)
{
	Console.WriteLine("Usage: <fileName=example.csv> <key=home|office>");
	return;
}
var fileNameArgument = args[0].Split("=");
if (string.Compare(fileNameArgument[0].Trim(), "fileName", true) != 0 || fileNameArgument.Length != 2)
{
	Console.WriteLine("<fileName=example.csv> is missing");
	return;
}
string? fileName = fileNameArgument[1]?.Trim();
if (string.IsNullOrEmpty(fileName))
{
	Console.WriteLine("fileName can not be null");
	return;
}
var keyArgument = args[1].Split("=");
string? key;
;
if (string.Compare(keyArgument[0].Trim(), "key", true) != 0 || fileNameArgument.Length != 2)
{
	Console.WriteLine("<key=home|office> is missing");
	return;
}
key = keyArgument[1]?.Trim();
AuthenticationTokeReference authenticationTokeReference;
if(!Enum.TryParse(key, true, out authenticationTokeReference))
{
	Console.WriteLine("key must be: home|office");
	return;
}
var playerScores = await clash.GetScoresAsync(authenticationTokeReference);
clash.ToExcel(fileName, playerScores);
Console.WriteLine("Finished.");
