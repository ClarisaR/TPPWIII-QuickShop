using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Productos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaRelacionVarianteColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Rubros_RubroId1",
                table: "Locales");

            migrationBuilder.DropIndex(
                name: "IX_Locales_RubroId1",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "RubroId1",
                table: "Locales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RubroId1",
                table: "Locales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locales_RubroId1",
                table: "Locales",
                column: "RubroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Rubros_RubroId1",
                table: "Locales",
                column: "RubroId1",
                principalTable: "Rubros",
                principalColumn: "Id");
        }
    }
}
