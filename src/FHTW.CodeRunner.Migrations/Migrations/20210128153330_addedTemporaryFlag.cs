using Microsoft.EntityFrameworkCore.Migrations;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class addedTemporaryFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "temporary_flag",
                table: "exercise_version",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "temporary_flag",
                table: "exercise_version");
        }
    }
}
