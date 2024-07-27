using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class Role2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e77d5f6-b1dd-4d59-88fc-18e2d9c2641d", "6fb12259-3830-40ba-8faa-c8b93ef9ac84", "User", "USER" },
                    { "59de5a69-fc2d-452a-aaa8-c92f084b25b3", "98b44649-3dcd-45bf-af91-a96031aa2c6a", "Admin", "ADMIN" },
                    { "e77bd46f-c285-48a9-94f1-46164692bb48", "f25b5f81-3dde-484e-92d0-40357be427c4", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e77d5f6-b1dd-4d59-88fc-18e2d9c2641d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59de5a69-fc2d-452a-aaa8-c92f084b25b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77bd46f-c285-48a9-94f1-46164692bb48");

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
    }
}
