using Microsoft.EntityFrameworkCore.Migrations;

namespace GftPetCare.Migrations
{
    public partial class AtualizandoEntidadeAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinalizado",
                table: "Atendimentos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinalizado",
                table: "Atendimentos");
        }
    }
}
