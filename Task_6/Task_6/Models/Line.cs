using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Practice_7.Models
{
    public class Line
    {
        [JsonProperty("number")]
        public string number { get; set; }

        [JsonProperty("contract")]
        public string contract { get; set; }
    }
}
