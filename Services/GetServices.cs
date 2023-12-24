using IStichIt.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IStichIt.Services
{
    public class GetServices
    {
        public GetServices(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "services.json");

        public IEnumerable<Models.Services> GetServicesList()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            var jsonString = jsonFileReader.ReadToEnd();

            var serviceList = JsonSerializer.Deserialize<List<Models.Services>>(jsonString,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            foreach (var service in serviceList) {
                System.Diagnostics.Debug.WriteLine(service.Category);
            }

            return serviceList;
        }

    }
}
