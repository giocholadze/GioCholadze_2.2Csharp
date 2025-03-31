using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Practice_7.Models
{
    public class Root
    {
        [JsonProperty("events")]
        public List<Event> events { get; set; }

        [JsonProperty("customers")]
        public List<Customer> customers { get; set; }
    }
}
