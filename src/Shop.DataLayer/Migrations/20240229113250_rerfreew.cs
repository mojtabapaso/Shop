using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class rerfreew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b5316d5-f711-4e3e-8687-0d8f3b12a1e7", "AQAAAAIAAYagAAAAEKNmLwukFL4AgmtiPPDdYJ472h7OsXUQzsZtmZ7I36cM+kUba3nGF051d4Z8ZaL3Hg==", "63137220-48ad-4f5f-ae12-25d9da40451c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9f77b37-09ef-4a8f-90e2-69fe32c90f78", "AQAAAAIAAYagAAAAEHUijDlBnsKzQ5SANsSypOkV4EoXeOnfR1BdohQzqBOCVO4m8UmZTdPrWsnI7LWghQ==", "23299ed3-7132-4eba-97d4-9b6d52b0bfd3" });
        }
    }
}
