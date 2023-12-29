using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IStichIt.Models
{
    public class Service
    {
        [Key]
        public required string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        [Required]
        [ForeignKey("Category")]
        public string Category { get; set; }
    }

    public class Services
    {
        [Key, JsonPropertyName("Category")]
        public required string Category { get; set; }

        public string Img { get; set; }

        [JsonPropertyName("Services")]
        public List<Service> ServicesList { get; set; }

    }

}
