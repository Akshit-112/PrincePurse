using Microsoft.EntityFrameworkCore.Migrations;

namespace PrincePurse.Data.Migrations
{
    public partial class CustomerRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CustomerRating",
                table: "Purse",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerRating",
                table: "Purse");
        }
    }
}
