using Microsoft.AspNetCore.Builder;
using System.Net;
using Microsoft.AspNetCore.Identity;
using IStitch.Models;

namespace IStitch.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.ServiceType.Any())
                {
                    context.ServiceType.AddRange(new List<ServiceType>()
                    {
                        new ServiceType()
                        {
                            Category = "Pant Alterations",
                            Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                            ServicesList = new List<Service>
                            {
                                new Service { ServiceName = "Resize Waist", Price = 12.99f, Description = "Adjust the waist size of pants for a better fit.", Img = "https://example.com/resize-waist.jpg" },
                                new Service { ServiceName = "Cuffing", Price = 15.99f, Description = "Add or adjust cuffs on pants.", Img = "https://example.com/cuffing.jpg" },
                                new Service { ServiceName = "Tapering Legs", Price = 18.99f, Description = "Narrow the legs of pants for a slimmer fit.", Img = "https://example.com/tapering-legs.jpg" },
                                new Service { ServiceName = "Replace Zipper", Price = 20.99f, Description = "Repair or replace broken zippers on pants.", Img = "https://example.com/replace-zipper.jpg" },
                                new Service { ServiceName = "Patch Work", Price = 14.99f, Description = "Add patches to worn or torn areas.", Img = "https://example.com/patch-work.jpg" }
                            }
                        },
                        new ServiceType()
                        {
                            Category = "Formal Wear",
                            Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                            ServicesList = new List<Service>
                            {
                                new Service { ServiceName = "Custom Tailoring", Price = 299.99f, Description = "Full custom tailoring for suits and dresses.", Img = "https://example.com/custom-tailoring.jpg" },
                                new Service { ServiceName = "Alter Suit Jackets", Price = 149.99f, Description = "Adjust the fit of suit jackets.", Img = "https://example.com/alter-suit-jackets.jpg" },
                                new Service { ServiceName = "Alter Dress Hems", Price = 79.99f, Description = "Shorten or lengthen the hem of dresses.", Img = "https://example.com/alter-dress-hems.jpg" },
                                new Service { ServiceName = "Reinforce Seams", Price = 39.99f, Description = "Strengthen seams on high-wear formal wear.", Img = "https://example.com/reinforce-seams.jpg" },
                                new Service { ServiceName = "Belt Loop Replacement", Price = 15.99f, Description = "Replace or repair belt loops on formal trousers.", Img = "https://example.com/belt-loop-replacement.jpg" }

                            }
                        },
                        new ServiceType()
                        {
                            Category = "Repairs",
                            Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                            ServicesList = new List<Service>
                            {
                                new Service {ServiceName = "Mending rips or tears in shirts, jackets, or skirts", Price = 999f, Description = "dfghfg", Img = "link"},
                                new Service {ServiceName = "Button replacements", Price = 999f, Description = "dfghdfgh", Img = "link"},
                                new Service {ServiceName = "Zipper replacements", Price = 999f, Description = "dfghdfgh", Img = "link"},
                                new Service {ServiceName = "Adding patches to jackets", Price = 999f, Description = "dfghdfgh", Img = "link"},
                                new Service {ServiceName = "Mending ripped pants or jeans", Price = 999f, Description = "dfghfgh", Img = "link"}
                            }
                        },
                        new ServiceType()
                        {
                            Category = "Household",
                            Img = "https://c.pxhere.com/photos/ae/bd/adult_attractive_business_contemporary_corporate_couple_dress_facial_expression-1542709.jpg!d",
                            ServicesList = new List<Service>
                            {
                                new Service { ServiceName = "Curtain Repairs", Price = 29.99f, Description = "Mend tears or replace hooks in your curtains.", Img = "https://example.com/curtain-repairs.jpg" },
                                new Service { ServiceName = "Duvet Repairs", Price = 34.99f, Description = "Repair tears or damaged seams in duvets.", Img = "https://example.com/duvet-repairs.jpg" },
                                new Service { ServiceName = "Blanket Repairs", Price = 19.99f, Description = "Fix holes or seams on blankets.", Img = "https://example.com/blanket-repairs.jpg" }
                            }
                        }
                    });

                            context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "thetestemail@email.gg";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        fName = "Ray",
                        lName = "Dai",
                        UserName = "raymonddai",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "atestemail@emailabc.ca";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        fName = "Ray2",
                        lName = "Dai2",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
