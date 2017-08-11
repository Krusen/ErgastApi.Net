namespace ErgastApi.Serialization.Converters
{
    public class StringGapTimeSpanConverter : StringTimeSpanConverter
    {
        protected override string[] Formats => new[]
        {
            "'+'mm':'ss'.'fff",
            "'+'m':'ss'.'fff",
            "'+'ss'.'fff",
            "'+'s'.'fff",
        };
    }
}
