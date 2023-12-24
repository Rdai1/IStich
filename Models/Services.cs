using System.Text.Json;
using System.Text.Json.Serialization;

namespace IStichIt.Models
{
    public class Service
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("Services")]
        public Dictionary<string, Service> Services { get; set; }
    }

    public class Services
    {
        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("Services")]
        public Dictionary<string, Service> ServicesData { get; set; }

    }

}
