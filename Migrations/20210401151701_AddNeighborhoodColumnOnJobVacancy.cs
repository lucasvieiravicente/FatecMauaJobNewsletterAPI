using Microsoft.EntityFrameworkCore.Migrations;

namespace FatecMauaJobNewsletter.Migrations
{
    public partial class AddNeighborhoodColumnOnJobVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "JobVacancies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "JobVacancies");
        }
    }
}
