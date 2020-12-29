using Microsoft.EntityFrameworkCore.Migrations;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class Restructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "template_param",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "template_param_lift_flag",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "twig_all_flag",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "valid_flag",
                table: "exercise_version");

            migrationBuilder.RenameColumn(
                name: "optainable_points",
                table: "exercise_body",
                newName: "obtainable_points");

            migrationBuilder.AddColumn<int>(
                name: "feedback_display",
                table: "test_suite",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "precheck",
                table: "test_suite",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valid_state",
                table: "exercise_version",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "template_param",
                table: "exercise_header",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "template_param_lift_flag",
                table: "exercise_header",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "twig_all_flag",
                table: "exercise_header",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "feedback_display",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "precheck",
                table: "test_suite");

            migrationBuilder.DropColumn(
                name: "valid_state",
                table: "exercise_version");

            migrationBuilder.DropColumn(
                name: "template_param",
                table: "exercise_header");

            migrationBuilder.DropColumn(
                name: "template_param_lift_flag",
                table: "exercise_header");

            migrationBuilder.DropColumn(
                name: "twig_all_flag",
                table: "exercise_header");

            migrationBuilder.RenameColumn(
                name: "obtainable_points",
                table: "exercise_body",
                newName: "optainable_points");

            migrationBuilder.AddColumn<string>(
                name: "template_param",
                table: "test_suite",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "template_param_lift_flag",
                table: "test_suite",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "twig_all_flag",
                table: "test_suite",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "valid_flag",
                table: "exercise_version",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
