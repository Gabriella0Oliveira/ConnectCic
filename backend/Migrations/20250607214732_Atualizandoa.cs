using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace connect_cic_api.Migrations
{
    /// <inheritdoc />
    public partial class Atualizandoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Students");

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
        }
    }
}
