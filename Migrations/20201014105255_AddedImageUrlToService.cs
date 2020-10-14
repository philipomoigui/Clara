using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedImageUrlToService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("26c12789-a4d5-4ba3-a0bd-9a32536cbd1a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("bd14d40c-59bb-4ca5-b903-6fc0952ecc86"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("bfe2ae28-8f9a-42e1-9127-9f64967250a2"));

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Services",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("56844e26-4c2e-4e33-8fe8-f1c3cd1dc812"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", null, "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("3aecd519-90d6-47af-9687-3c67e6383ad5"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", null, "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("cded74b4-dc44-4ceb-ba27-b205ec5f5387"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", null, "09021987212", "Kwara", null, null, "0122392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("3aecd519-90d6-47af-9687-3c67e6383ad5"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("56844e26-4c2e-4e33-8fe8-f1c3cd1dc812"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("cded74b4-dc44-4ceb-ba27-b205ec5f5387"));

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Services");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("26c12789-a4d5-4ba3-a0bd-9a32536cbd1a"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("bd14d40c-59bb-4ca5-b903-6fc0952ecc86"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("bfe2ae28-8f9a-42e1-9127-9f64967250a2"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, null, "0122392" });
        }
    }
}
