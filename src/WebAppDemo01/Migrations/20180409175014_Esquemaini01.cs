using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDemo01.Migrations
{
    public partial class Esquemaini01 : Migration
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
                    DescripProducto = table.Column<string>(nullable: true),
                    EstadoProducto = table.Column<bool>(nullable: false),
                    NombreProducto = table.Column<string>(nullable: true),
                    PreCostoProducto = table.Column<decimal>(nullable: false),
                    PreVentaProducto = table.Column<decimal>(nullable: false)
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
