using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAbp_Api.Migrations
{
    public partial class _3rdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Surv_Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Surv_Persons");

            migrationBuilder.DropColumn(
                name: "RespondantID",
                table: "Surv_Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminID",
                table: "Surv_Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Surv_Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RespondantID",
                table: "Surv_Persons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
