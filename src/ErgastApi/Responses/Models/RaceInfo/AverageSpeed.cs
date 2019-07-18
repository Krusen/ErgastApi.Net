using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// The average speed during a race.
    /// </summary>
    public class AverageSpeed
    {
        [JsonProperty("units")]
        public SpeedUnit Unit { get; protected set; }

        [JsonProperty("speed")]
        public double Speed { get; protected set; }

        /// <summary>
        /// The speed in kilometers per hour with 2 decimals if the <see cref="SpeedUnit"/> is known, otherwise null.
        /// </summary>
        public double? SpeedInKph
        {
            get
            {
                switch (Unit)
                {
                    case SpeedUnit.Unknown: return null;
                    case SpeedUnit.Kph:     return Speed;
                    case SpeedUnit.Mph:     return Math.Round(Speed * 1.609344, 2);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Returns the speed in miles per hour with 2 decimals if the <see cref="SpeedUnit"/> is known, otherwise null.
        /// </summary>
        public double? SpeedInMph
        {
            get
            {
                switch (Unit)
                {
                    case SpeedUnit.Unknown: return null;
                    case SpeedUnit.Mph:     return Speed;
                    case SpeedUnit.Kph:     return Math.Round(Speed * 0.6213711922, 2);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}