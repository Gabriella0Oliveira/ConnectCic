using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace connect_cic_api.Migrations
{
    /// <inheritdoc />
    public partial class AddAreasAndDisciplines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false),
                    Syllabus = table.Column<string>(type: "TEXT", nullable: false),
                    Objectives = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorID = table.Column<int>(type: "INTEGER", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Rules = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "VacancyTypes",
                columns: table => new
                {
                    VacancyTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyTypes", x => x.VacancyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.ProfessorID);
                    table.ForeignKey(
                        name: "FK_Professors_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Course = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CRAA = table.Column<float>(type: "REAL", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    VacancyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<float>(type: "REAL", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Requirements = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    ProfessorID = table.Column<int>(type: "INTEGER", nullable: false),
                    VacancyTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.VacancyID);
                    table.ForeignKey(
                        name: "FK_Vacancies_Professors_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professors",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_VacancyTypes_VacancyTypeID",
                        column: x => x.VacancyTypeID,
                        principalTable: "VacancyTypes",
                        principalColumn: "VacancyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAreas",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAreas", x => new { x.StudentId, x.AreaId });
                    table.ForeignKey(
                        name: "FK_StudentAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAreas_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDisciplines",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<decimal>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDisciplines", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDisciplines_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentVacancy",
                columns: table => new
                {
                    StudentsStudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    VacanciesVacancyID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentVacancy", x => new { x.StudentsStudentID, x.VacanciesVacancyID });
                    table.ForeignKey(
                        name: "FK_StudentVacancy_Students_StudentsStudentID",
                        column: x => x.StudentsStudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentVacancy_Vacancies_VacanciesVacancyID",
                        column: x => x.VacanciesVacancyID,
                        principalTable: "Vacancies",
                        principalColumn: "VacancyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "ProfessorID", "Department", "Email", "Name", "UserID" },
                values: new object[,]
                {
                    { 1, "DCET", "professor.cic@uesc.br", "Professor Teste", null },
                    { 2, "DCET", "helder@uesc.com", "Helder", null },
                    { 3, "DCET", "martinha@uesc.com", "Martha", null },
                    { 4, "DCET", "bravo@uesc.com", "Bravo", null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "CRAA", "Course", "Description", "Email", "Name", "Status", "UserID" },
                values: new object[,]
                {
                    { 1, 9f, "Ciencia da Computação", null, "aluno.cic@uesc.br", "Aluno teste", "Cursando", null },
                    { 2, 9f, "Ciencia da Computação", null, "everaldina@gmail.com", "Everaldina Barbosa", "Cursando", null },
                    { 3, 9f, "Ciencia da Computação", null, "lavinia@gmail.com", "Lavinia", "Cursando", null },
                    { 4, 9f, "Ciencia da Computação", null, "ana_cristina@gmail.com", "ana cristina", "Cursando", null },
                    { 5, 9f, "Ciencia da Computação", null, "gabie@gmail.com", "gabie", "Cursando", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Login", "Password", "ProfessorID", "Rules", "StudentID" },
                values: new object[,]
                {
                    { 1, "admin", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", null, 0, null },
                    { 2, "professor", "17c1532ca6cff8f6a3a8200028af6c2580bf37f39e10cb0966e8a573e3b24a1f", 1, 1, null },
                    { 3, "student", "264c8c381bf16c982a4e59b0dd4c6f7808c51a05f64c35db42cc78a2a72875bb", null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "VacancyTypes",
                columns: new[] { "VacancyTypeID", "Name" },
                values: new object[,]
                {
                    { 1, "Estágio" },
                    { 2, "Iniciação Cientifica" },
                    { 3, "Iniciação a docencia" },
                    { 4, "TCC" },
                    { 5, "Projeto de Extensão" }
                });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "VacancyID", "Description", "EndDate", "ProfessorID", "ProjectTitle", "Requirements", "StartDate", "Status", "VacancyTypeID", "Value" },
                values: new object[,]
                {
                    { 1, "Teste de vaga atual", new DateTime(2025, 6, 25, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(36), 1, "Projeto teste de vaga", "Teste de vaga atual", new DateTime(2025, 5, 26, 23, 21, 12, 333, DateTimeKind.Local).AddTicks(4089), "Aberta", 1, 0f },
                    { 2, "Teste de vaga antiga", new DateTime(2025, 5, 16, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2197), 1, "Projeto teste de vaga", "Teste de vaga antiga", new DateTime(2025, 4, 6, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2189), "Fechada", 1, 0f },
                    { 3, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 5, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2200), 2, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2200), "Aberta", 1, 1000f },
                    { 4, "Desenvolvimento de aplicação web", new DateTime(2025, 7, 5, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2207), 3, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2202), "Aberta", 1, 1000f },
                    { 5, "Desenvolvimento de aplicação web", new DateTime(2025, 5, 26, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2209), 4, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 16, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2209), "Aberta", 2, 1000f },
                    { 6, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 25, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2211), 2, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 16, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2211), "Aberta", 3, 700f },
                    { 7, "Desenvolvimento de aplicação web", new DateTime(2025, 7, 5, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2213), 3, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2213), "Aberta", 4, 0f },
                    { 8, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 5, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2216), 4, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 21, 12, 336, DateTimeKind.Local).AddTicks(2215), "Aberta", 5, 1000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserID",
                table: "Professors",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAreas_AreaId",
                table: "StudentAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplines_DisciplineId",
                table: "StudentDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentVacancy_VacanciesVacancyID",
                table: "StudentVacancy",
                column: "VacanciesVacancyID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ProfessorID",
                table: "Vacancies",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_VacancyTypeID",
                table: "Vacancies",
                column: "VacancyTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAreas");

            migrationBuilder.DropTable(
                name: "StudentDisciplines");

            migrationBuilder.DropTable(
                name: "StudentVacancy");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "VacancyTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
