using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDateTime", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "d2b7969a-cb3f-4dd2-b1ad-ccda5ea19e23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin@Admin.com", true, "", "", false, null, "ADMIN@ADMIN.COM", "MASTERADMIN", "AQAAAAIAAYagAAAAECkGC28G24u8lcb6fsZlyP0EXFAvjdxoKuZndWPD5PyXc/YCyDEp64mwh2qN5y8T8A==", "XXXXXXXXXXXXX", true, "00000000-0000-0000-0000-000000000000", false, "masteradmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
