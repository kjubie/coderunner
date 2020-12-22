using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class AddedQuestionTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "question_type",
                table: "test_suite");

            migrationBuilder.AddColumn<int>(
                name: "fk_question_type_id",
                table: "test_suite",
                type: "integer",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "questiontype",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questiontype", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_test_suite_fk_question_type_id",
                table: "test_suite",
                column: "fk_question_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_test_suite_questiontype_fk_question_type_id",
                table: "test_suite",
                column: "fk_question_type_id",
                principalTable: "questiontype",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_suite_questiontype_fk_question_type_id",
                table: "test_suite");

            migrationBuilder.DropTable(
                name: "questiontype");

            migrationBuilder.DropIndex(
                name: "IX_test_suite_fk_question_type_id",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "fk_question_type_id",
                table: "test_suite");

            migrationBuilder.AddColumn<string>(
                name: "question_type",
                table: "test_suite",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
