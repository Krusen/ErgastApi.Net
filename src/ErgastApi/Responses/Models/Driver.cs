using System;
using ErgastApi.Ids;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    /// <summary>
    /// Contains information about a driver like his ID, name, nationality, date of birth, driver code etc.
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// The ID of the driver in the API. Used to make requests concerning a specific driver.
        /// The static <see cref="Drivers"/> class contains the IDs of most recent and popular drivers.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        /// <summary>
        /// Drivers who participated in the 2014 season onwards have a permanent driver number.
        /// However, this may differ from the value of the number attribute of the Result element in earlier seasons
        /// or  where the reigning champion has chosen to use "1" rather than his permanent driver number.
        /// </summary>
        [JsonProperty("permanentNumber")]
        public int? PermanentNumber { get; private set; }

        /// <summary>
        /// 3-letter driver code, e.g. HAM, VER, RIC.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        [JsonProperty("givenName")]
        public string FirstName { get; private set; }

        [JsonProperty("familyName")]
        public string LastName { get; private set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; private set; }

        [JsonProperty("nationality")]
        public string Nationality { get; private set; }
    }
}