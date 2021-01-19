using Clara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
                new ApplicationUser { Email = "Test@mail.com", NormalizedUserName= "Test@mail.com", UserName = "Test@mail.com", EmailConfirmed = true, Id = "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2", PasswordHash= hasher.HashPassword(null, "Test123")}
                );

            modelBuilder.Entity<UserProfile>().HasData(

                new UserProfile { LastName = "Test", FirstName = "Just", UserId = "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2", Email = "Test@mail.com" }
                ) ;
        }
    }
}
