using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29f83399-512e-43ce-81a5-7f6464582f1a", "3c94a511-05ac-4ea4-a42f-2e6c536ce23d", "Admin", "ADMIN" },
                    { "ce941750-d784-4596-9fe4-a16f107ffaa6", "c7eed8a5-7b0d-4744-9998-8ff130df19bb", "User", "USER" },
                    { "f4521021-3d3c-4952-843c-4a4a66b45ad4", "6eb3a9ad-7dcf-490c-ba80-6ab5709cfc4d", "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f83399-512e-43ce-81a5-7f6464582f1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce941750-d784-4596-9fe4-a16f107ffaa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4521021-3d3c-4952-843c-4a4a66b45ad4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22bf8461-4214-44a0-a3d6-fa311438fe7b", "471a0807-edaa-4b22-9d17-b6d31cc513e6", "User", "USER" },
                    { "5f16d82c-38ae-449f-9509-5afb23cd3298", "a64cdf02-ab43-4ac8-a090-8f5cd5ed83c8", "Admin", "ADMIN" },
                    { "864fddcf-eabd-455a-9153-f872bbf0db0d", "6f164b5e-8b75-4c70-8b73-c17e97704050", "Editor", "EDITOR" }
                });
        }
    }
}
