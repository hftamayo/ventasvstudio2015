using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppDemo01.models
{
    public static class DataInicio
    {
        
        public static void AgregarData(IApplicationBuilder ab)
        {
            AppDbContext contexto = ab.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!contexto.CategoriasProductos.Any())
            {
                //CategoriasProductosIniciales es una coleccion local
                contexto.CategoriasProductos.AddRange(CategoriasProductosIniciales.Select(c => c.Value));
            }
            if (!contexto.Productos.Any())
            {
                contexto.AddRange
                (
                    new Productos { NombreProducto = "Raspberry Pi 2", DescripCortaProducto = "Tableta de Entrenamiento Raspberry Pi Model B", DescripLargaProducto = "512 MB, Procesador ARM, Ethernet, HDMI, 4 USB 2.0", PreCostoProducto = 20.0M, PreVentaProducto = 35.0M, ImagenURL = "/Imagenes/productos/raspberry2.jpg", ImagenPreviaURL = "/Imagenes/productos/sraspberry2.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Tabletas de Entrenamiento"]},
                    new Productos { NombreProducto = "Raspberry Pi 3", DescripCortaProducto = "Tableta de Entrenamiento Raspberry Pi Model B+", DescripLargaProducto = "1 GB, Procesador ARM Cortex, Ethernet, HDMI, 4 USB 3.0", PreCostoProducto = 25.0M, PreVentaProducto = 40.0M, ImagenURL = "/Imagenes/productos/raspberry3.jpg", ImagenPreviaURL = "/Imagenes/productos/sraspberry3.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Tabletas de Entrenamiento"] },
                    new Productos { NombreProducto = "Raspberry Pi Zero", DescripCortaProducto = "Tableta de Entrenamiento Raspberry Pi Zero", DescripLargaProducto = "512 MB, Procesador ARM Cortex, HDMI, 1 USB 3.0", PreCostoProducto = 15.0M, PreVentaProducto = 22.0M, ImagenURL = "/Imagenes/productos/raspberryzero.jpg", ImagenPreviaURL = "/Imagenes/productos/sraspberryzero.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Tabletas de Entrenamiento"] },
                    new Productos { NombreProducto = "Office 2016 Standard", DescripCortaProducto = "Microsoft Office 2016 Standard", DescripLargaProducto = "Word, Excel, PowerPoint, Outlook", PreCostoProducto = 16.0M, PreVentaProducto = 25.0M, ImagenURL = "/Imagenes/productos/office.jpg", ImagenPreviaURL = "/Imagenes/productos/soffice.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Software"] },
                    new Productos { NombreProducto = "Office 2016 Professional", DescripCortaProducto = "Microsoft Office 2016 Professional", DescripLargaProducto = "Word, Excel, PowerPoint, Outlook, Access", PreCostoProducto = 25.0M, PreVentaProducto = 35.0M, ImagenURL = "/Imagenes/productos/office2.jpg", ImagenPreviaURL = "/Imagenes/productos/soffice2.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Software"] },
                    new Productos { NombreProducto = "Multimetro", DescripCortaProducto = "Tester con baterias AC", DescripLargaProducto = "Multimetro Digital con baterias AC", PreCostoProducto = 30.0M, PreVentaProducto = 50.0M, ImagenURL = "/Imagenes/productos/tester1.jpg", ImagenPreviaURL = "/Imagenes/productos/stester1.jpg", ProductoEnOferta = true, ProductoEnExistencia = true, EstadoProducto = true, CatProductos = CategoriasProductosIniciales["Insumos de Electronica"] }
                );
            }

            contexto.SaveChanges();
        }//fin de agregarData

        //se hace referencia a la clase dominio CatProductos
        public static Dictionary<string, CatProductos> catproductosiniciales;
        public static Dictionary<string, CatProductos> CategoriasProductosIniciales
        {
            get
            {
                if(catproductosiniciales == null)
                {
                    var listadoCategorias = new CatProductos[]
                    {
                        new CatProductos { NombreCatProducto = "Tabletas de Entrenamiento" },
                        new CatProductos { NombreCatProducto = "Software" },
                        new CatProductos { NombreCatProducto = "Insumos de Electronica" },
                    };
                    catproductosiniciales = new Dictionary<string, CatProductos>();

                    foreach(CatProductos catproini in listadoCategorias)
                    {
                        catproductosiniciales.Add(catproini.NombreCatProducto, catproini);
                    }//fin del foreach
                }
                return catproductosiniciales;
            }//fin del metodo get
        }//fin de diccionario de categorias
    }
}
