using System;
using System.Text.RegularExpressions;

namespace ErgastApi.Ids
{
    public static class FinishingStatusIdParser
    {
        public static FinishingStatusId Parse(string value)
        {
            FinishingStatusId statusId;

            var lapsMatch = Regex.Match(value, @"\+(\d+) Laps?", RegexOptions.IgnoreCase);
            if (lapsMatch.Success)
            {
                value = "Laps" + lapsMatch.Groups[1].Value;
                if (Enum.TryParse(value, out statusId))
                    return statusId;
            }

            value = Regex.Replace(value, @"\s", "");

            Enum.TryParse(value, true, out statusId);

            return statusId;
        }
    }
}
