using Microsoft.EntityFrameworkCore.Migrations;

namespace Raposa.Lanches.DataBase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LancheIngredientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LancheId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancheIngredientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LancheIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancheIngredientes_Lanches_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Lanches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "ID", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, "Hamburguer", 4.5m },
                    { 2, "Pão", 4.75m },
                    { 3, "Queijo", 4m },
                    { 4, "Tomate", 1m },
                    { 5, "Alface", 1m },
                    { 6, "Bacon", 4m },
                    { 7, "Ovo", 2m },
                    { 8, "Cebola Roxa", 1m },
                    { 9, "Pão australiano", 5m }
                });

            migrationBuilder.InsertData(
                table: "Lanches",
                columns: new[] { "ID", "Nome" },
                values: new object[,]
                {
                    { 1, "x-salada" },
                    { 2, "x-salada bacon" },
                    { 3, "x-egg" },
                    { 4, "duplo bacon" }
                });

            migrationBuilder.InsertData(
                table: "LancheIngredientes",
                columns: new[] { "ID", "IngredienteId", "LancheId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 15, 2, 4 },
                    { 14, 1, 4 },
                    { 13, 1, 4 },
                    { 12, 7, 3 },
                    { 11, 2, 3 },
                    { 10, 1, 3 },
                    { 16, 3, 4 },
                    { 9, 6, 2 },
                    { 7, 4, 2 },
                    { 6, 2, 2 },
                    { 5, 1, 2 },
                    { 4, 5, 1 },
                    { 3, 4, 1 },
                    { 2, 2, 1 },
                    { 8, 5, 2 },
                    { 17, 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancheIngredientes_IngredienteId",
                table: "LancheIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LancheIngredientes_LancheId",
                table: "LancheIngredientes",
                column: "LancheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancheIngredientes");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Lanches");
        }
    }
}
