using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class rerf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78ee6145-dea0-4e71-b2ea-62ede8e98116", "AQAAAAIAAYagAAAAEB8G/b/YqOafkx6cLWoxSd6hpVe0UG1Rox9A5wo909dIgB3NJC1oCd8FdXol6M2j0Q==", "bc2af27e-9bc0-41c4-b78b-ce6a88d631ef" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07c9dd24-08de-45ef-8ae3-90136b35ffd8", "AQAAAAIAAYagAAAAEKTEOwQ+2L/3HkpjjkDockXxjLh0+8YCbkU9PfAbfmXCNwJLhQH9/NuJ9CVx/HVGWg==", "5bf5a581-660d-4857-bcb2-b28b8dabee27" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
