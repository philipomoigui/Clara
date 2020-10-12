using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedAmenitiesToServiceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ExpectedGuests = table.Column<string>(nullable: true),
                    AdditionalDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

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

            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Services");

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
    }
}
