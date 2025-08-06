using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace connect_cic_api.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileEmbeddingToStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileEmbedding",
                table: "Students",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileEmbedding",
                table: "Students");
        }
    }
}
