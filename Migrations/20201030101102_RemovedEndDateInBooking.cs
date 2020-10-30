using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class RemovedEndDateInBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("0f9af9b9-0498-4ccf-919e-8a252123a0cb"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("5b52ad9f-c027-4b16-a0fb-6b1173e84805"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("7d56789b-e4fc-4aa2-aa4c-6c4ec9ec10ca"));

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("e973ea44-505c-49c2-b234-87af99de3d96"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", null, null, "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("6f823d98-1ba3-4adc-9c33-6b803d0fece3"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", null, null, "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("b77c6231-4eb6-42fe-9962-5798928b5a3a"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", null, null, "09021987212", "Kwara", null, null, "0122392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("6f823d98-1ba3-4adc-9c33-6b803d0fece3"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("b77c6231-4eb6-42fe-9962-5798928b5a3a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("e973ea44-505c-49c2-b234-87af99de3d96"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("7d56789b-e4fc-4aa2-aa4c-6c4ec9ec10ca"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", null, null, "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("5b52ad9f-c027-4b16-a0fb-6b1173e84805"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", null, null, "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("0f9af9b9-0498-4ccf-919e-8a252123a0cb"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", null, null, "09021987212", "Kwara", null, null, "0122392" });
        }
    }
}
