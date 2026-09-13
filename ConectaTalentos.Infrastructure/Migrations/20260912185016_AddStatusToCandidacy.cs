using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConectaTalentos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToCandidacy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "candidaturas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "candidaturas");
        }
    }
}
