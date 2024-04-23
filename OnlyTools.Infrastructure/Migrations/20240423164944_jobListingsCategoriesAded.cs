using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    public partial class jobListingsCategoriesAded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobListings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Category unique identifier, integer representation");

            migrationBuilder.AddColumn<bool>(
                name: "IsServiceOffered",
                table: "JobListings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicates if the listing is for offering a service or looking for handyman");

            migrationBuilder.AddColumn<int>(
                name: "JobListingCategoryId",
                table: "JobListings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobListingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "unique integer category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name, string representation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListingCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "JobListingCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electrical" },
                    { 2, "Plumbing" },
                    { 3, "HVAC Systems:" },
                    { 4, "Interior Renovations" },
                    { 5, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobListings_CategoryId",
                table: "JobListings",
                column: "CategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_JobListingCategories_JobListingCategoryId",
                table: "JobListings");

            migrationBuilder.DropForeignKey(
                name: "FK_JobListings_TipCategories_CategoryId",
                table: "JobListings");

            migrationBuilder.DropTable(
                name: "JobListingCategories");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_CategoryId",
                table: "JobListings");

            migrationBuilder.DropIndex(
                name: "IX_JobListings_JobListingCategoryId",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "IsServiceOffered",
                table: "JobListings");

            migrationBuilder.DropColumn(
                name: "JobListingCategoryId",
                table: "JobListings");
        }
    }
}
