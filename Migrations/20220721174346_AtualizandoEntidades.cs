using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GftPetCare.Migrations
{
    public partial class AtualizandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Animais");

            migrationBuilder.AddColumn<int>(
                name: "AnoDeNascimento",
                table: "Animais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Animais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoDeNascimento",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Animais");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Animais",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
