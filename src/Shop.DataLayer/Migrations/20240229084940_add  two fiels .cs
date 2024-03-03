using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addtwofiels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11e2c8e5-9dec-421a-8462-9b30f37b825d", "AQAAAAIAAYagAAAAEJQf6dY6S3rgbRZ0UnxTZZ4Go94jCHHLKrkw45uN+rNGTMlYI+z6Sl0/H0hKIwGVWw==", "efbbdce1-cac4-4d51-80f4-b6e126ee2ebb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3956eae8-e645-4594-83a0-fc8aa0496d97", "AQAAAAIAAYagAAAAEH04xBpZR9CyE63JeTw1hOjVdRa3Kgxo2/FuNXssDk++aZtyu5whhQGRoABgk40VGw==", "885b182f-a206-4e9d-b537-93e58a9dca1a" });
        }
    }
}
