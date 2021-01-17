using Microsoft.EntityFrameworkCore.Migrations;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class uniqueIndexesAndQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_programming_language_id",
                table: "questiontype",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_written_language_name",
                table: "written_language",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tag_name",
                table: "tag",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_questiontype_fk_programming_language_id",
                table: "questiontype",
                column: "fk_programming_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_questiontype_name",
                table: "questiontype",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_programming_language_name",
                table: "programming_language",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questiontype_programming_language_fk_programming_language_id",
                table: "questiontype",
                column: "fk_programming_language_id",
                principalTable: "programming_language",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questiontype_programming_language_fk_programming_language_id",
                table: "questiontype");

            migrationBuilder.DropIndex(
                name: "IX_written_language_name",
                table: "written_language");

            migrationBuilder.DropIndex(
                name: "IX_tag_name",
                table: "tag");

            migrationBuilder.DropIndex(
                name: "IX_questiontype_fk_programming_language_id",
                table: "questiontype");

            migrationBuilder.DropIndex(
                name: "IX_questiontype_name",
                table: "questiontype");

            migrationBuilder.DropIndex(
                name: "IX_programming_language_name",
                table: "programming_language");

            migrationBuilder.DropColumn(
                name: "fk_programming_language_id",
                table: "questiontype");
        }
    }
}
