using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlyTools.Infrastructure.Migrations
{
    public partial class categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kitchen Renovations" },
                    { 2, "Bathroom Renovations" },
                    { 3, "Flooring Solutions" },
                    { 4, "Interior Painting" },
                    { 5, "Exterior Upgrades" },
                    { 6, "Plumbing Fixes" },
                    { 7, "Electrical Repairs" },
                    { 8, "HVAC Maintenance" },
                    { 9, "Foundation and Structural Repairs" },
                    { 10, "DIY Home Improvement" }
                });

            migrationBuilder.InsertData(
                table: "ToolCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Power Tools" },
                    { 2, "Hand Tools" },
                    { 3, "Gardening Tools" },
                    { 4, "Woodworking Tools" },
                    { 5, "Measuring Tools" },
                    { 6, "Masonry Tool" },
                    { 7, "Other Tools" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TipCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ToolCategories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
