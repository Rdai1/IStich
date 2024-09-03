using Microsoft.AspNetCore.Identity;

namespace IStitch.Models
{
    public class User : IdentityUser
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public ICollection<Service?> items { get; set; }
    }
}
