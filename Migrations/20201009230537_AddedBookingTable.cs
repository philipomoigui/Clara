using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedBookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("047ef76d-e9ad-4876-8001-97932e546dd0"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("40659207-7ef6-4a72-85b4-38de5c58825d"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("ec320357-911c-4a5b-a1ed-a383dd4faaf3"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("9e50696e-3821-41ab-a4f6-4a3c12e099a0"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("60b7343d-84df-4ed3-baeb-ccde02c5dbb4"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("c47467dc-b206-4c88-aeb1-b803d16e127c"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, null, "0122392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("60b7343d-84df-4ed3-baeb-ccde02c5dbb4"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("9e50696e-3821-41ab-a4f6-4a3c12e099a0"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("c47467dc-b206-4c88-aeb1-b803d16e127c"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("047ef76d-e9ad-4876-8001-97932e546dd0"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("ec320357-911c-4a5b-a1ed-a383dd4faaf3"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileUserId", "ZipCode" },
                values: new object[] { new Guid("40659207-7ef6-4a72-85b4-38de5c58825d"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, null, "0122392" });
        }
    }
}
