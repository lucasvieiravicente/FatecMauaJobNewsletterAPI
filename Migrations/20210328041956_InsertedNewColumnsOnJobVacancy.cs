using Microsoft.EntityFrameworkCore.Migrations;

namespace FatecMauaJobNewsletter.Migrations
{
    public partial class InsertedNewColumnsOnJobVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "JobVacancies",
                newName: "ResponsiblePhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "JobVacancies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "AdministrationStep",
                table: "JobVacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleEmail",
                table: "JobVacancies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrationStep",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "ResponsibleEmail",
                table: "JobVacancies");

            migrationBuilder.RenameColumn(
                name: "ResponsiblePhoneNumber",
                table: "JobVacancies",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "JobVacancies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
