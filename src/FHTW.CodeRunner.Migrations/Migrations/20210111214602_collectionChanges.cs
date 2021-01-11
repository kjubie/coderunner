using Microsoft.EntityFrameworkCore.Migrations;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class collectionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_exercise_fk_collection_language_id_fkey",
                table: "collection_exercise");

            migrationBuilder.RenameColumn(
                name: "fk_collection_language_id",
                table: "collection_exercise",
                newName: "fk_collection_id");

            migrationBuilder.RenameIndex(
                name: "IX_collection_exercise_fk_collection_language_id",
                table: "collection_exercise",
                newName: "IX_collection_exercise_fk_collection_id");

            migrationBuilder.AddColumn<int>(
                name: "fk_written_language_id",
                table: "collection_language",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_collection_language_fk_written_language_id",
                table: "collection_language",
                column: "fk_written_language_id");

            migrationBuilder.AddForeignKey(
                name: "collection_exercise_fk_collection_id_fkey",
                table: "collection_exercise",
                column: "fk_collection_id",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_collection_language_written_language_fk_written_language_id",
                table: "collection_language",
                column: "fk_written_language_id",
                principalTable: "written_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_exercise_fk_collection_id_fkey",
                table: "collection_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_collection_language_written_language_fk_written_language_id",
                table: "collection_language");

            migrationBuilder.DropIndex(
                name: "IX_collection_language_fk_written_language_id",
                table: "collection_language");

            migrationBuilder.DropColumn(
                name: "fk_written_language_id",
                table: "collection_language");

            migrationBuilder.RenameColumn(
                name: "fk_collection_id",
                table: "collection_exercise",
                newName: "fk_collection_language_id");

            migrationBuilder.RenameIndex(
                name: "IX_collection_exercise_fk_collection_id",
                table: "collection_exercise",
                newName: "IX_collection_exercise_fk_collection_language_id");

            migrationBuilder.AddForeignKey(
                name: "collection_exercise_fk_collection_language_id_fkey",
                table: "collection_exercise",
                column: "fk_collection_language_id",
                principalTable: "collection_language",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
