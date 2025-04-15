using ClosedXML.Excel;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Practice_7.Models
{
    public class Customer
    {
        [JsonProperty("lines")]
        public List<Line> lines { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }
        public XLCellValue CustomerId { get; internal set; }
    }
}

