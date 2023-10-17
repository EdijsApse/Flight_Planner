using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Flight_Planner.Models
{
    public class AirportRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(10)]
        [JsonPropertyName("airport")]
        public string Airport { get; set; }
    }
}
