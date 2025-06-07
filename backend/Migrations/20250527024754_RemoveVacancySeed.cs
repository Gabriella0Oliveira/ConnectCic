using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace connect_cic_api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVacancySeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "VacancyID", "Description", "EndDate", "ProfessorID", "ProjectTitle", "Requirements", "StartDate", "Status", "VacancyTypeID", "Value" },
                values: new object[,]
                {
                    { 1, "Teste de vaga atual", new DateTime(2025, 6, 25, 23, 42, 38, 906, DateTimeKind.Local).AddTicks(8130), 1, "Projeto teste de vaga", "Teste de vaga atual", new DateTime(2025, 5, 26, 23, 42, 38, 904, DateTimeKind.Local).AddTicks(3087), "Aberta", 1, 0f },
                    { 2, "Teste de vaga antiga", new DateTime(2025, 5, 16, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(636), 1, "Projeto teste de vaga", "Teste de vaga antiga", new DateTime(2025, 4, 6, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(628), "Fechada", 1, 0f },
                    { 3, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 5, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(640), 2, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(639), "Aberta", 1, 1000f },
                    { 4, "Desenvolvimento de aplicação web", new DateTime(2025, 7, 5, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(642), 3, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(642), "Aberta", 1, 1000f },
                    { 5, "Desenvolvimento de aplicação web", new DateTime(2025, 5, 26, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(645), 4, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 16, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(644), "Aberta", 2, 1000f },
                    { 6, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 25, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(647), 2, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 16, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(646), "Aberta", 3, 700f },
                    { 7, "Desenvolvimento de aplicação web", new DateTime(2025, 7, 5, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(649), 3, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(649), "Aberta", 4, 0f },
                    { 8, "Desenvolvimento de aplicação web", new DateTime(2025, 6, 5, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(652), 4, "Sistema de gerenciamento de vendas", "Conhecimento em Java", new DateTime(2025, 5, 26, 23, 42, 38, 907, DateTimeKind.Local).AddTicks(651), "Aberta", 5, 1000f }
                });
        }
    }
}
