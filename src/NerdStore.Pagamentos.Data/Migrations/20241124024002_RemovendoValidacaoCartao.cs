using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NerdStore.Pagamentos.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoValidacaoCartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CvvCartao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "ExpiracaoCartao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "NomeCartao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "NumeroCartao",
                table: "Pagamentos");

            migrationBuilder.AddColumn<string>(
                name: "TipoPagamento",
                table: "Pagamentos",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPagamento",
                table: "Pagamentos");

            migrationBuilder.AddColumn<string>(
                name: "CvvCartao",
                table: "Pagamentos",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ExpiracaoCartao",
                table: "Pagamentos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeCartao",
                table: "Pagamentos",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCartao",
                table: "Pagamentos",
                type: "varchar(16)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
