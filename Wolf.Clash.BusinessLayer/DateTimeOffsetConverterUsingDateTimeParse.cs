namespace Wolf.Clash.BusinessLayer;

public class DateTimeOffsetConverterUsingDateTimeParse : JsonConverter<DateTimeOffset>
{
	public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return DateTimeOffset.ParseExact(reader.GetString() ?? "", "yyyyMMddTHHmmss.FFFZ", null, DateTimeStyles.None);
	}

	public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}
