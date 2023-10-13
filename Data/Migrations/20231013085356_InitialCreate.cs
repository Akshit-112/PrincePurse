using Microsoft.EntityFrameworkCore.Migrations;

namespace PrincePurse.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 60, nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Materials = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Availability = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purse");
        }
    }
}
