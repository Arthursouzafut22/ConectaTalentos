using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConectaTalentos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserRoleToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleTemp",
                table: "usuarios",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.Sql("""
        UPDATE usuarios
        SET "RoleTemp" = CASE "Role"
            WHEN 1 THEN 'Candidate'
            WHEN 2 THEN 'Recruiter'
            ELSE 'Candidate'
        END;
    """);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "RoleTemp",
                table: "usuarios",
                newName: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "usuarios",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleTemp",
                table: "usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql("""
        UPDATE usuarios
        SET "RoleTemp" = CASE "Role"
            WHEN 'Candidate' THEN 1
            WHEN 'Recruiter' THEN 2
            ELSE 0
        END;
    """);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "RoleTemp",
                table: "usuarios",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "usuarios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
