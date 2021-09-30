using Microsoft.EntityFrameworkCore.Migrations;

namespace AvondaleTyresOnlineShop.Migrations
{
    public partial class pdftakeone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PricechartPdfUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricechartPdfUrl",
                table: "Products");
        }
    }
}
