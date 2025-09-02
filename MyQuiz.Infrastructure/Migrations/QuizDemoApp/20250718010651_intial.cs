using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyQuiz.Infrastructure.Migrations.QuizDemoApp
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Operation");

            migrationBuilder.CreateTable(
                name: "Lk_Question",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SysCodeQuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    SysCodeQuestionLevelId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lk_Quiz",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk_Quiz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lk_QuizQuestion",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lk_QuizQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoice",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoisName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemCodeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemCodeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemCodeTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCodeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tr_QuizStudent",
                schema: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tr_QuizStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemCodeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemCodes_SystemCodeTypes_SystemCodeTypeId",
                        column: x => x.SystemCodeTypeId,
                        principalTable: "SystemCodeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SystemCodeTypes",
                columns: new[] { "Id", "SystemCodeTypeDescription", "SystemCodeTypeName" },
                values: new object[,]
                {
                    { 1, "Question Level Simple medium or Hard", "Question Level" },
                    { 2, "Question Type ", "Question Type" }
                });

            migrationBuilder.InsertData(
                table: "SystemCodes",
                columns: new[] { "Id", "SystemCodeName", "SystemCodeTypeId" },
                values: new object[,]
                {
                    { 1, "Basic", 1 },
                    { 2, "Intermediate", 1 },
                    { 3, "Advanced", 1 },
                    { 4, "True Or False", 2 },
                    { 5, "Single Choice", 2 },
                    { 6, "Multi Choice", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemCodes_SystemCodeTypeId",
                table: "SystemCodes",
                column: "SystemCodeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lk_Question",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Lk_Quiz",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "Lk_QuizQuestion",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "QuestionChoice",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "SystemCodes");

            migrationBuilder.DropTable(
                name: "Tr_QuizStudent",
                schema: "Operation");

            migrationBuilder.DropTable(
                name: "SystemCodeTypes");
        }
    }
}
