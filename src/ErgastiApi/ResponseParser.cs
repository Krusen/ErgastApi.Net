using System;
using System.Collections.Generic;
using ErgastApi.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErgastApi
{
    public interface IResponseParser
    {
        RaceResponse Parse(string json);
    }

    public class ResponseParser : IResponseParser
    {
        public RaceResponse Parse(string json)
        {
            Console.WriteLine("Parsing response... (not really)");
            return new RaceResponse();
        }

        private ResponseType GetResponseType(string json)
        {
            var jobject = JsonConvert.DeserializeObject<JObject>(json);

            var responseTypes = new Dictionary<string, ResponseType>
            {
                ["RaceTable"] = ResponseType.Race,
                ["ConstructorTable"] = ResponseType.Constructor,
            };

            foreach (var entry in responseTypes)
            {
                if (jobject.SelectToken("MRData." + entry.Key) != null)
                    return entry.Value;
            }

            // TODO: Better handling and/or error message
            throw new NotSupportedException("The response is not supported");
        }

        public enum ResponseType
        {
            Race,
            Constructor
        }
    }
}