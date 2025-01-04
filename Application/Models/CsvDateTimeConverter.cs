using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

public class CsvDateTimeConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (DateTime.TryParseExact(
            text,
            "yyyy-MM-ddTHH:mm+00Z",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal,
            out var date))
        {
            return date;
        }

        throw new Exception($"Invalid date format: {text}");       
    }

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value is DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm+00Z");
        }

        return base.ConvertToString(value, row, memberMapData);
    }
}
