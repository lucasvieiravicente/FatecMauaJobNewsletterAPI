using Microsoft.EntityFrameworkCore.Migrations;

namespace FatecMauaJobNewsletter.Migrations
{
    public partial class InsertedAdmDescriptionColumnOnJobVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministrationDescription",
                table: "JobVacancies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrationDescription",
                table: "JobVacancies");
        }
    }
}
