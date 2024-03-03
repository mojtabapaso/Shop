using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce5cc011-5477-4844-8f86-ccab0c90605e", "AQAAAAIAAYagAAAAEEC1I5jKK/pcyAsNj0zK0dHFw4doWz9RCGS7dQbATH7CapoTMi3ENigwGp9RCzofsw==", "6e6a0f86-2a4e-4c7c-a7c0-250e287ac687" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e42d586-8a6e-46f5-a4f2-39c479cc8201", "AQAAAAIAAYagAAAAEPvQlw+UOcZ7xSgM4Kfpu9usZx87yOfrWlpAyW53Tb4EHFEvbhMs6QHYGIzjMe84aA==", "f336676e-3d48-47e7-b378-2483ec1fd10c" });
        }
    }
}
