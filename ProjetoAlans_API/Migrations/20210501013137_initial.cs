using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAlans_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    escala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custoDia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "custoDia", "escala", "nome" },
                values: new object[,]
                {
                    { 1, 200.0, "5x2", "Marta" },
                    { 2, 300.0, "12x36", "Paula" },
                    { 3, 500.0, "6x1", "Laura" },
                    { 4, 150.0, "5x2", "Luiza" },
                    { 5, 50.0, "12x36", "Lucas" },
                    { 6, 60.0, "6x1", "Pedro" },
                    { 7, 75.0, "12x36", "Paulo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
