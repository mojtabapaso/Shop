using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "c2b110bf-acbd-426d-9a1f-4328f2b1a33c", "AQAAAAIAAYagAAAAEIZHnu8+wEZQy/L2GyiKCdyubpRONbAZmxtgTZIk1pJyK3Ul/D/bT0VPNEfa5V9CQg==", "09111111111", "0db46ee0-087e-48a8-9972-5737e5021e16" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "31761da5-c3ff-436e-8520-c27e12fd8353", "AQAAAAIAAYagAAAAEFBfhQ3PqGQN9wI63J8T1DxgXlZCZl58s3dfsfGhkdpptUZDNNR4gH5E+LDwBugi2w==", "XXXXXXXXXXXXX", "4f2c876a-7772-43fc-b400-01273f90f439" });
        }
    }
}
