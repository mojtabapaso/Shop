using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e42d586-8a6e-46f5-a4f2-39c479cc8201", "AQAAAAIAAYagAAAAEPvQlw+UOcZ7xSgM4Kfpu9usZx87yOfrWlpAyW53Tb4EHFEvbhMs6QHYGIzjMe84aA==", "f336676e-3d48-47e7-b378-2483ec1fd10c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2b110bf-acbd-426d-9a1f-4328f2b1a33c", "AQAAAAIAAYagAAAAEIZHnu8+wEZQy/L2GyiKCdyubpRONbAZmxtgTZIk1pJyK3Ul/D/bT0VPNEfa5V9CQg==", "0db46ee0-087e-48a8-9972-5737e5021e16" });
        }
    }
}
