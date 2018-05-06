using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDemo01.Migrations
{
    public partial class CarroCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroComprasItems",
                columns: table => new
                {
                    codigoProductoSeleccionado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductosCodigoProducto = table.Column<int>(nullable: true),
                    cantidadProductoSeleccionado = table.Column<int>(nullable: false),
                    codigoCarroCompras = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroComprasItems", x => x.codigoProductoSeleccionado);
                    table.ForeignKey(
                        name: "FK_CarroComprasItems_Productos_ProductosCodigoProducto",
                        column: x => x.ProductosCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarroComprasItems_ProductosCodigoProducto",
                table: "CarroComprasItems",
                column: "ProductosCodigoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarroComprasItems");
        }
    }
}
