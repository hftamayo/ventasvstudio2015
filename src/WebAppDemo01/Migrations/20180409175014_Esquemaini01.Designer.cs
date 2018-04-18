using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebAppDemo01.models;

namespace WebAppDemo01.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180409175014_Esquemaini01")]
    partial class Esquemaini01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppDemo01.models.CatProductos", b =>
                {
                    b.Property<int>("CodigoCatProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionCatProducto");

                    b.Property<string>("NombreCatProducto");

                    b.HasKey("CodigoCatProducto");

                    b.ToTable("CategoriasProductos");
                });

            modelBuilder.Entity("WebAppDemo01.models.Productos", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CatProductosCodigoCatProducto");

                    b.Property<int>("CodigoCategoria");

                    b.Property<string>("DescripProducto");

                    b.Property<bool>("EstadoProducto");

                    b.Property<string>("NombreProducto");

                    b.Property<decimal>("PreCostoProducto");

                    b.Property<decimal>("PreVentaProducto");

                    b.HasKey("CodigoProducto");

                    b.HasIndex("CatProductosCodigoCatProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WebAppDemo01.models.Productos", b =>
                {
                    b.HasOne("WebAppDemo01.models.CatProductos", "CatProductos")
                        .WithMany("Productos")
                        .HasForeignKey("CatProductosCodigoCatProducto");
                });
        }
    }
}
