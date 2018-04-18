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
                        new CatProductos { NombreCatProducto = "Raspberry Pi 3" },
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
