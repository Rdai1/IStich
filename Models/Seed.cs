using Microsoft.AspNetCore.Builder;
using System.Net;
using Microsoft.AspNetCore.Identity;


namespace IStichIt.Models
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Services.Any())
                {
                    context.Services.AddRange(new List<Services>()
            {
                new Services()
                {
                    Category = "Pants",
                    Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                    ServicesList = new List<Service>
                    {
                        new Service {Name = "Hem Pants", Price = 10.99f, Description = "Transform the fit of your pants...", Img = "link"},
                        new Service {Name = "Replace Buttons", Price = 10.99f, Description = "Lost a button on the waist of your pants?...", Img = "link"},
                        new Service {Name = "Fix/Replace Zipper", Price = 10.99f, Description = "For pants with zipper issues...", Img = "link"}
                    }
                },
                new Services()
                {
                    Category = "Formal",
                    Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                    ServicesList = new List<Service>
                    {
                        new Service {Name = "Wedding Dress", Price = 999f, Description = "dgfhdfgh", Img = "link"},
                        new Service {Name = "Suits", Price = 999f, Description = "dghfgh", Img = "link"},
                        new Service {Name = "Prom and Graduation", Price = 999f, Description = "dghdfg", Img = "link"}
                    }
                },
                new Services()
                {
                    Category = "Repairs",
                    Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                    ServicesList = new List<Service>
                    {
                        new Service {Name = "Mending rips or tears in shirts, jackets, or skirts", Price = 999f, Description = "dfghfg", Img = "link"},
                        new Service {Name = "Button replacements", Price = 999f, Description = "dfghdfgh", Img = "link"},
                        new Service {Name = "Zipper replacements", Price = 999f, Description = "dfghdfgh", Img = "link"},
                        new Service {Name = "Adding patches to jackets", Price = 999f, Description = "dfghdfgh", Img = "link"},
                        new Service {Name = "Mending ripped pants or jeans", Price = 999f, Description = "dfghfgh", Img = "link"}
                    }
                },
                new Services()
                {
                    Category = "Household",
                    Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                    ServicesList = new List<Service>
                    {
                        new Service {Name = "repair mending curtains", Price = 999f, Description = "asdasd", Img = "link"},
                        new Service {Name = "repair mending douvets", Price = 999f, Description = "asdsd", Img = "link"},
                        new Service {Name = "etc", Price = 999f, Description = "etc", Img = "link"}
                    }
                }
            });

                    context.SaveChanges();
                }
            }
        }
    }
}
