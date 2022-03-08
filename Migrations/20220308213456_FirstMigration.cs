using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FatecMauaJobNewsletter.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobVacancies",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    JobName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    JobArea = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    JobDescription = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    ResponsiblePhoneNumber = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    ResponsibleEmail = table.Column<string>(type: "text", nullable: true),
                    StartDateJobVacancy = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDateJobVacancy = table.Column<DateTime>(type: "datetime", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true),
                    Address = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    CompanyNumber = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    JobResponsible = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdministrationStep = table.Column<int>(type: "int", nullable: false),
                    AdministrationDescription = table.Column<string>(type: "text", nullable: true),
                    UserCreated = table.Column<string>(type: "varchar(26)", maxLength: 26, nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    FlagActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Login = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    FlagActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobVacancies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
