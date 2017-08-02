using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Driver
    {
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        /// <summary>
        /// Drivers who participated in the 2014 season onwards have a permanent driver number.
        /// However, this may differ from the value of the number attribute of the Result element in earlier seasons
        /// or  where the reigning champion has chosen to use "1" rather than his permanent driver number.
        /// </summary>
        [JsonProperty("permanentNumber")]
        public int? PermanentNumber { get; private set; }

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