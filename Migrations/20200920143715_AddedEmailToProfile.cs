using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedEmailToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("478f3ce6-bacb-49a4-8d43-6c3de92fd505"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("6affc6c0-7ea0-4312-ab37-21ae113f9694"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("961952bf-a891-45f4-b5bf-1647c90fd31f"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("1857250a-e0e0-4017-aa8d-9ab66a1e9603"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("4e35420e-12fa-41b6-86c1-08212dfb630e"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("ab5cc934-956e-4fc8-badf-bd9086721967"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, "0122392" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("1857250a-e0e0-4017-aa8d-9ab66a1e9603"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("4e35420e-12fa-41b6-86c1-08212dfb630e"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("ab5cc934-956e-4fc8-badf-bd9086721967"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserProfiles");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("6affc6c0-7ea0-4312-ab37-21ae113f9694"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("961952bf-a891-45f4-b5bf-1647c90fd31f"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("478f3ce6-bacb-49a4-8d43-6c3de92fd505"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, "0122392" });
        }
    }
}
