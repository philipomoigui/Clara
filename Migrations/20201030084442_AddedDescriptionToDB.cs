using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedDescriptionToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("6f2f796f-9bcd-45e5-bd7c-ea983c4e2ef6"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("c60756e2-9f40-4521-b5f6-88e9983faaaa"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("d2355991-e5dc-4111-844f-94bcabb6b8be"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("d2355991-e5dc-4111-844f-94bcabb6b8be"), "21, barr. xpress omoigui strt", null, "philo@gmail.com", "Philo Inc", 235, "sagamu", null, "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("c60756e2-9f40-4521-b5f6-88e9983faaaa"), "11, Sangotedo strt", null, "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", null, "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "Amenities", "BusinessEmail", "BusinessName", "CategoryId", "City", "ImageURL", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("6f2f796f-9bcd-45e5-bd7c-ea983c4e2ef6"), "115, barr. xpress omoigui strt", null, "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", null, "09021987212", "Kwara", null, null, "0122392" });
        }
    }
}
