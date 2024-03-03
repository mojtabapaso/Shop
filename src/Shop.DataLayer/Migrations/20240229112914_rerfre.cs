using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class rerfre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9f77b37-09ef-4a8f-90e2-69fe32c90f78", "AQAAAAIAAYagAAAAEHUijDlBnsKzQ5SANsSypOkV4EoXeOnfR1BdohQzqBOCVO4m8UmZTdPrWsnI7LWghQ==", "23299ed3-7132-4eba-97d4-9b6d52b0bfd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78ee6145-dea0-4e71-b2ea-62ede8e98116", "AQAAAAIAAYagAAAAEB8G/b/YqOafkx6cLWoxSd6hpVe0UG1Rox9A5wo909dIgB3NJC1oCd8FdXol6M2j0Q==", "bc2af27e-9bc0-41c4-b78b-ce6a88d631ef" });
        }
    }
}
