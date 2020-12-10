using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FHTW.CodeRunner.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exercise_header",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    full_title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    introduction = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_header", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programming_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programming_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reg_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "test_suite",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    question_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    template_debug_flag = table.Column<bool>(type: "boolean", nullable: false),
                    test_on_save_flag = table.Column<bool>(type: "boolean", nullable: false),
                    global_extra_param = table.Column<string>(type: "text", nullable: true),
                    runtime_data = table.Column<string>(type: "text", nullable: true),
                    template_param = table.Column<string>(type: "text", nullable: true),
                    template_param_lift_flag = table.Column<bool>(type: "boolean", nullable: false),
                    twig_all_flag = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_suite", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "written_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_written_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "collection",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection", x => x.id);
                    table.ForeignKey(
                        name: "collection_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise", x => x.id);
                    table.ForeignKey(
                        name: "exercise_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "test_case",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    order_used = table.Column<int>(type: "integer", nullable: true),
                    test_code = table.Column<string>(type: "text", nullable: true),
                    standard_input = table.Column<string>(type: "text", nullable: true),
                    expected_output = table.Column<string>(type: "text", nullable: true),
                    additional_data = table.Column<string>(type: "text", nullable: true),
                    points = table.Column<int>(type: "integer", nullable: true),
                    fk_test_suite_id = table.Column<int>(type: "integer", nullable: false),
                    use_as_example_flag = table.Column<bool>(type: "boolean", nullable: false),
                    hide_on_fail_flag = table.Column<bool>(type: "boolean", nullable: false),
                    display_type = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_case", x => x.id);
                    table.ForeignKey(
                        name: "test_case_fk_test_suite_id_fkey",
                        column: x => x.fk_test_suite_id,
                        principalTable: "test_suite",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "collection_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    full_title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    short_title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    introduction = table.Column<string>(type: "text", nullable: true),
                    fk_collection_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_language", x => x.id);
                    table.ForeignKey(
                        name: "collection_language_fk_collection_id_fkey",
                        column: x => x.fk_collection_id,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "collection_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    fk_tag_id = table.Column<int>(type: "integer", nullable: false),
                    fk_collection_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_tag", x => x.id);
                    table.ForeignKey(
                        name: "collection_tag_fk_collection_id_fkey",
                        column: x => x.fk_collection_id,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_tag_fk_tag_id_fkey",
                        column: x => x.fk_tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "comment_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "comment_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "difficulty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_difficulty", x => x.id);
                    table.ForeignKey(
                        name: "difficulty_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "difficulty_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    fk_tag_id = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_tag", x => x.id);
                    table.ForeignKey(
                        name: "exercise_tag_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_tag_fk_tag_id_fkey",
                        column: x => x.fk_tag_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_version",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    version_number = table.Column<int>(type: "integer", nullable: false),
                    creator_rating = table.Column<int>(type: "integer", nullable: true),
                    creator_difficulty = table.Column<int>(type: "integer", nullable: true),
                    last_modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_version", x => x.id);
                    table.ForeignKey(
                        name: "exercise_version_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_version_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                    table.ForeignKey(
                        name: "rating_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "rating_fk_user_id_fkey",
                        column: x => x.fk_user_id,
                        principalTable: "reg_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "collection_exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    fk_collection_language_id = table.Column<int>(type: "integer", nullable: false),
                    version_number = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_id = table.Column<int>(type: "integer", nullable: false),
                    fk_programming_language_id = table.Column<int>(type: "integer", nullable: false),
                    fk_written_language_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_exercise", x => x.id);
                    table.ForeignKey(
                        name: "collection_exercise_fk_collection_language_id_fkey",
                        column: x => x.fk_collection_language_id,
                        principalTable: "collection_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_exercise_fk_exercise_id_fkey",
                        column: x => x.fk_exercise_id,
                        principalTable: "exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_exercise_fk_programming_language_id_fkey",
                        column: x => x.fk_programming_language_id,
                        principalTable: "programming_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_exercise_fk_written_language_id_fkey",
                        column: x => x.fk_written_language_id,
                        principalTable: "written_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_language",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    fk_written_language_id = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_version_id = table.Column<int>(type: "integer", nullable: false),
                    fk_exercise_header_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_language", x => x.id);
                    table.ForeignKey(
                        name: "exercise_language_fk_exercise_header_id_fkey",
                        column: x => x.fk_exercise_header_id,
                        principalTable: "exercise_header",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_language_fk_exercise_version_id_fkey",
                        column: x => x.fk_exercise_version_id,
                        principalTable: "exercise_version",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_language_fk_written_language_id_fkey",
                        column: x => x.fk_written_language_id,
                        principalTable: "written_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_body",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    fk_programming_language_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    hint = table.Column<string>(type: "text", nullable: true),
                    fk_exercise_language_id = table.Column<int>(type: "integer", nullable: false),
                    fk_test_suite_id = table.Column<int>(type: "integer", nullable: false),
                    field_lines = table.Column<int>(type: "integer", nullable: false),
                    grading_flag = table.Column<bool>(type: "boolean", nullable: false),
                    substract_system = table.Column<string>(type: "text", nullable: true),
                    optainable_points = table.Column<int>(type: "integer", nullable: false),
                    id_num = table.Column<int>(type: "integer", nullable: false),
                    solution = table.Column<string>(type: "text", nullable: true),
                    prefill = table.Column<string>(type: "text", nullable: true),
                    feedback = table.Column<string>(type: "text", nullable: true),
                    allow_files = table.Column<int>(type: "integer", nullable: false),
                    files_required = table.Column<int>(type: "integer", nullable: false),
                    files_regex = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    files_description = table.Column<string>(type: "text", nullable: true),
                    files_size = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_body", x => x.id);
                    table.CheckConstraint("value_constraint_exercise_allow_files", "allow_files >= 0 AND allow_files <= 4");
                    table.CheckConstraint("value_constraint_exercise_files_required", "files_required >= 0 AND files_required <= 3");
                    table.ForeignKey(
                        name: "exercise_body_fk_exercise_language_id_fkey",
                        column: x => x.fk_exercise_language_id,
                        principalTable: "exercise_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_body_fk_programming_language_id_fkey",
                        column: x => x.fk_programming_language_id,
                        principalTable: "programming_language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "exercise_body_fk_test_suite_id_fkey",
                        column: x => x.fk_test_suite_id,
                        principalTable: "test_suite",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collection_fk_user_id",
                table: "collection",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_exercise_fk_collection_language_id",
                table: "collection_exercise",
                column: "fk_collection_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_exercise_fk_exercise_id",
                table: "collection_exercise",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_exercise_fk_programming_language_id",
                table: "collection_exercise",
                column: "fk_programming_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_exercise_fk_written_language_id",
                table: "collection_exercise",
                column: "fk_written_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_language_fk_collection_id",
                table: "collection_language",
                column: "fk_collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_tag_fk_collection_id",
                table: "collection_tag",
                column: "fk_collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_tag_fk_tag_id",
                table: "collection_tag",
                column: "fk_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_fk_exercise_id",
                table: "comment",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_fk_user_id",
                table: "comment",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_difficulty_fk_exercise_id",
                table: "difficulty",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_difficulty_fk_user_id",
                table: "difficulty",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_fk_user_id",
                table: "exercise",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_body_fk_exercise_language_id",
                table: "exercise_body",
                column: "fk_exercise_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_body_fk_programming_language_id",
                table: "exercise_body",
                column: "fk_programming_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_body_fk_test_suite_id",
                table: "exercise_body",
                column: "fk_test_suite_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_language_fk_exercise_header_id",
                table: "exercise_language",
                column: "fk_exercise_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_language_fk_exercise_version_id",
                table: "exercise_language",
                column: "fk_exercise_version_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_language_fk_written_language_id",
                table: "exercise_language",
                column: "fk_written_language_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_tag_fk_exercise_id",
                table: "exercise_tag",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_tag_fk_tag_id",
                table: "exercise_tag",
                column: "fk_tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_version_fk_exercise_id",
                table: "exercise_version",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_version_fk_user_id",
                table: "exercise_version",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_fk_exercise_id",
                table: "rating",
                column: "fk_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_rating_fk_user_id",
                table: "rating",
                column: "fk_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reg_user_name",
                table: "reg_user",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_test_case_fk_test_suite_id",
                table: "test_case",
                column: "fk_test_suite_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collection_exercise");

            migrationBuilder.DropTable(
                name: "collection_tag");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "difficulty");

            migrationBuilder.DropTable(
                name: "exercise_body");

            migrationBuilder.DropTable(
                name: "exercise_tag");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "test_case");

            migrationBuilder.DropTable(
                name: "collection_language");

            migrationBuilder.DropTable(
                name: "exercise_language");

            migrationBuilder.DropTable(
                name: "programming_language");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropTable(
                name: "test_suite");

            migrationBuilder.DropTable(
                name: "collection");

            migrationBuilder.DropTable(
                name: "exercise_header");

            migrationBuilder.DropTable(
                name: "exercise_version");

            migrationBuilder.DropTable(
                name: "written_language");

            migrationBuilder.DropTable(
                name: "exercise");

            migrationBuilder.DropTable(
                name: "reg_user");
        }
    }
}
