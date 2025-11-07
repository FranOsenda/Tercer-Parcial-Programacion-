using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tercer_Parcial_Osenda_Francisco.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentaID",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaID",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "ProductoVenta",
                columns: table => new
                {
                    ProductosID = table.Column<int>(type: "int", nullable: false),
                    VentaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVenta", x => new { x.ProductosID, x.VentaID });
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Productos_ProductosID",
                        column: x => x.ProductosID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Ventas_VentaID",
                        column: x => x.VentaID,
                        principalTable: "Ventas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVenta_VentaID",
                table: "ProductoVenta",
                column: "VentaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaID",
                table: "Productos",
                column: "VentaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentaID",
                table: "Productos",
                column: "VentaID",
                principalTable: "Ventas",
                principalColumn: "ID");
        }
    }
}
