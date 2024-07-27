using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class chatMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a0e4292-b33c-4dab-b865-4be3303b7e7f", "0a60582a-e048-4943-bb9d-6f57d55bf61b", "Editor", "EDITOR" },
                    { "2c3897aa-1fb7-42ec-b0cd-c5acf2f08427", "db258917-72b4-48ee-8f74-e89b5417a345", "Admin", "ADMIN" },
                    { "7227a5b6-9e3b-416c-88f6-27750942c062", "c8275556-9f71-43d8-afa7-ccbea5b9c987", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a0e4292-b33c-4dab-b865-4be3303b7e7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3897aa-1fb7-42ec-b0cd-c5acf2f08427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7227a5b6-9e3b-416c-88f6-27750942c062");

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
    }
}
