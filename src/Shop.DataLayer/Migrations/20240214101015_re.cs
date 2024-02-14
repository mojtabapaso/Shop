using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class re : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac86fc4e-bd72-4492-b96e-71d0bc59855b", "AQAAAAIAAYagAAAAEFCWjAXSqyQwNSgkQDRBVyhz47rcscYeEW50KrMyU8o58oVDCp+WjkhCgeNR4pwW0A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21614328-155a-4896-9fff-a97bf0954f74", "AQAAAAIAAYagAAAAEHM1UGEM2XBPkWjMYQVL7PPxIeBmbt26J8+CxsjlCmMTByggngbEKM/lcfTGUifZLA==" });
        }
    }
}
