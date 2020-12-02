using Microsoft.EntityFrameworkCore.Migrations;

namespace Clara.Migrations
{
    public partial class ChangedExpectedGuestDataTypeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExpectedGuests",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce61d808-7b38-47c3-b864-2d9e8dfdf235", "AQAAAAEAACcQAAAAEFTmqATQKex9hCJ9A/1/0GS9UEjNR/+4tgVNNeo1M83p0U2MwQvCHT9iVW1sJ0TU8w==", "f1bd7117-ce3f-4722-9208-cd4a691ed82c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpectedGuests",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2d2414-3baa-473b-baf2-0a3dd5e6a6e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db85c766-9454-416a-844a-cfc1d9815f5d", "AQAAAAEAACcQAAAAEDgl/Y4VC0tQz8HM3FwmJLBE9GrLScWbHdQ+xvM3KS/zmMO4vXWCeSD/3AluIERdnw==", "68c42249-b309-4cd6-8b05-b582fa4d4b2e" });
        }
    }
}
