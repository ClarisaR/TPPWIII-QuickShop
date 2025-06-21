using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Productos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaDireccionYRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Locales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Locales",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locales_DireccionId",
                table: "Locales",
                column: "DireccionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Direccion_DireccionId",
                table: "Locales",
                column: "DireccionId",
                principalTable: "Direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Direccion_DireccionId",
                table: "Locales");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Locales_DireccionId",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Locales");
        }
    }
}
