using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaCamisas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesCamisa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeEstoque",
                table: "Camisas");

            migrationBuilder.AlterColumn<string>(
                name: "Temporada",
                table: "Camisas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Temporada",
                table: "Camisas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstoque",
                table: "Camisas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
