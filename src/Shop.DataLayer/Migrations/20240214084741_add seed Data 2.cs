using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addseedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "b35494cf-4040-47e3-a6de-dee4b6f8e250", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "24d227af-bc70-476f-9082-8bf04f791465", "AQAAAAIAAYagAAAAENWRchBf7r6rnh+tmOe7ZOp0QNSKJxGzLX3ddFjJT3FrKNCMq6dmFGDTiZAdIgOEUQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2b7969a-cb3f-4dd2-b1ad-ccda5ea19e23", "AQAAAAIAAYagAAAAECkGC28G24u8lcb6fsZlyP0EXFAvjdxoKuZndWPD5PyXc/YCyDEp64mwh2qN5y8T8A==" });
        }
    }
}
