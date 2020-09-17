using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 233, " Halls" },
                    { 234, "Logistics" },
                    { 235, "Event Planning" },
                    { 236, "Food And Drinks" },
                    { 237, "Accomodations" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { new Guid("2c14db4c-f2e0-4194-b102-f1e030093f8c"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { new Guid("6c2539c6-098f-4e09-8289-01c07b831161"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { new Guid("37388458-1a99-4395-a3c9-fa16168532c1"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", "0122392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("2c14db4c-f2e0-4194-b102-f1e030093f8c"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("37388458-1a99-4395-a3c9-fa16168532c1"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("6c2539c6-098f-4e09-8289-01c07b831161"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 236);
        }
    }
}
