using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StARKS.Data.Migrations
{
    public partial class ChangedMarkToMarkValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseCode = table.Column<int>(nullable: false),
                    MarkValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarksForStudent", x => new { x.StudentId, x.CourseCode });
                    table.ForeignKey(
                        name: "FK_Mark_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_CourseCode",
                table: "Mark",
                column: "CourseCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseCode = table.Column<int>(nullable: false),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarksForStudent", x => new { x.StudentId, x.CourseCode });
                    table.ForeignKey(
                        name: "FK_Marks_Courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Courses",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_CourseCode",
                table: "Marks",
                column: "CourseCode");
        }
    }
}
