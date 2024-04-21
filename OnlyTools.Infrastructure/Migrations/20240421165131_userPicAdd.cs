using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    public partial class userPicAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                comment: "profile picture, stored as a byte array, optional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");
        }
    }
}
