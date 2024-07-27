using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17c4c835-989a-4772-bc2d-e2c69e105dfa", "3bc3683e-8f6a-46fe-a37e-ab5989c6029c", "Editor", "EDITOR" },
                    { "1a484105-05f1-45f7-8a73-6afe94f1a323", "be9b7071-fb6a-4be0-b2a4-da1867eabc62", "User", "USER" },
                    { "7489b25e-d6e5-457c-a42d-72eee8aa5308", "a9154001-f355-4e0c-bbca-08fe72b67965", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database Management System" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17c4c835-989a-4772-bc2d-e2c69e105dfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a484105-05f1-45f7-8a73-6afe94f1a323");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7489b25e-d6e5-457c-a42d-72eee8aa5308");

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
    }
}
