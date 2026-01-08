using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAtivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivoPerfis");

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrecoAtual",
                value: 1.00m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrecoAtual",
                value: 1.05m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 3,
                column: "PrecoAtual",
                value: 520.00m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 4,
                column: "PrecoAtual",
                value: 450.00m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PrecoAtual", "Simbolo" },
                values: new object[] { 38.50m, "PETR4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtivoPerfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    NivelRisco = table.Column<int>(type: "int", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivoPerfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivoPerfis_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AtivoPerfis",
                columns: new[] { "Id", "AtivoId", "NivelRisco", "Perfil" },
                values: new object[,]
                {
                    { 1, 1, 2, 0 },
                    { 2, 2, 4, 1 },
                    { 3, 3, 6, 1 },
                    { 4, 4, 8, 2 },
                    { 5, 5, 9, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrecoAtual",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrecoAtual",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 3,
                column: "PrecoAtual",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 4,
                column: "PrecoAtual",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Ativos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PrecoAtual", "Simbolo" },
                values: new object[] { 0m, "B3" });

            migrationBuilder.CreateIndex(
                name: "IX_AtivoPerfis_AtivoId",
                table: "AtivoPerfis",
                column: "AtivoId");
        }
    }
}
