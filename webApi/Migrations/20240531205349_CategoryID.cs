using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22bf8461-4214-44a0-a3d6-fa311438fe7b", "471a0807-edaa-4b22-9d17-b6d31cc513e6", "User", "USER" },
                    { "5f16d82c-38ae-449f-9509-5afb23cd3298", "a64cdf02-ab43-4ac8-a090-8f5cd5ed83c8", "Admin", "ADMIN" },
                    { "864fddcf-eabd-455a-9153-f872bbf0db0d", "6f164b5e-8b75-4c70-8b73-c17e97704050", "Editor", "EDITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22bf8461-4214-44a0-a3d6-fa311438fe7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f16d82c-38ae-449f-9509-5afb23cd3298");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "864fddcf-eabd-455a-9153-f872bbf0db0d");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17c4c835-989a-4772-bc2d-e2c69e105dfa", "3bc3683e-8f6a-46fe-a37e-ab5989c6029c", "Editor", "EDITOR" },
                    { "1a484105-05f1-45f7-8a73-6afe94f1a323", "be9b7071-fb6a-4be0-b2a4-da1867eabc62", "User", "USER" },
                    { "7489b25e-d6e5-457c-a42d-72eee8aa5308", "a9154001-f355-4e0c-bbca-08fe72b67965", "Admin", "ADMIN" }
                });
        }
    }
}
