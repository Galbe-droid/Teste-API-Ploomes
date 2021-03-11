using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Ploomes_API_PersonagemRPG.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Aparencia = table.Column<string>(nullable: true),
                    Historia = table.Column<string>(nullable: true),
                    Forca = table.Column<int>(nullable: false),
                    Agilidade = table.Column<int>(nullable: false),
                    Inteligencia = table.Column<int>(nullable: false),
                    Vitalidade = table.Column<int>(nullable: false),
                    Carisma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagem");
        }
    }
}
