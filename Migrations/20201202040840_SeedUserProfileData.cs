using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class SeedUserProfileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db85c766-9454-416a-844a-cfc1d9815f5d", "AQAAAAEAACcQAAAAEDgl/Y4VC0tQz8HM3FwmJLBE9GrLScWbHdQ+xvM3KS/zmMO4vXWCeSD/3AluIERdnw==", "68c42249-b309-4cd6-8b05-b582fa4d4b2e" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "About", "AddressLine", "City", "Email", "FirstName", "ImageUrl", "LastName", "PasswordChangeDate", "PhoneNumber", "State", "ZipCode" },
                values: new object[] { "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2", null, null, null, "Test@mail.com", "Just", null, "Test", null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "UserId",
                keyValue: "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba7f4fa6-a31b-408d-aeb7-c33afc3d36cf", "AQAAAAEAACcQAAAAEELx6Eoyn/zpy1LKZZmC4m1rnXFnRD+eiY60LNmoWnKd5nBUo1W3+z2Q7zDtrDNWmA==", "f7773610-2b29-4054-b970-0f380b399fcc" });
        }
    }
}
