namespace Wolf.Clan.BusinessLayer
{
	internal class UriUtility
	{
		public static string Combine(string baseUri, string uriSegment)
		{
			if (baseUri.EndsWith('/') && uriSegment.StartsWith('/'))
			{
				return $"{baseUri}{uriSegment.Substring(1)}";
			}
			else if (!baseUri.EndsWith('/') && !uriSegment.StartsWith('/'))
			{
				return $"{baseUri}/{uriSegment[1..]}";
			}
			return $"{baseUri}{uriSegment}";
		}
	}
}
