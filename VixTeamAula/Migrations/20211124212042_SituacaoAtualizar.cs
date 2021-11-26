using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VixTeamAula.Migrations
{
    public partial class SituacaoAtualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Situacao",
                table: "PessoaModel",
                type: "bit",
                nullable: true,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "PessoaModel");
        }
    }
}
