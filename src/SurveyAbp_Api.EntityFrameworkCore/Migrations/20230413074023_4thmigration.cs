using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAbp_Api.Migrations
{
    public partial class _4thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Surv_Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Surv_Persons");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Surv_Persons",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surv_Persons_UserId",
                table: "Surv_Persons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surv_Persons_AbpUsers_UserId",
                table: "Surv_Persons",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surv_Persons_AbpUsers_UserId",
                table: "Surv_Persons");

            migrationBuilder.DropIndex(
                name: "IX_Surv_Persons_UserId",
                table: "Surv_Persons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Surv_Persons");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Surv_Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Surv_Persons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
