using Clara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Extension_Methods
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Category Seed Data
           
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 233, CategoryName = " Halls"},
                new Category { CategoryId = 234, CategoryName = "Logistics" },
                new Category { CategoryId = 235, CategoryName = "Event Planning" },
                new Category { CategoryId = 236, CategoryName = "Food And Drinks" },
                new Category { CategoryId = 237, CategoryName = "Accomodations" }
                );

            //User Seed Data

            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Email = "Test@mail.com", NormalizedUserName= "Test@mail.com", UserName = "Test@mail.com", EmailConfirmed = true, Id = Guid.NewGuid().ToString(), PasswordHash= hasher.HashPassword(null, "Test123")}
                );
        }
    }
}
