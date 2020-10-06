using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class LinkedUserProfileToD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("13be5e9d-a470-4c40-bacb-e7571dc1adb0"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("1ac77b3f-adef-4ab7-ad3f-bf1ec419668f"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("8c61b0f6-2204-4120-8a76-66f07959f8c5"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Services",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileId", "ZipCode" },
                values: new object[] { new Guid("8d976b7d-c10d-410c-963b-8f11553651a6"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileId", "ZipCode" },
                values: new object[] { new Guid("e7388417-e5ea-4fa2-b4c2-2c25d2b808fc"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "UserProfileId", "ZipCode" },
                values: new object[] { new Guid("52e9ddbd-bf9b-4aa7-978b-d471cd93b992"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, null, "0122392" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserProfileId",
                table: "Services",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_UserProfiles_UserProfileId",
                table: "Services",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_UserProfiles_UserProfileId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserProfileId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("52e9ddbd-bf9b-4aa7-978b-d471cd93b992"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("8d976b7d-c10d-410c-963b-8f11553651a6"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("e7388417-e5ea-4fa2-b4c2-2c25d2b808fc"));

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Services");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("8c61b0f6-2204-4120-8a76-66f07959f8c5"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("13be5e9d-a470-4c40-bacb-e7571dc1adb0"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("1ac77b3f-adef-4ab7-ad3f-bf1ec419668f"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, "0122392" });
        }
    }
}
