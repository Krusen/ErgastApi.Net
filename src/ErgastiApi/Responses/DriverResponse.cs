using System;
using System.Collections.Generic;
using ErgastApi.Serialization;
using Newtonsoft.Json;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ErgastApi.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class DriverResponse : ErgastResponse
    {
        [JsonProperty("DriverTable.Drivers")]
        public IList<Driver> Drivers { get; set; }
    }

    public class Driver
    {
        public string DriverId { get; private set; }

        // TODO: Only for 2014+ (and might different than their actual number . i.e. #1 for champions
        /// <summary>
        /// Drivers who participated in the 2014 season onwards have a permanent driver number.
        /// However, this may differ from the value of the number attribute of the Result element in earlier seasons or
        ///  where the reigning champion has chosen to use “1” rather than his permanent driver number.
        /// </summary>
        public int? PermanentNumber { get; private set; }

        public string Code { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("givenName")]
        public string FirstName { get; private set; }

        [JsonProperty("familyName")]
        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string Nationality { get; private set; }
    }
}
