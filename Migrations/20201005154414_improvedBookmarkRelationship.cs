using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class improvedBookmarkRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("4a6039b0-9af3-4520-8e29-c8cef077a35c"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("86c1cacb-ffad-47e3-9259-f417a79990f9"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("d7cbb5cd-2f5e-4bac-b667-1bf7489ec413"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookmark_ServiceId",
                table: "Bookmark",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmark_Services_ServiceId",
                table: "Bookmark",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmark_Services_ServiceId",
                table: "Bookmark");

            migrationBuilder.DropIndex(
                name: "IX_Bookmark_ServiceId",
                table: "Bookmark");

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

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("86c1cacb-ffad-47e3-9259-f417a79990f9"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("4a6039b0-9af3-4520-8e29-c8cef077a35c"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("d7cbb5cd-2f5e-4bac-b667-1bf7489ec413"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, "0122392" });
        }
    }
}
