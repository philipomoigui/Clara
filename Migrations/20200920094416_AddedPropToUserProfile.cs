using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class AddedPropToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("0d24d75a-d97e-4f65-b3cb-43515b24cc97"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("2eaa1e72-155e-4839-b779-8db53eee7e3d"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: new Guid("4bb7eb00-8cc5-4d7c-ba2d-5f792bea2ccb"));

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserProfiles",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "About",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserProfiles");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("2eaa1e72-155e-4839-b779-8db53eee7e3d"), "21, barr. xpress omoigui strt", "philo@gmail.com", "Philo Inc", 235, "sagamu", "09021987212", "Lagos", null, "07162392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("4bb7eb00-8cc5-4d7c-ba2d-5f792bea2ccb"), "11, Sangotedo strt", "dadesola@gmail.com", "Dade Designs", 235, "Lawanfe", "09021987212", "Lagos", null, "122392" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "AddressLine", "BusinessEmail", "BusinessName", "CategoryId", "City", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[] { new Guid("0d24d75a-d97e-4f65-b3cb-43515b24cc97"), "115, barr. xpress omoigui strt", "SholpeDes@gmail.com", "Shola Catering", 236, "Ikorodu", "09021987212", "Kwara", null, "0122392" });
        }
    }
}
