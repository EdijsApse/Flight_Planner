using System.Text.Json.Serialization;

namespace Flight_Planner.Models
{
    public struct Airport
    {
        public string Country { get; set; }

        public string City { get; set; }

        [JsonPropertyName("airport")]
        public string Code { get; set; }
    }
}
