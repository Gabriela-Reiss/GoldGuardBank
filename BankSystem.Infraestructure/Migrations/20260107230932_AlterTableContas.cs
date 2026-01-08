using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankSystem.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableContas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Simbolo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    PrecoAtual = table.Column<decimal>(type: "decimal(20,2)", precision: 20, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtivoPerfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    NivelRisco = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NumeroConta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    AtivoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investimentos_Ativos_AtivoId",
                        column: x => x.AtivoId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investimentos_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ativos",
                columns: new[] { "Id", "Nome", "PrecoAtual", "Simbolo", "Tipo" },
                values: new object[,]
                {
                    { 1, "Tesouro Selic", 0m, "SELIC", 0 },
                    { 2, "Tesouro IPCA+", 0m, "IPCA", 0 },
                    { 3, "ETF S&P 500", 0m, "SPY", 2 },
                    { 4, "ETF Nasdaq 100", 0m, "QQQ", 2 },
                    { 5, "Ações Brasileiras", 0m, "B3", 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_AtivoPerfis_AtivoId",
                table: "AtivoPerfis",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_NumeroConta",
                table: "Contas",
                column: "NumeroConta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_UsuarioId",
                table: "Contas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_AtivoId",
                table: "Investimentos",
                column: "AtivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_ContaId",
                table: "Investimentos",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_CPF",
                table: "Logins",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UsuarioId",
                table: "Logins",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaId",
                table: "Transacoes",
                column: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivoPerfis");

            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
