using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAbp_Api.Migrations
{
    public partial class _7thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Surv_Persons_PersonId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Products_ProductId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Questions",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ProductId",
                table: "Questions",
                newName: "IX_Questions_SurveyId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Answers",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_PersonId",
                table: "Answers",
                newName: "IX_Answers_SurveyId");

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Surveys_Surv_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Surv_Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PersonId",
                table: "Surveys",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_ProductId",
                table: "Surveys",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Surveys_SurveyId",
                table: "Answers",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Surveys_SurveyId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "Questions",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                newName: "IX_Questions_ProductId");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "Answers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_SurveyId",
                table: "Answers",
                newName: "IX_Answers_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Surv_Persons_PersonId",
                table: "Answers",
                column: "PersonId",
                principalTable: "Surv_Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Products_ProductId",
                table: "Questions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
