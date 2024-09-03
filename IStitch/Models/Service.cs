using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IStitch.Models
{
    public class Service
    {
        [Key]
        public required string ServiceName { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }

        [Required]
        [ForeignKey("Category")]
        public string Category { get; set; }
    }

}
