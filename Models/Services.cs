using System.Text.Json;

namespace IStichIt.Models
{
    public class Services
    {

        public string Service { get; set; }
        public float Price { get; set; }
        //public string Image { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Services>(this);
    }
}
