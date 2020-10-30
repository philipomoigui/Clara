using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class ChangedRatingToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("532f238b-6ec4-4efc-9250-ed6f386b38f6"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("55edb914-2e5a-4f8f-a7e4-d953bc4851cb"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("dc9a2fa2-daa0-47c5-b612-b6b335636102"));

            migrationBuilder.AlterColumn<int>(
                name: "rating",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "rating",
                table: "Comments",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("55edb914-2e5a-4f8f-a7e4-d953bc4851cb"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", null, null, "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("dc9a2fa2-daa0-47c5-b612-b6b335636102"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", null, null, "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "Description", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("532f238b-6ec4-4efc-9250-ed6f386b38f6"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", null, null, "09021987212", "Kwara", null, null, "0122392" });
        }
    }
}
