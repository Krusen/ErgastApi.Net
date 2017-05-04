using System;
using Newtonsoft.Json;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ErgastApi.Responses.Models
{
    public class Driver
    {
        public string DriverId { get; set; }

        // TODO: Only for 2014+ (and might different than their actual number . i.e. #1 for champions
        /// <summary>
        /// Drivers who participated in the 2014 season onwards have a permanent driver number.
        /// However, this may differ from the value of the number attribute of the Result element in earlier seasons or
        ///  where the reigning champion has chosen to use “1” rather than his permanent driver number.
        /// </summary>
        public int? PermanentNumber { get; set; }

        public string Code { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [JsonProperty("givenName")]
        public string FirstName { get; set; }

        [JsonProperty("familyName")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }
    }
}