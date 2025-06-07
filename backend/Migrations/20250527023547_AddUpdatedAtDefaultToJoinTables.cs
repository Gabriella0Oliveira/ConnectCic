using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace connect_cic_api.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtDefaultToJoinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(6041), new DateTime(2025, 5, 26, 23, 35, 46, 227, DateTimeKind.Local).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 16, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9724), new DateTime(2025, 4, 6, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 5, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9728), new DateTime(2025, 5, 26, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9727) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 7, 5, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9730), new DateTime(2025, 5, 26, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 26, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9732), new DateTime(2025, 5, 16, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9734), new DateTime(2025, 5, 16, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 7, 5, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9738), new DateTime(2025, 5, 26, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 5, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9740), new DateTime(2025, 5, 26, 23, 35, 46, 229, DateTimeKind.Local).AddTicks(9739) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(6799), new DateTime(2025, 5, 26, 23, 23, 39, 209, DateTimeKind.Local).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 16, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8570), new DateTime(2025, 4, 6, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8564) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 5, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8574), new DateTime(2025, 5, 26, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8574) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 7, 5, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8576), new DateTime(2025, 5, 26, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8576) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 5, 26, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8578), new DateTime(2025, 5, 16, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8578) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 25, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8580), new DateTime(2025, 5, 16, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8580) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 7, 5, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8582), new DateTime(2025, 5, 26, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "VacancyID",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 6, 5, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8584), new DateTime(2025, 5, 26, 23, 23, 39, 212, DateTimeKind.Local).AddTicks(8584) });
        }
    }
}
