using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addfieldOrdertomodeluser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b087717-cd5f-464d-a166-a8454212ffa8", "AQAAAAIAAYagAAAAENGA7s+MB6nLC8LLe8B9S90+Gkb3MJLXTgMfkVgkr6SxlvVi7yPA/keKdGmENj9tVA==", "52e39e9c-ff27-4682-9443-c3ecbc93a4ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b61b18c-838e-40c7-8bee-d7d7797de60c", "AQAAAAIAAYagAAAAEOfbwPsCdjexLLF7TVbNQ/lPNxqHJOusRrEPylTw/HGXFtBL6soUVjnQKHhy3jc8nQ==", "14d10205-b7f2-4562-9e69-4415d7cffa97" });
        }
    }
}
