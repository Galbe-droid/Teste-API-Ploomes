using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Ploomes_API_PersonagemRPG.Data.Migrations
{
    public partial class Fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mana",
                table: "Personagem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAtributos",
                table: "Personagem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vida",
                table: "Personagem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mana",
                table: "Personagem");

            migrationBuilder.DropColumn(
                name: "TotalAtributos",
                table: "Personagem");

            migrationBuilder.DropColumn(
                name: "Vida",
                table: "Personagem");
        }
    }
}
