namespace Wolf.Clash.BusinessLayer
{
	internal class UriUtility
	{
		public static Uri Combine(Uri baseUri, Uri uriSegment)
		{
			return Combine(baseUri, uriSegment);
		}

		public static Uri Combine(string baseUri, string uriSegment)
		{
			if (baseUri.EndsWith('/') && uriSegment.StartsWith('/'))
			{
				return new($"{baseUri}{uriSegment[1..]}");
			}
			else if (!baseUri.EndsWith('/') && !uriSegment.StartsWith('/'))
			{
				return new($"{baseUri}/{uriSegment}");
			}
			return new($"{baseUri}{uriSegment}");
		}
	}
}
