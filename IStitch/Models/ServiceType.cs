using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IStitch.Models
{
    public class ServiceType
    {
        [Key, JsonPropertyName("Category")]
        public required string Category { get; set; }

        public string Img { get; set; }

        [JsonPropertyName("ServicesType")]
        public List<Service> ServicesList { get; set; }

    }
}
