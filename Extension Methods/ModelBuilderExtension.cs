using Clara.Models;
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

            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceId = Guid.NewGuid(), BusinessName = "Philo Inc", AddressLine = "21, barr. xpress omoigui strt", City ="sagamu" ,BusinessEmail = "philo@gmail.com", State = "Lagos", ZipCode = "07162392", CategoryId = 235, PhoneNumber = "09021987212"},
                new Service { ServiceId = Guid.NewGuid(), BusinessName = "Dade Designs", AddressLine = "11, Sangotedo strt", City = "Lawanfe", BusinessEmail = "dadesola@gmail.com", State = "Lagos", ZipCode = "122392", CategoryId = 235, PhoneNumber = "09021987212" },
                new Service { ServiceId = Guid.NewGuid(), BusinessName = "Shola Catering", AddressLine = "115, barr. xpress omoigui strt", City = "Ikorodu", BusinessEmail = "SholpeDes@gmail.com", State = "Kwara", ZipCode = "0122392", CategoryId = 236, PhoneNumber = "09021987212" }
                );
        }
    }
}
