using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    public partial class cat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_JobListingCategories_JobListingCategoryId",
                table: "JobListings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_TipCategories_CategoryId",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_JobListingCategoryId",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "JobListingCategoryId",
                table: "JobListings");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_JobListingCategories_CategoryId",
                table: "JobListings",
                column: "CategoryId",
                principalTable: "JobListingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_JobListingCategories_CategoryId",
                table: "JobListings");

            migrationBuilder.AddColumn<int>(
                name: "JobListingCategoryId",
                table: "JobListings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_JobListingCategoryId",
                table: "JobListings",
                column: "JobListingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_JobListingCategories_JobListingCategoryId",
                table: "JobListings",
                column: "JobListingCategoryId",
                principalTable: "JobListingCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobListings_TipCategories_CategoryId",
                table: "JobListings",
                column: "CategoryId",
                principalTable: "TipCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
