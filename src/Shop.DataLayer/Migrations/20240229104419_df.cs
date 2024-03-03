using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class df : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07c9dd24-08de-45ef-8ae3-90136b35ffd8", "AQAAAAIAAYagAAAAEKTEOwQ+2L/3HkpjjkDockXxjLh0+8YCbkU9PfAbfmXCNwJLhQH9/NuJ9CVx/HVGWg==", "5bf5a581-660d-4857-bcb2-b28b8dabee27" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11e2c8e5-9dec-421a-8462-9b30f37b825d", "AQAAAAIAAYagAAAAEJQf6dY6S3rgbRZ0UnxTZZ4Go94jCHHLKrkw45uN+rNGTMlYI+z6Sl0/H0hKIwGVWw==", "efbbdce1-cac4-4d51-80f4-b6e126ee2ebb" });
        }
    }
}
