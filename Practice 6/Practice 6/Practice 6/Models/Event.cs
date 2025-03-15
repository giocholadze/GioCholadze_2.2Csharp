using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Practice_6.Models
{
    public class Event
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("src_number")]
        public string src_number { get; set; }

        [JsonProperty("dst_number")]
        public string dst_number { get; set; }

        [JsonProperty("time")]
        public string time { get; set; }

        [JsonProperty("src_loc")]
        public List<double> src_loc { get; set; }

        [JsonProperty("dst_loc")]
        public List<double> dst_loc { get; set; }

        [JsonProperty("duration")]
        public int? duration { get; set; }
    }
    
}
