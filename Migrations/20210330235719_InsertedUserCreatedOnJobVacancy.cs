using Microsoft.EntityFrameworkCore.Migrations;

namespace FatecMauaJobNewsletter.Migrations
{
    public partial class InsertedUserCreatedOnJobVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCreated",
                table: "JobVacancies",
                type: "nvarchar(26)",
                maxLength: 26,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "JobVacancies");
        }
    }
}
