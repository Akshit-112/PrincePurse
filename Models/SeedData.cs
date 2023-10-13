using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrincePurse.Data;
using System;
using System.Linq;

namespace PrincePurse.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PrincePurseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PrincePurseContext>>()))
            {
                // Look for any Purse.
                if (context.Purse.Any())
                {
                    return;   // DB has been seeded
                }

                context.Purse.AddRange(
                    new Purse { Brand = "Gucci", Colour = "Black", Materials = "Leather", Price = 1200.00M, Style = "Clutch", Availability = "Yes",CustomerRating = 2 },
            new Purse { Brand = "Louis Vuitton", Colour = "Brown", Materials = "Canvas", Price = 1500.00M, Style = "Tote", Availability = "Yes", CustomerRating = 4 },
            new Purse { Brand = "Chanel", Colour = "Red", Materials = "Lambskin", Price = 2500.00M, Style = "Crossbody", Availability = "No", CustomerRating = 2.5 },
            new Purse { Brand = "Prada", Colour = "Pink", Materials = "Saffiano Leather", Price = 1800.00M, Style = "Shoulder Bag", Availability = "Yes", CustomerRating = 4.5 },
            new Purse { Brand = "Michael Kors", Colour = "Blue", Materials = "Suede", Price = 900.00M, Style = "Hobo", Availability = "Yes", CustomerRating = 3 },
            new Purse { Brand = "Kate Spade", Colour = "Green", Materials = "Nylon", Price = 700.00M, Style = "Satchel", Availability = "No", CustomerRating = 1 },
            new Purse { Brand = "Coach", Colour = "Tan", Materials = "Signature Canvas", Price = 850.00M, Style = "Crossbody", Availability = "Yes", CustomerRating = 2.5},
            new Purse { Brand = "Burberry", Colour = "Beige", Materials = "Cotton", Price = 1600.00M, Style = "Shoulder Bag", Availability = "Yes", CustomerRating = 1.5 },
            new Purse { Brand = "Dior", Colour = "White", Materials = "Calfskin", Price = 2100.00M, Style = "Tote", Availability = "No", CustomerRating = 5 },
            new Purse { Brand = "Fendi", Colour = "Pink", Materials = "Suede", Price = 1900.00M, Style = "Hobo", Availability = "Yes", CustomerRating = 3.5 }



                );
                context.SaveChanges();
            }
        }
    }
}