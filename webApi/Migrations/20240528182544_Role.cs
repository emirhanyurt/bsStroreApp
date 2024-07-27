using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1037a43f-0d64-4a21-9449-8bfa1ea017c0", null, "Admin", "ADMIN" },
                    { "b39454d3-2f73-4428-9d90-c42b7efc36a3", null, "Editor", "EDITOR" },
                    { "cae06484-0542-46e8-b059-19e9df0c95d2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1037a43f-0d64-4a21-9449-8bfa1ea017c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b39454d3-2f73-4428-9d90-c42b7efc36a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cae06484-0542-46e8-b059-19e9df0c95d2");
        }
    }
}
