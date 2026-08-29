using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConectaTalentos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterContractTypeAndWorkModeToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkMode",
                table: "vagas",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ContractType",
                table: "vagas",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            // Converte os valores antigos (agora em texto "0","1"...) para os nomes do enum
            migrationBuilder.Sql(@"
                UPDATE vagas SET ""ContractType"" = CASE ""ContractType""
                    WHEN '0' THEN 'CLT'
                    WHEN '1' THEN 'PJ'
                    WHEN '2' THEN 'Estagio'
                    WHEN '3' THEN 'Freelancer'
                END;
            ");

            migrationBuilder.Sql(@"
                UPDATE vagas SET ""WorkMode"" = CASE ""WorkMode""
                    WHEN '0' THEN 'Remoto'
                    WHEN '1' THEN 'Presencial'
                    WHEN '2' THEN 'Híbrido'
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverte os nomes de volta para número, antes de trocar o tipo da coluna de volta pra int
            migrationBuilder.Sql(@"
                UPDATE vagas SET ""ContractType"" = CASE ""ContractType""
                    WHEN 'CLT' THEN '0'
                    WHEN 'PJ' THEN '1'
                    WHEN 'Estagio' THEN '2'
                    WHEN 'Freelancer' THEN '3'
                END;
            ");

            migrationBuilder.Sql(@"
                UPDATE vagas SET ""WorkMode"" = CASE ""WorkMode""
                    WHEN 'Remoto' THEN '0'
                    WHEN 'Presencial' THEN '1'
                    WHEN 'Híbrido' THEN '2'
                END;
            ");

            migrationBuilder.AlterColumn<int>(
                name: "WorkMode",
                table: "vagas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ContractType",
                table: "vagas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}