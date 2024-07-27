using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class refreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03bf4820-fcdd-42d7-a5b1-fedf44cb43d3", "37f84207-bc3c-4e3d-b177-b63bdd80b2eb", "User", "USER" },
                    { "1f8233e0-e35d-4435-85f9-c0b80492ddd4", "5459d5cf-5c64-4889-a547-b30e22b73a2a", "Admin", "ADMIN" },
                    { "aabf0b0a-62ba-442c-9761-d06856f4ecb0", "98e9c0b7-7ff0-47ba-a279-b6169740d5e7", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03bf4820-fcdd-42d7-a5b1-fedf44cb43d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f8233e0-e35d-4435-85f9-c0b80492ddd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aabf0b0a-62ba-442c-9761-d06856f4ecb0");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
