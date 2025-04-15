using Newtonsoft.Json;

namespace Practice_7.Models
{
    public class Root
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }

        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }
    }
}
