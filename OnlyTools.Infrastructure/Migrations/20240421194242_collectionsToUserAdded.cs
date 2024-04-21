using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    public partial class collectionsToUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "TipsAndTricks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipsAndTricks_ApplicationUserId",
                table: "TipsAndTricks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipsAndTricks_AspNetUsers_ApplicationUserId",
                table: "TipsAndTricks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipsAndTricks_AspNetUsers_ApplicationUserId",
                table: "TipsAndTricks");

            migrationBuilder.DropIndex(
                name: "IX_TipsAndTricks_ApplicationUserId",
                table: "TipsAndTricks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TipsAndTricks");
        }
    }
}
