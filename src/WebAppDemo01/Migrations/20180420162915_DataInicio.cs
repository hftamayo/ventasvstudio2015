using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDemo01.Migrations
{
    public partial class DataInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProductos",
                columns: table => new
                {
                    CodigoCatProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionCatProducto = table.Column<string>(nullable: true),
                    NombreCatProducto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProductos", x => x.CodigoCatProducto);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatProductosCodigoCatProducto = table.Column<int>(nullable: true),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    DescripCortaProducto = table.Column<string>(nullable: true),
                    DescripLargaProducto = table.Column<string>(nullable: true),
                    DescripProducto = table.Column<string>(nullable: true),
                    EstadoProducto = table.Column<bool>(nullable: false),
                    ImagenPreviaURL = table.Column<string>(nullable: true),
                    ImagenURL = table.Column<string>(nullable: true),
                    NombreProducto = table.Column<string>(nullable: true),
                    PreCostoProducto = table.Column<decimal>(nullable: false),
                    PreVentaProducto = table.Column<decimal>(nullable: false),
                    ProductoEnExistencia = table.Column<bool>(nullable: false),
                    ProductoEnOferta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriasProductos_CatProductosCodigoCatProducto",
                        column: x => x.CatProductosCodigoCatProducto,
                        principalTable: "CategoriasProductos",
                        principalColumn: "CodigoCatProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CatProductosCodigoCatProducto",
                table: "Productos",
                column: "CatProductosCodigoCatProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "CategoriasProductos");
        }
    }
}
